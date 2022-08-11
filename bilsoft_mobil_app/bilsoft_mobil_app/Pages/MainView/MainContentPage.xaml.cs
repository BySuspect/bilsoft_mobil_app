using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using SkiaSharp;
using bilsoft_mobil_app.Helper;
using Xamarin.Essentials;
using Android.Content.Res;
using bilsoft_mobil_app.Pages.MainView;
using Xamarin.CommunityToolkit.Extensions;
using bilsoft_mobil_app.Helper.Veriler;
using bilsoft_mobil_app.Helper.App;
using bilsoft_mobil_app.Helper.API;
using RestSharp;
using Newtonsoft.Json;
using bilsoft_mobil_app.Helper.JSONHelpers.RootAjanda;
using bilsoft_mobil_app.Pages.Ajanda;
using System.Collections.ObjectModel;

namespace bilsoft_mobil_app.Pages.MainView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainContentPage : ContentPage
    {
        #region renk Bindleri
        public Color TextColor { get; set; } = Color.FromHex(AppThemeColors._textColor);
        public Color TextColorKoyu { get; set; } = Color.FromHex(AppThemeColors._textColorKoyu);
        public Color BorderColor { get; set; } = Color.FromHex(AppThemeColors._borderColor);
        public new Color BackgroundColor { get; set; } = Color.FromHex(AppThemeColors._backgroundColor);
        public Color CardBackgroundColor { get; set; } = Color.FromHex(AppThemeColors._cardBackgroundColor);
        public Color ToolBarColor { get; set; } = Color.FromHex(AppThemeColors._toolbarcolor);
        public Color NavBarColor { get; set; } = Color.FromHex(AppThemeColors._navbarcolor);

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

        public ObservableCollection<MainContentPageViewItems> _mainContentPageViewItemsSource { get; set; }
        public MainContentPage()
        {
            InitializeComponent();
            BindingContext = this;

            MainViewStart();
        }
        #region Main Content
        private void MainViewStart()
        {
            _mainContentPageViewItemsSource = new ObservableCollection<MainContentPageViewItems>();

            _mainContentPageViewItemsSource.Add(new MainContentPageViewItems() { Name = "Menü", View = "Main" });
            _mainContentPageViewItemsSource.Add(new MainContentPageViewItems() { Name = "chart1", View = "A" });
            _mainContentPageViewItemsSource.Add(new MainContentPageViewItems() { Name = "chart2", View = "A" });
            _mainContentPageViewItemsSource.Add(new MainContentPageViewItems() { Name = "chart3", View = "A" });
            _mainContentPageViewItemsSource.Add(new MainContentPageViewItems() { Name = "chart4", View = "A" });
            _mainContentPageViewItemsSource.Add(new MainContentPageViewItems() { Name = "chart5", View = "A" });
            _mainContentPageViewItemsSource.Add(new MainContentPageViewItems() { Name = "chart6", View = "A" });

            MainPageCarouselView.ItemsSource = _mainContentPageViewItemsSource;
        }

        #endregion

        #region mainView Navigation
        private void btnNavHome_Tapped(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainContentPage(), this);
            Navigation.PopAsync(false);
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
        private async void UserPopupbtnLogout_Tapped(object sender, EventArgs e)
        {
            Preferences.Clear();
            await Navigation.PushModalAsync(new LoginPage());
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
    }
}