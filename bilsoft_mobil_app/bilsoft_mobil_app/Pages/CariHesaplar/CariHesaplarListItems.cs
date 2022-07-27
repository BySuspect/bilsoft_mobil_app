using bilsoft_mobil_app.Helper.App;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace bilsoft_mobil_app.Pages.CariHesaplar
{
    public class CariHesaplarListItems
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

        /**/
        public int id { get; set; }
        public int cariId { get; set; }
        public string yetkili { get; set; }
        public string tel { get; set; }
        public string cep { get; set; }
        public string sevkAdres { get; set; }
        public string mail { get; set; }
        public string postaKodu { get; set; }
        public string il { get; set; }
        public string ilce { get; set; }
        public object ulke { get; set; }
        public object cariKart { get; set; }
        public int SIRA { get; set; }
        public string Bakiye { get; set; }
        public string CariAd { get; set; }
        public string btnID { get; set; }
    }
}
