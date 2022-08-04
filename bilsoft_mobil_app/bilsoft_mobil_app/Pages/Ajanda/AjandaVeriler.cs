using bilsoft_mobil_app.Helper.App;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace bilsoft_mobil_app.Pages.Ajanda
{
    public class AjandaVeriler
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
        public int id { get; set; }
        public string btnid { get; set; }
        public int userId { get; set; }
        public string adSoyad { get; set; }
        public string firma { get; set; }
        public string tel { get; set; }
        public string cep { get; set; }
        public string aciklama { get; set; }
        public DateTime tarih { get; set; }
        public bool okundu { get; set; }
        public object user { get; set; }
        public List<object> ajandaDosya { get; set; }
    }
}
