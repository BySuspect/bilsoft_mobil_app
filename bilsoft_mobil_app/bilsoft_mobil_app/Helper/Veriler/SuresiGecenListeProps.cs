using bilsoft_mobil_app.Helper.App;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace bilsoft_mobil_app.Helper.Veriler
{
    public class SuresiGecenListeProps
    {
        #region renk Bindleri
        public Color TextColor { get; set; } = Color.FromHex(AppThemeColors._textColor);
        public Color TextColorKoyu { get; set; } = Color.FromHex(AppThemeColors._textColorKoyu);
        public Color BorderColor { get; set; } = Color.FromHex(AppThemeColors._borderColor);
        public new Color BackgroundColor { get; set; } = Color.FromHex(AppThemeColors._backgroundColor);
        public Color CardBackgroundColor { get; set; } = Color.FromHex(AppThemeColors._cardBackgroundColor);
        public Color ToolBarColor { get; set; } = Color.FromHex(AppThemeColors._toolbarcolor);
        #endregion
        public string AdSoyad { get; set; }
        public string Firma { get; set; }
        public string Aciklama { get; set; }
    }
}
