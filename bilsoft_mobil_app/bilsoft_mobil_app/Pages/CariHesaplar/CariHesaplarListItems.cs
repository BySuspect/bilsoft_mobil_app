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
        public Color BackgroundColor { get; set; } = Color.FromHex(AppThemeColors._backgroundColor);
        public Color CardBackgroundColor { get; set; } = Color.FromHex(AppThemeColors._cardBackgroundColor);
        public Color Money { get; set; } = Color.FromHex(AppThemeColors._money);
        public Color MoneyBackground { get; set; } = Color.FromHex(AppThemeColors._moneyBackground);
        #endregion

        /**/
        public int id { get; set; }
        public int SIRA { get; set; }
        public string btnId { get; set; }
        public string cariad { get; set; }
        public string bakiye { get; set; }
        public string grup { get; set; }
        public string yetkili { get; set; }
        public string tel { get; set; }
        public string cep { get; set; }
        public string adres { get; set; }
        public string mail { get; set; }
        public string fax { get; set; }
        public string faturaIl { get; set; }
        public string faturaIlce { get; set; }
        public string faturaAdres { get; set; }
        public string vergiDairesi { get; set; }
        public string vergiNo { get; set; }
        public string faturaUnvan { get; set; }
        public string webAdresi { get; set; }
        public string postakodu { get; set; }
        public string riskLimiti { get; set; }
        public string riskIslemi { get; set; }
        public string sevkAdresi { get; set; }
        public string kullaniciAdi { get; set; }
        public string subeAdi { get; set; }
        public string ticaretsicilno { get; set; }
        public string cariKod { get; set; }
    }
}
