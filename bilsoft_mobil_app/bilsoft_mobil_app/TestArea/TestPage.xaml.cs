using bilsoft_mobil_app.Helper.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bilsoft_mobil_app.TestArea
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        #region renk Bindleri
        public Color TextColor { get; set; } = Color.FromHex(AppThemeColors._textColor);
        public Color TextColorKoyu { get; set; } = Color.FromHex(AppThemeColors._textColorKoyu);
        public Color BorderColor { get; set; } = Color.FromHex(AppThemeColors._borderColor);
        public new Color BackgroundColor { get; set; } = Color.FromHex(AppThemeColors._backgroundColor);
        public Color CardBackgroundColor { get; set; } = Color.FromHex(AppThemeColors._cardBackgroundColor);
        public Color ToolBarColor { get; set; } = Color.FromHex(AppThemeColors._toolbarcolor);

        public Color KrediKartiColor { get; set; } = Color.FromHex(AppThemeColors._chartKrediKartiColor);
        public Color NakitColor { get; set; } = Color.FromHex(AppThemeColors._chartNakitColor);
        public Color AcikHesapColor { get; set; } = Color.FromHex(AppThemeColors._chartAcikHesapColor);
        public Color CekColor { get; set; } = Color.FromHex(AppThemeColors._chartCekColor);
        public Color _7GunVadeTahsilatColor { get; set; } = Color.FromHex(AppThemeColors._7GunVadeTahsilatGColor);
        public Color _7GunVadeOdemeColor { get; set; } = Color.FromHex(AppThemeColors._7GunVadeOdemeGColor);
        public Color _BankaHaraketGirisColor { get; set; } = Color.FromHex(AppThemeColors._7GunBankaHaraketGirisColor);
        public Color _BankaHaraketCikisColor { get; set; } = Color.FromHex(AppThemeColors._7GunBankaHaraketCikisColor);
        public Color _KasaGirisColor { get; set; } = Color.FromHex(AppThemeColors._7GunlukKasaGirisColor);
        public Color _KasaCikisColor { get; set; } = Color.FromHex(AppThemeColors._7GunlukKasaCikisColor);
        #endregion
        public TestPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        #region mainView Popup
        private void btnPopupMenu_Clicked(object sender, EventArgs e)
        {
            popupMenu.IsVisible = true;
        }

        #endregion

        private void btnPopupMenuClose_Tapped(object sender, EventArgs e)
        {
            popupMenu.IsVisible = false;
        }
    }
}