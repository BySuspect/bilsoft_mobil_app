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
        public Color NavBarColor { get; set; } = Color.FromHex(AppThemeColors._navbarcolor);
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

        #region Kullanıcı Ayarları Menü
        private void btnNavSettings_Tapped(object sender, EventArgs e)
        {
            userSettingsViewBack.IsVisible = true;
            UserPopupbtnLogout.TranslateTo/*        */(0, 0, 120);
            UserPopupbtnFirmaInfo.TranslateTo/*     */(0, 0, 140);
            UserPopupbtnYetkiAyarlari.TranslateTo/* */(0, 0, 160);
            UserPopupbtnMailAyarlari.TranslateTo/*  */(0, 0, 180);
        }
        private void btnNavSettingsClose_Tapped(object sender, EventArgs e)
        {
            userSettingsViewBack.IsVisible = false;
            UserPopupbtnLogout.TranslateTo/*        */(300, 0, 120);
            UserPopupbtnFirmaInfo.TranslateTo/*     */(300, 0, 140);
            UserPopupbtnYetkiAyarlari.TranslateTo/* */(300, 0, 160);
            UserPopupbtnMailAyarlari.TranslateTo/*  */(300, 0, 180);
        }
        private void UserPopupbtnMailAyarlari_Tapped(object sender, EventArgs e)
        {

        }
        private void UserPopupbtnYetkiAyarlari_Tapped(object sender, EventArgs e)
        {

        }
        private void UserPopupbtnFirmaInfo_Tapped(object sender, EventArgs e)
        {

        }
        private void UserPopupbtnLogout_Tapped(object sender, EventArgs e)
        {

        }
        #endregion

        #region Hızlı Menü
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

        #endregion

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}