using System;
using Xamarin.Forms;

namespace bilsoft_mobil_app.CustomItems
{
    public class CustomSearchBar : Frame
    {
        Grid _grid;
        BorderlessEntry _entry;
        Button _btn;

        string _placeHolder = "Search...",
            _btnText = "",
            _entryText = "";

        int _btnCornerRadius = 15;

        Color _entryPlaceHolderColor = Color.White,
            _entryTextColor = Color.White,
            _btnBackColor = Color.Blue;

        ImageSource _btnImageSource = "search24px.png";
        public CustomSearchBar() : base()
        {
            _grid = new Grid();
            _entry = new BorderlessEntry();
            _btn = new Button();

            //Entry
            _entry.Placeholder = _placeHolder;
            _entry.PlaceholderColor = _entryPlaceHolderColor;
            _entry.VerticalTextAlignment = TextAlignment.Center;
            _entry.VerticalOptions = LayoutOptions.Center;
            _entry.TextColor = _entryTextColor;
            _entry.TextChanged += (sender, args) =>
            {
                _entryText = _entry.Text;
                OnTextChanged(args);
            };
            _entry.Unfocused += entry_unfocused;


            //Button
            _btn.HorizontalOptions = LayoutOptions.EndAndExpand;
            _btn.CornerRadius = _btnCornerRadius;
            _btn.BackgroundColor = _btnBackColor;
            _btn.Margin = new Thickness(0, 0, -15, 0);
            _btn.BackgroundColor = Color.FromHex("#03a647");
            _btn.BorderColor = this.BorderColor;
            _btn.BorderWidth = 1;
            //_btn.HeightRequest = _grid.Height;
            // _btn.WidthRequest = _grid.Height;
            if (_btnText == "") _btn.ImageSource = _btnImageSource;
            else _btn.Text = _btnText;
            _btn.Clicked += (e, args) =>
            {
                onClicked(args);
            };

            //Grid
            _grid.Margin = new Thickness(0, -15);

            _grid.Children.Add(_entry);
            _grid.Children.Add(_btn);

            //Frame
            this.BackgroundColor = Color.Transparent;
            this.Content = _grid;
        }
        public event EventHandler<TextChangedEventArgs> TextChanged;
        protected virtual void OnTextChanged(TextChangedEventArgs e)
        {
            EventHandler<TextChangedEventArgs> handler = TextChanged;
            handler?.Invoke(this, e);
        }
        private void entry_unfocused(object sender, FocusEventArgs e)
        {

        }
        public event EventHandler<EventArgs> Clicked;
        protected virtual void onClicked(EventArgs e)
        {
            EventHandler<EventArgs> handler = Clicked;
            handler?.Invoke(this, e);
        }
        public string Placeholder
        {
            get
            {
                return _placeHolder;
            }
            set
            {
                _entry.Placeholder = value;
                _placeHolder = value;
            }
        }
        public string Text
        {
            get
            {
                return _entryText;
            }
            set
            {
                _entry.Text = value;
                _entryText = value;
            }
        }
        public Color TextColor
        {
            get
            {
                return _entryTextColor;
            }
            set
            {
                _entry.TextColor = value;
                _entryTextColor = value;
            }
        }
        public Color PlaceHolderColor
        {
            get
            {
                return _entryPlaceHolderColor;
            }
            set
            {
                _entry.PlaceholderColor = value;
                _entryPlaceHolderColor = value;
            }
        }
    }
}
