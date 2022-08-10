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

        #region mainView Navigation

        private void btnNavHome_Tapped(object sender, EventArgs e)
        {

        }
        private void btnNavSettings_Tapped(object sender, EventArgs e)
        {

        }
        private void btnNavMenu_Tapped(object sender, EventArgs e)
        {
            this.CancelAnimations();
            popupMenuBack.IsVisible = true;
            PopUpMenuItemPanel.TranslateTo/*       */(0, 0, 120);
            PopUpMenuItemCariArama.TranslateTo/*   */(0, 0, 140);
            PopUpMenuItemCariIslemler.TranslateTo/**/(0, 0, 160);
            PopUpMenuItemStokKartlar.TranslateTo/* */(0, 0, 180);
            PopUpMenuItemSatisYap.TranslateTo/*    */(0, 0, 200);
            PopUpMenuItemFaturalar.TranslateTo/*   */(0, 0, 220);
            PopUpMenuItemFiyatGor.TranslateTo/*    */(0, 0, 240);
        }

        private void btnPopupMenuClose_Tapped(object sender, EventArgs e)
        {
            this.CancelAnimations();
            popupMenuBack.IsVisible = false;
            PopUpMenuItemPanel.TranslateTo/*       */(-300, 0, 120);
            PopUpMenuItemCariArama.TranslateTo/*   */(-300, 0, 140);
            PopUpMenuItemCariIslemler.TranslateTo/**/(-300, 0, 160);
            PopUpMenuItemStokKartlar.TranslateTo/* */(-300, 0, 180);
            PopUpMenuItemSatisYap.TranslateTo/*    */(-300, 0, 200);
            PopUpMenuItemFaturalar.TranslateTo/*   */(-300, 0, 220);
            PopUpMenuItemFiyatGor.TranslateTo/*    */(-300, 0, 240);
        }

        #region popup menu items
        private void btnPopUpMenuItemPanel_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("", sender.ToString(), "ok");
        }

        private void btnPopUpMenuItemCariArama_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("", sender.ToString(), "ok");
        }

        private void btnPopUpMenuItemCariIslemler_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("", sender.ToString(), "ok");
        }

        private void btnPopUpMenuItemStokKartlar_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("", sender.ToString(), "ok");
        }

        private void btnPopUpMenuItemSatisYap_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("", sender.ToString(), "ok");
        }

        private void btnPopUpMenuItemFaturalar_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("", sender.ToString(), "ok");
        }

        private void btnPopUpMenuItemFiyatGor_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("", sender.ToString(), "ok");
        }
        #endregion

        #endregion
        bool test = true;
        private void Button_Clicked(object sender, EventArgs e)
        {
            this.CancelAnimations();
            if (test)
            {
                PopUpMenuItemPanel.TranslateTo(0, 0, 100);
                PopUpMenuItemCariArama.TranslateTo(0, 0, 200);
                PopUpMenuItemCariIslemler.TranslateTo(0, 0, 300);
                PopUpMenuItemStokKartlar.TranslateTo(0, 0, 400);
                PopUpMenuItemSatisYap.TranslateTo(0, 0, 500);
                PopUpMenuItemFaturalar.TranslateTo(0, 0, 600);
                PopUpMenuItemFiyatGor.TranslateTo(0, 0, 700);
                test = false;
            }
            else
            {
                PopUpMenuItemPanel.TranslateTo(-1000, 0, 100);
                PopUpMenuItemCariArama.TranslateTo(-1000, 0, 200);
                PopUpMenuItemCariIslemler.TranslateTo(-1000, 0, 300);
                PopUpMenuItemStokKartlar.TranslateTo(-1000, 0, 400);
                PopUpMenuItemSatisYap.TranslateTo(-1000, 0, 500);
                PopUpMenuItemFaturalar.TranslateTo(-1000, 0, 600);
                PopUpMenuItemFiyatGor.TranslateTo(-1000, 0, 700);
                test = true;
            }
        }
    }
}