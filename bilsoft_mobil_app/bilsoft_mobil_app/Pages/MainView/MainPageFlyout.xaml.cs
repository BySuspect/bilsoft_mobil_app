﻿using bilsoft_mobil_app.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bilsoft_mobil_app.Pages.MainView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageFlyout : ContentPage
    {

        public ListView ListView;

        public MainPageFlyout()
        {
            InitializeComponent();

            BindingContext = new MainPageFlyoutViewModel();
        }

        private class MainPageFlyoutViewModel : INotifyPropertyChanged
        {
            #region renk Bindleri
            public Color TextColor { get; set; } = Color.FromHex(AppThemeColors._textColor);
            public Color TextColorKoyu { get; set; } = Color.FromHex(AppThemeColors._textColorKoyu);
            public Color BorderColor { get; set; } = Color.FromHex(AppThemeColors._borderColor);
            public Color BackgroundColor { get; set; } = Color.FromHex(AppThemeColors._backgroundColor);
            public Color CardBackgroundColor { get; set; } = Color.FromHex(AppThemeColors._cardBackgroundColor);
            public Color ToolBarColor { get; set; } = Color.FromHex(AppThemeColors._toolbarcolor);
            #endregion
            public ObservableCollection<MainPageFlyoutMenuItem> MenuItems { get; set; }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        #region tree view
        //cari, stok, taksit, satis, kasa, banka, cek-senet, diger, gelir-gider
        private string openedTree;

        #region Raporlar/Cari
        private void btnMenuRaporlarCari_Clicked(object sender, EventArgs e)
        {
            if (RaporlarCariToggle.IsVisible)
            {
                RaporlarCariToggle.IsVisible = false;
                openedTree = null;
                btnMenuRaporlarCari.Text = "Cari ◀";
            }
            else
            {
                RaporlarCariToggle.IsVisible = true;
                openedTree = "cari";
                btnMenuRaporlarCari.Text = "Cari ▼";

                //RaporlarCariToggle.IsVisible = false;
                RaporlarDigerToggle.IsVisible = false;
                RaporlarCekSenetToggle.IsVisible = false;
                RaporlarBankaToggle.IsVisible = false;
                RaporlarKasaToggle.IsVisible = false;
                RaporlarSatisToggle.IsVisible = false;
                RaporlarTaksitToggle.IsVisible = false;
                RaporlarStokToggle.IsVisible = false;
                RaporlarGelirGiderToggle.IsVisible = false;
            }
        }

        private void btnMenuRaporlarCariBakiyeRaporu_Clicked(object sender, EventArgs e)
        {

        }
        private void btnMenuRaporlarCariHesapEkstreRaporu_Clicked(object sender, EventArgs e)
        {

        }
        private void btnMenuRaporlarCariIslemRaporu_Clicked(object sender, EventArgs e)
        {

        }

        private void btnMenuRaporlarCariBA_BSRaporu_Clicked(object sender, EventArgs e)
        {

        }

        private void btnMenuRaporlarCariMutabakatRaporu_Clicked(object sender, EventArgs e)
        {

        }

        #endregion

        #region Raporlar/Stok
        private void btnMenuRaporlarStok_Clicked(object sender, EventArgs e)
        {
            if (RaporlarStokToggle.IsVisible)
            {
                RaporlarStokToggle.IsVisible = false;
                openedTree = null;
                btnMenuRaporlarStok.Text = "Stok ◀";
            }
            else
            {
                RaporlarStokToggle.IsVisible = true;
                openedTree = "stok";
                btnMenuRaporlarStok.Text = "Stok ▼";

                RaporlarCariToggle.IsVisible = false;
                RaporlarDigerToggle.IsVisible = false;
                RaporlarCekSenetToggle.IsVisible = false;
                RaporlarBankaToggle.IsVisible = false;
                RaporlarKasaToggle.IsVisible = false;
                RaporlarSatisToggle.IsVisible = false;
                RaporlarTaksitToggle.IsVisible = false;
                //RaporlarStokToggle.IsVisible = false;
                RaporlarGelirGiderToggle.IsVisible = false;
            }
        }
        private void btnMenuRaporlarStokHaraketleriRaporu_Clicked(object sender, EventArgs e)
        {
            if (RaporlarStokToggle.IsVisible)
            {
                RaporlarStokToggle.IsVisible = false;
                openedTree = "";
            }
            else
            {
                RaporlarStokToggle.IsVisible = true;
                openedTree = "stok";
            }
        }
        private void btnMenuRaporlarStokBakiyeRaporu_Clicked(object sender, EventArgs e)
        {

        }
        private void btnMenuRaporlarStokFiyatListesi_Clicked(object sender, EventArgs e)
        {

        }
        private void btnMenuRaporlarStokDepoHaraketleriRaporu_Clicked(object sender, EventArgs e)
        {

        }
        private void btnMenuRaporlarStokDepoAktarimRaporu_Clicked(object sender, EventArgs e)
        {

        }
        #endregion

        #region Raporlar/Taksit
        private void btnMenuRaporlarTaksit_Clicked(object sender, EventArgs e)
        {
            if (RaporlarTaksitToggle.IsVisible)
            {
                openedTree = null;
                RaporlarTaksitToggle.IsVisible = false;
                btnMenuRaporlarTaksit.Text = "Taksit ◀";
            }
            else
            {
                openedTree = "taksit";
                RaporlarTaksitToggle.IsVisible = true;
                btnMenuRaporlarTaksit.Text = "Taksit ▼";

                RaporlarCariToggle.IsVisible = false;
                RaporlarDigerToggle.IsVisible = false;
                RaporlarCekSenetToggle.IsVisible = false;
                RaporlarBankaToggle.IsVisible = false;
                RaporlarKasaToggle.IsVisible = false;
                RaporlarSatisToggle.IsVisible = false;
                //RaporlarTaksitToggle.IsVisible = false;
                RaporlarStokToggle.IsVisible = false;
                RaporlarGelirGiderToggle.IsVisible = false;
            }
        }
        private void btnMenuRaporlarTaksitRaporu_Clicked(object sender, EventArgs e)
        {

        }
        #endregion

        #region Raporlar/Satis
        private void btnMenuRaporlarSatis_Clicked(object sender, EventArgs e)
        {
            if (RaporlarSatisToggle.IsVisible)
            {
                openedTree = null;
                RaporlarSatisToggle.IsVisible = false;
                btnMenuRaporlarSatis.Text = "Satış ◀";
            }
            else
            {
                openedTree = "satis";
                RaporlarSatisToggle.IsVisible = true;
                btnMenuRaporlarSatis.Text = "Satış ▼";

                RaporlarCariToggle.IsVisible = false;
                RaporlarDigerToggle.IsVisible = false;
                RaporlarCekSenetToggle.IsVisible = false;
                RaporlarBankaToggle.IsVisible = false;
                RaporlarKasaToggle.IsVisible = false;
                //RaporlarSatisToggle.IsVisible = false;
                RaporlarTaksitToggle.IsVisible = false;
                RaporlarStokToggle.IsVisible = false;
                RaporlarGelirGiderToggle.IsVisible = false;
            }
        }

        private void btnMenuRaporlarSatisRaporu_Clicked(object sender, EventArgs e)
        {

        }

        private void btnMenuRaporlarSatisGrafigi_Clicked(object sender, EventArgs e)
        {

        }
        #endregion

        #region Raporlar/Kasa
        private void btnMenuRaporlarKasa_Clicked(object sender, EventArgs e)
        {
            if (RaporlarKasaToggle.IsVisible)
            {
                openedTree = null;
                RaporlarKasaToggle.IsVisible = false;
                btnMenuRaporlarKasa.Text = "Kasa ◀";
            }
            else
            {
                openedTree = "kasa";
                RaporlarKasaToggle.IsVisible = true;
                btnMenuRaporlarKasa.Text = "Kasa ▼";

                RaporlarCariToggle.IsVisible = false;
                RaporlarDigerToggle.IsVisible = false;
                RaporlarCekSenetToggle.IsVisible = false;
                RaporlarBankaToggle.IsVisible = false;
                //RaporlarKasaToggle.IsVisible = false;
                RaporlarSatisToggle.IsVisible = false;
                RaporlarTaksitToggle.IsVisible = false;
                RaporlarStokToggle.IsVisible = false;
                RaporlarGelirGiderToggle.IsVisible = false;
            }
        }

        private void btnMenuRaporlarKasaRaporu_Clicked(object sender, EventArgs e)
        {

        }
        #endregion

        #region Raporlar/Banka
        private void btnMenuRaporlarBanka_Clicked(object sender, EventArgs e)
        {
            if (RaporlarBankaToggle.IsVisible)
            {
                RaporlarBankaToggle.IsVisible = false;
                openedTree = null;
                btnMenuRaporlarBanka.Text = "Banka ◀";
            }
            else
            {
                RaporlarBankaToggle.IsVisible = true;
                openedTree = "banka";
                btnMenuRaporlarBanka.Text = "Banka ▼";

                RaporlarCariToggle.IsVisible = false;
                RaporlarDigerToggle.IsVisible = false;
                RaporlarCekSenetToggle.IsVisible = false;
                //RaporlarBankaToggle.IsVisible = false;
                RaporlarKasaToggle.IsVisible = false;
                RaporlarSatisToggle.IsVisible = false;
                RaporlarTaksitToggle.IsVisible = false;
                RaporlarStokToggle.IsVisible = false;
                RaporlarGelirGiderToggle.IsVisible = false;
            }
        }

        private void btnMenuRaporlarBankaRaporu_Clicked(object sender, EventArgs e)
        {

        }
        #endregion

        #region Raporlar/Cek-Senet
        private void btnMenuRaporlarCekSenet_Clicked(object sender, EventArgs e)
        {
            if (RaporlarCekSenetToggle.IsVisible)
            {
                RaporlarCekSenetToggle.IsVisible = false;
                openedTree = null;
                btnMenuRaporlarCekSenet.Text = "Çek/Senet ◀";
            }
            else
            {
                RaporlarCekSenetToggle.IsVisible = true;
                openedTree = "cek-senet";
                btnMenuRaporlarCekSenet.Text = "Çek/Senet ▼";

                RaporlarCariToggle.IsVisible = false;
                RaporlarDigerToggle.IsVisible = false;
                //RaporlarCekSenetToggle.IsVisible = false;
                RaporlarBankaToggle.IsVisible = false;
                RaporlarKasaToggle.IsVisible = false;
                RaporlarSatisToggle.IsVisible = false;
                RaporlarTaksitToggle.IsVisible = false;
                RaporlarStokToggle.IsVisible = false;
                RaporlarGelirGiderToggle.IsVisible = false;
            }
        }

        private void btnMenuRaporlarCekSenetRaporu_Clicked(object sender, EventArgs e)
        {

        }
        #endregion

        #region Raporlar/Diger
        private void btnMenuRaporlarDiger_Clicked(object sender, EventArgs e)
        {
            if (RaporlarDigerToggle.IsVisible)
            {
                RaporlarDigerToggle.IsVisible = false;
                openedTree = null;
                btnMenuRaporlarDiger.Text = "Diğer ◀";
            }
            else
            {
                RaporlarDigerToggle.IsVisible = true;
                openedTree = "diger";
                btnMenuRaporlarDiger.Text = "Diğer ▼";

                RaporlarCariToggle.IsVisible = false;
                //RaporlarDigerToggle.IsVisible = false;
                RaporlarCekSenetToggle.IsVisible = false;
                RaporlarBankaToggle.IsVisible = false;
                RaporlarKasaToggle.IsVisible = false;
                RaporlarSatisToggle.IsVisible = false;
                RaporlarTaksitToggle.IsVisible = false;
                RaporlarStokToggle.IsVisible = false;
                RaporlarGelirGiderToggle.IsVisible = false;
            }
        }

        private void btnMenuRaporlarBankaHasaHaraketleri_Clicked(object sender, EventArgs e)
        {

        }
        #endregion

        #region Gun Sonu
        private void btnMenuRaporlarGunSonu_Clicked(object sender, EventArgs e)
        {

        }
        #endregion

        #region Kar Zarar Analizi
        private void btnMenuRaporlarKarZarar_Clicked(object sender, EventArgs e)
        {

        }
        #endregion

        #region Gelir-Gider
        private async void btnMenuRaporlarGelirGider_Clicked(object sender, EventArgs e)
        {
            if (RaporlarGelirGiderToggle.IsVisible)
            {
                RaporlarGelirGiderToggle.IsVisible = false;
                openedTree = null;
                btnMenuRaporlarGelirGider.Text = "Gelir Gider ◀";
            }
            else
            {
                RaporlarGelirGiderToggle.IsVisible = true;
                openedTree = "gelir-gider";
                btnMenuRaporlarGelirGider.Text = "Gelir Gider ▼";

                RaporlarCariToggle.IsVisible = false;
                RaporlarDigerToggle.IsVisible = false;
                RaporlarCekSenetToggle.IsVisible = false;
                RaporlarBankaToggle.IsVisible = false;
                RaporlarKasaToggle.IsVisible = false;
                RaporlarSatisToggle.IsVisible = false;
                RaporlarTaksitToggle.IsVisible = false;
                RaporlarStokToggle.IsVisible = false;
                //RaporlarGelirGiderToggle.IsVisible = false;
            }
        }

        private void btnMenuRaporlarGelirGiderBakiyeRapor_Clicked(object sender, EventArgs e)
        {

        }

        private void btnMenuRaporlarGelirGiderDetayliRapor_Clicked(object sender, EventArgs e)
        {

        }
        #endregion
        private async void btnMenuRaporlarTreeView_Clicked(object sender, EventArgs e)
        {
            if (RaporlarToggle.IsVisible)
            {
                RaporlarToggle.IsVisible = false;
                RaporlarCariToggle.IsVisible = false;
                RaporlarDigerToggle.IsVisible = false;
                RaporlarCekSenetToggle.IsVisible = false;
                RaporlarBankaToggle.IsVisible = false;
                RaporlarKasaToggle.IsVisible = false;
                RaporlarSatisToggle.IsVisible = false;
                RaporlarTaksitToggle.IsVisible = false;
                RaporlarStokToggle.IsVisible = false;
                RaporlarGelirGiderToggle.IsVisible = false;
                btnMenuRaporlarTreeView.Text = "Raporlar ◀";
                btnMenuRaporlarCari.Text = "Cari ◀";
                btnMenuRaporlarStok.Text = "Stok ◀";
                btnMenuRaporlarTaksit.Text = "Taksit ◀";
                btnMenuRaporlarSatis.Text = "Satış ◀";
                btnMenuRaporlarKasa.Text = "Kasa ◀";
                btnMenuRaporlarBanka.Text = "Banka ◀";
                btnMenuRaporlarCekSenet.Text = "Çek/Senet ◀";
                btnMenuRaporlarDiger.Text = "Diğer ◀";
                btnMenuRaporlarGelirGider.Text = "Gelir Gider ◀";
            }
            else
            {
                RaporlarToggle.IsVisible = true;
                btnMenuRaporlarTreeView.Text = "Raporlar ▼";
            }
        }

        [Obsolete]
        private async void btnGirisEkrani_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainMDPage(APIHelper.loginMod, "index", APIHelper.secilenlogindonemYil), false);
        }

        [Obsolete]
        private void btnSatisYap_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainMDPage(APIHelper.loginMod, "SatisYap", APIHelper.secilenlogindonemYil), false);
        }

        [Obsolete]
        private void btnCariHesaplar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainMDPage(APIHelper.loginMod, "CariHesaplar", APIHelper.secilenlogindonemYil), false);
        }
        #endregion
    }
}