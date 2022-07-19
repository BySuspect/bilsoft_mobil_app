using bilsoft_mobil_app.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace bilsoft_mobil_app.CustomItems
{
    public class NumericUpDown : Frame
    {
        Grid _grid;
        CustomNumericUpDownEntry _entry;
        StackLayout _stackLayout;
        Button _btnup, _btndown;

        double _value = 0,
            _maxValue = 60,
            _minValue = 0,
            _increaseValue = 1;

        int _btnCornerRadius = 15,
            _btnBorderWith = 1,
            _btnFontSize = 20,
            _entryFontSize = 20;

        Color _btnUpBackColor = Color.White,
            _btnDownBackColor = Color.White,
            _btnUpBorderColor = Color.FromHex(AppThemeColors._borderColor),
            _btnDownBorderColor = Color.FromHex(AppThemeColors._borderColor),
            _entryTextColor = Color.FromHex(AppThemeColors._textColor),
            _btnUpTextColor = Color.FromHex(AppThemeColors._textColor),
            _btnDownTextColor = Color.FromHex(AppThemeColors._textColor);
        public NumericUpDown() : base()
        {
            BindingContext = this;
            _grid = new Grid();
            _entry = new CustomNumericUpDownEntry();
            _stackLayout = new StackLayout();
            _btnup = new Button();
            _btndown = new Button();

            #region Entry Settings
            _entry.Margin = new Thickness(15, 0, 0, 0);
            _entry.TextColor = _entryTextColor;
            _entry.FontSize = _entryFontSize;
            _entry.SetBinding(Entry.TextProperty, "Value");
            _entry.Keyboard = Keyboard.Numeric;
            _entry.TextChanged += (sender, args) =>
            {
                OnTextChanged(args);
            };
            _entry.Unfocused += entry_unfocused;
            #endregion

            #region btnup settings
            _btnup.WidthRequest = 50;
            _btnup.FontSize = _btnFontSize;
            _btnup.FontAttributes = FontAttributes.Bold;
            _btnup.TextColor = _btnUpTextColor;
            _btnup.VerticalOptions = LayoutOptions.Center;
            _btnup.CornerRadius = _btnCornerRadius;
            _btnup.BorderColor = _btnUpBorderColor;
            _btnup.BorderWidth = _btnBorderWith;
            _btnup.BackgroundColor = _btnUpBackColor;
            _btnup.Text = "+";
            _btnup.Clicked += (e, args) =>
            {
                Unfocus();
                if (_value < _maxValue)
                {
                    _btndown.IsEnabled = true;
                    _value = Convert.ToDouble(_entry.Text) + _increaseValue;
                    _entry.Text = _value.ToString();
                    if (_value == _maxValue) _btnup.IsEnabled = false;
                }
                else
                {
                    _value = maxValue;
                    _entry.Text = _value.ToString();
                    _btnup.IsEnabled = false;
                }
            };
            #endregion

            #region btndown settings
            _btndown.WidthRequest = 50;
            _btndown.FontSize = _btnFontSize;
            _btndown.FontAttributes = FontAttributes.Bold;
            _btndown.TextColor = _btnDownTextColor;
            _btndown.VerticalOptions = LayoutOptions.Center;
            _btndown.BorderColor = _btnDownBorderColor;
            _btndown.BorderWidth = _btnBorderWith;
            _btndown.CornerRadius = _btnCornerRadius;
            _btndown.BackgroundColor = _btnDownBackColor;
            _btndown.Text = "-";
            _btndown.Clicked += (e, args) =>
            {
                Unfocus();
                if (_value > _minValue)
                {
                    _btnup.IsEnabled = true;
                    _value = Convert.ToDouble(_entry.Text) - _increaseValue;
                    _entry.Text = _value.ToString();
                    if (_value == _minValue) _btndown.IsEnabled = false;
                }
                else
                {
                    _value = _minValue;
                    _entry.Text = _value.ToString();
                    _btndown.IsEnabled = false;
                }
            };
            #endregion

            #region stacklayout settings
            _stackLayout.Orientation = StackOrientation.Horizontal;
            _stackLayout.HorizontalOptions = LayoutOptions.EndAndExpand;
            _stackLayout.Children.Add(_btndown);
            _stackLayout.Children.Add(_btnup);
            #endregion

            #region grid settings
            _grid.Margin = new Thickness(-10, -15, -10, -15);
            _grid.Children.Add(_entry);
            _grid.Children.Add(_stackLayout);
            #endregion

            Content = _grid;
            this.BorderColor = Color.FromHex(AppThemeColors._borderColor);
            this.CornerRadius = 15;
        }

        public double maxValue
        {
            get
            {
                return _maxValue;
            }
            set
            {
                _maxValue = value;
            }
        }
        public double minValue
        {
            get
            {
                return _minValue;
            }
            set
            {
                _minValue = value;
                if (Value <= minValue)
                {
                    Value = _minValue;
                    _value = _minValue;
                    _entry.Text = _value.ToString();
                    _btndown.IsEnabled = false;
                    _btnup.IsEnabled = true;
                }
            }
        }
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _entry.Text = value.ToString();
                _value = value;
            }
        }
        public double Increment
        {
            get
            {
                return _increaseValue;
            }
            set
            {
                _increaseValue = value;
            }
        }
        public Color UpButtonBackgroundColor
        {
            get
            {
                return _btnUpBackColor;
            }
            set
            {
                _btnup.BackgroundColor = value;
                _btnUpBackColor = value;
            }
        }
        public Color DownButtonBackgroundColor
        {
            get
            {
                return _btnDownBackColor;
            }
            set
            {
                _btndown.BackgroundColor = value;
                _btnDownBackColor = value;
            }
        }
        public Color UpButtonBorderColor
        {
            get
            {
                return _btnUpBorderColor;
            }
            set
            {
                _btnup.BorderColor = value;
                _btnUpBorderColor = value;
            }
        }
        public Color DownButtonBorderColor
        {
            get
            {
                return _btnDownBorderColor;
            }
            set
            {
                _btndown.BorderColor = value;
                _btnDownBorderColor = value;
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
        public Color ButtonUpTextColor
        {
            get
            {
                return _btnUpTextColor;
            }
            set
            {
                _btnup.TextColor = value;
                _btnUpTextColor = value;
            }
        }
        public Color ButtonDownTextColor
        {
            get
            {
                return _btnDownTextColor;
            }
            set
            {
                _btndown.TextColor = value;
                _btnDownTextColor = value;
            }
        }
        public int TextFontSize
        {
            get
            {
                return _entryFontSize;
            }
            set
            {
                _entry.FontSize = value;
                _entry.FontSize = value;
                _entryFontSize = value;
            }
        }
        public int ButtonFontSize
        {
            get
            {
                return _btnFontSize;
            }
            set
            {
                _btnup.FontSize = value;
                _btndown.FontSize = value;
                _btnFontSize = value;
            }
        }
        public int ButtonBorderWith
        {
            get
            {
                return _btnBorderWith;
            }
            set
            {
                _btnup.BorderWidth = value;
                _btndown.BorderWidth = value;
                _btnBorderWith = value;
            }
        }
        public int ButtonCornerRadius
        {
            get
            {
                return _btnCornerRadius;
            }
            set
            {
                _btnup.CornerRadius = value;
                _btndown.CornerRadius = value;
                _btnCornerRadius = value;
            }
        }
        public event EventHandler<TextChangedEventArgs> TextChanged;
        protected virtual void OnTextChanged(TextChangedEventArgs e)
        {
            EventHandler<TextChangedEventArgs> handler = TextChanged;
            handler?.Invoke(this, e);
        }
        private void entry_unfocused(object sender, FocusEventArgs e)
        {
            if (Convert.ToDouble(_entry.Text) >= maxValue)
            {
                _value = maxValue;
                _entry.Text = _value.ToString();
                _btnup.IsEnabled = false;
                _btndown.IsEnabled = true;
            }
            else if (Convert.ToDouble(_entry.Text) <= minValue)
            {
                _value = minValue;
                _entry.Text = _value.ToString();
                _btndown.IsEnabled = false;
                _btnup.IsEnabled = true;
            }
        }
        public new void Unfocus()
        {
            _entry.Unfocus();
        }
    }
    public class CustomNumericUpDownEntry : Entry
    {

    }
}
