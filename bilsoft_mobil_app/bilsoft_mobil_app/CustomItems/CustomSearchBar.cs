using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static Xamarin.Forms.VisualMarker;

namespace bilsoft_mobil_app.CustomItems
{
    public class CustomSearchBar : Frame
    {
        Grid _grid;
        BorderlessEntry _entry;
        Button _btn;

        string _placeHolder = "Search...",
            _btnText = null;

        int _btnCornerRadius = 15;

        Color _entryPlaceHolderColor = Color.Gray,
            _entryTextColor = Color.Black,
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


            //Button
            _btn.HorizontalOptions = LayoutOptions.EndAndExpand;
            _btn.CornerRadius = _btnCornerRadius;
            _btn.BackgroundColor = _btnBackColor;
            _btn.Margin = new Thickness(0, 0, -10, 0);
            _btn.HeightRequest = _grid.Height;
            _btn.WidthRequest = _grid.Height;
            if (_btnText == null) _btn.ImageSource = _btnImageSource;
            else _btn.Text = _btnText;

            //Grid
            _grid.Margin = new Thickness(0, -15);

            _grid.Children.Add(_entry);
            _grid.Children.Add(_btn);

            //Frame
            this.BackgroundColor = Color.Transparent;
            this.Content = _grid;
        }
    }
}
