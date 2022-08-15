using bilsoft_mobil_app.Helper.App;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace bilsoft_mobil_app.Pages.MainView
{
    public class MainContentPageViewItems
    {
        #region renk Bindleri
        public Color TextColor { get; set; } = Color.FromHex(AppThemeColors._textColor);
        public Color TextColorKoyu { get; set; } = Color.FromHex(AppThemeColors._textColorKoyu);
        public Color BorderColor { get; set; } = Color.FromHex(AppThemeColors._borderColor);
        public new Color BackgroundColor { get; set; } = Color.FromHex(AppThemeColors._backgroundColor);
        public Color CardBackgroundColor { get; set; } = Color.FromHex(AppThemeColors._cardBackgroundColor);
        public Color ToolBarColor { get; set; } = Color.FromHex(AppThemeColors._toolbarcolor);
        public Color NavBarColor { get; set; } = Color.FromHex(AppThemeColors._navbarcolor);
        #endregion
        public string Name { get; set; }
        public string View { get; set; }
        public Chart ChartView { get; set; }

        public string ChartValueName1 { get; set; }
        public string ChartValue1 { get; set; }
        public Color ChartValueColor1 { get; set; }
        public string ChartValueName2 { get; set; }
        public string ChartValue2 { get; set; }
        public Color ChartValueColor2 { get; set; }
        public string ChartValueName3 { get; set; }
        public string ChartValue3 { get; set; }
        public Color ChartValueColor3 { get; set; }
        public string ChartValueName4 { get; set; }
        public string ChartValue4 { get; set; }
        public Color ChartValueColor4 { get; set; }
    }
}
