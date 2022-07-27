﻿using bilsoft_mobil_app.CustomItems;
using bilsoft_mobil_app.Helper.App;
using System;
using System.Collections;
using static Xamarin.Forms.VisualMarker;

namespace Xamarin.Forms.ComboBox
{
    /// <summary>
    /// Combo box with search option
    /// </summary>
    public class ComboBox : Frame
    {
        private StackLayout _stackLayout;
        private BorderlessEntry _entry;
        private ListView _listView;
        private bool _supressFiltering;
        private bool _supressSelectedItemFiltering;

        //Bindable properties
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(ComboBox), defaultValue: null, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var comboBox = (ComboBox)bindable;
            comboBox._listView.ItemsSource = (IEnumerable)newVal;
        });

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(ComboBox), defaultValue: null, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var comboBox = (ComboBox)bindable;
            comboBox._listView.SelectedItem = newVal;
        });

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static new readonly BindableProperty VisualProperty = BindableProperty.Create(nameof(Visual), typeof(IVisual), typeof(ComboBox), defaultValue: new DefaultVisual(), propertyChanged: (bindable, oldVal, newVal) =>
        {
            var comboBox = (ComboBox)bindable;
            comboBox._listView.Visual = (IVisual)newVal;
            comboBox._entry.Visual = (IVisual)newVal;
        });

        public new IVisual Visual
        {
            get { return (IVisual)GetValue(VisualProperty); }
            set { SetValue(VisualProperty, value); }
        }

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(ComboBox), defaultValue: "", propertyChanged: (bindable, oldVal, newVal) =>
        {
            var comboBox = (ComboBox)bindable;
            comboBox._entry.Placeholder = (string)newVal;
        });

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(ComboBox), defaultValue: "", propertyChanged: (bindable, oldVal, newVal) =>
        {
            var comboBox = (ComboBox)bindable;
            comboBox._entry.Text = (string)newVal;
        });

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(ComboBox), defaultValue: null, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var comboBox = (ComboBox)bindable;
            comboBox._listView.ItemTemplate = (DataTemplate)newVal;
        });

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public static readonly BindableProperty EntryDisplayPathProperty = BindableProperty.Create(nameof(EntryDisplayPath), typeof(string), typeof(ComboBox), defaultValue: "");

        public string EntryDisplayPath
        {
            get { return (string)GetValue(EntryDisplayPathProperty); }
            set { SetValue(EntryDisplayPathProperty, value); }
        }

        public event EventHandler<SelectedItemChangedEventArgs> SelectedItemChanged;

        protected virtual void OnSelectedItemChanged(SelectedItemChangedEventArgs e)
        {
            EventHandler<SelectedItemChangedEventArgs> handler = SelectedItemChanged;
            handler?.Invoke(this, e);
        }

        public event EventHandler<TextChangedEventArgs> TextChanged;

        protected virtual void OnTextChanged(TextChangedEventArgs e)
        {
            EventHandler<TextChangedEventArgs> handler = TextChanged;
            handler?.Invoke(this, e);
        }

        public ComboBox()
        {
            //Entry used for filtering list view
            _entry = new BorderlessEntry();
            _entry.Margin = new Thickness(0);
            _entry.Keyboard = Keyboard.Create(KeyboardFlags.None);
            _entry.Focused += (sender, args) => _listView.IsVisible = true;
            _entry.Unfocused += (sender, args) => _listView.IsVisible = false;


            //Text changed event, bring it back to the surface
            _entry.TextChanged += (sender, args) =>
            {
                if (_supressFiltering)
                    return;

                if (String.IsNullOrEmpty(args.NewTextValue))
                {
                    _supressSelectedItemFiltering = true;
                    _listView.SelectedItem = null;
                    _supressSelectedItemFiltering = false;
                }

                _listView.IsVisible = true;

                OnTextChanged(args);
            };

            //List view - used to display search options
            _listView = new ListView();
            _listView.Margin = new Thickness(0);
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.ListView.SetSeparatorStyle(_listView, Xamarin.Forms.PlatformConfiguration.iOSSpecific.SeparatorStyle.FullWidth);
            _listView.HeightRequest = 120;
            _listView.HorizontalOptions = LayoutOptions.StartAndExpand;
            _listView.IsVisible = false;
            _listView.SetBinding(ListView.SelectedItemProperty, new Binding(nameof(ComboBox.SelectedItem), source: this));

            //Item selected event, surface it back to the top
            _listView.ItemSelected += (sender, args) =>
            {
                if (!_supressSelectedItemFiltering)
                {
                    _supressFiltering = true;

                    var selectedItem = args.SelectedItem;
                    _entry.Text = !String.IsNullOrEmpty(EntryDisplayPath) && selectedItem != null ? selectedItem.GetType().GetProperty(EntryDisplayPath).GetValue(selectedItem, null).ToString() : selectedItem?.ToString();

                    _supressFiltering = false;
                    _listView.IsVisible = false;
                    Unfocus();
                    OnSelectedItemChanged(args);
                }
            };

            //Add bottom border
            var boxView = new BoxView();
            boxView.HeightRequest = 1;
            boxView.Color = Color.FromHex(AppThemeColors._borderColor);
            boxView.Margin = new Thickness(0);
            boxView.SetBinding(BoxView.IsVisibleProperty, new Binding(nameof(ListView.IsVisible), source: _listView));

            //Custom preferences
            _stackLayout = new StackLayout();
            _entry.BackgroundColor = Color.Transparent;
            _entry.HorizontalTextAlignment = TextAlignment.Start;
            _listView.BackgroundColor = Color.Transparent;
            _entry.TextColor = Color.White;
            _entry.PlaceholderColor = Color.White;
            this.BorderColor = Color.FromHex(AppThemeColors._borderColor);
            this.CornerRadius = 15;
            _stackLayout.Margin = new Thickness(-15);

            //Add main view
            _stackLayout.Children.Add(_entry);
            _stackLayout.Children.Add(_listView);
            //_stackLayout.Children.Add(boxView);

            this.Content = _stackLayout;
        }

        public new bool Focus()
        {
            return _entry.Focus();
        }

        public new void Unfocus()
        {
            _entry.Unfocus();
        }
    }
}
