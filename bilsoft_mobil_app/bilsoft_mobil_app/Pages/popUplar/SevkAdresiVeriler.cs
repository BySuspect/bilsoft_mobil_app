using bilsoft_mobil_app.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace bilsoft_mobil_app.Pages.popUplar
{
    public class SevkAdresiVeriler
    {
        #region renk Bindleri
        public Color TextColor { get; set; } = Color.FromHex(AppThemeColors._textColor);
        public Color TextColorKoyu { get; set; } = Color.FromHex(AppThemeColors._textColorKoyu);
        public Color Success { get; set; } = Color.FromHex(AppThemeColors._success);
        public Color BorderColor { get; set; } = Color.FromHex(AppThemeColors._borderColor);
        public new Color BackgroundColor { get; set; } = Color.FromHex(AppThemeColors._backgroundColor);
        public Color CardBackgroundColor { get; set; } = Color.FromHex(AppThemeColors._cardBackgroundColor);
        public Color Money { get; set; } = Color.FromHex(AppThemeColors._money);
        public Color MoneyBackground { get; set; } = Color.FromHex(AppThemeColors._moneyBackground);
        #endregion
        public string ulke { get; set; }
        public string il { get; set; }
        public string ilce { get; set; }
        public string yetkili { get; set; }
        public string postakodu { get; set; }
        public string tel { get; set; }
        public string ceptel { get; set; }
        public string sevkadres { get; set; }
    }
}
