using System;
using Xamarin.Forms;

namespace bilsoft_mobil_app.CustomItems
{
    public class CustomEntry : Frame
    {
        BorderlessEntry _entry;

        string _text = "",
               _placeholder = "";

        TextAlignment _horizontal = TextAlignment.Start,
                      _vertical = TextAlignment.Center;

        int _entryFontSize = 20;

        Keyboard _entryKeyboard;

        Color _entryTextColor = Color.Black,
              _placeholderColor = Color.Default;
        public CustomEntry() : base()
        {
            _entry = new BorderlessEntry();
            #region Entry Settings
            _entry.Margin = new Thickness(-15);
            _entry.TextColor = _entryTextColor;
            _entry.FontSize = _entryFontSize;
            _entry.SetBinding(Entry.TextProperty, "Value");
            _entry.Keyboard = _entryKeyboard;
            _entry.Text = _text;
            _entry.Placeholder = _placeholder;
            _entry.PlaceholderColor = _placeholderColor;
            _entry.HorizontalTextAlignment = _horizontal;
            _entry.VerticalTextAlignment = _vertical;
            _entry.TextChanged += (sender, args) =>
            {
                OnTextChanged(args);
            };
            _entry.Unfocused += (sender, args) =>
            {
                OnUnFocused(args);
            };
            #endregion
            this.Content = _entry;
            this.BackgroundColor = Color.Transparent;
            this.CornerRadius = 15;
        }
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                _entry.Text = value;
            }

        }
        public TextAlignment HorizontalTextAlignment
        {
            get
            {
                return _horizontal;
            }
            set
            {
                _horizontal = value;
                _entry.HorizontalTextAlignment = value;

            }
        }
        public TextAlignment VerticalTextAlignment
        {
            get
            {
                return _vertical;
            }
            set
            {
                _vertical = value;
                _entry.VerticalTextAlignment = value;
            }
        }
        public string Placeholder
        {
            get
            {
                return _placeholder;
            }
            set
            {
                _placeholder = value;
                _entry.Placeholder = value;
            }
        }
        public Keyboard Keyboard
        {
            get
            {
                return _entryKeyboard;
            }
            set
            {
                _entryKeyboard = value;
                _entry.Keyboard = value;
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
        public Color PlaceholderColor
        {
            get
            {
                return _placeholderColor;
            }
            set
            {
                _entry.PlaceholderColor = value;
                _placeholderColor = value;
            }
        }
        public int FontSize
        {
            get
            {
                return _entryFontSize;
            }
            set
            {
                _entry.FontSize = value;
                _entryFontSize = value;
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

        public event EventHandler<TextChangedEventArgs> TextChanged;
        protected virtual void OnTextChanged(TextChangedEventArgs e)
        {
            EventHandler<TextChangedEventArgs> handler = TextChanged;
            handler?.Invoke(this, e);
        }

        public event EventHandler<FocusEventArgs> UnFocused;
        protected virtual void OnUnFocused(FocusEventArgs e)
        {
            EventHandler<FocusEventArgs> handler = UnFocused;
            handler?.Invoke(this, e);
        }
    }
}
