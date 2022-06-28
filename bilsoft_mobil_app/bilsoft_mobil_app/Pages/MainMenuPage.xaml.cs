using bilsoft_mobil_app.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bilsoft_mobil_app.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPage : ContentPage
    {
        /* Not */
        /* menu iconları 32px
        /* menu altı iconları 20px
        /* menu alt altı iconları 16px
        /* Not */


        #region renk Bindleri
        public Color TextColor { get; set; } = Color.FromHex(AppThemeColors._textColor);
        public Color TextColorKoyu { get; set; } = Color.FromHex(AppThemeColors._textColorKoyu);
        public Color BorderColor { get; set; } = Color.FromHex(AppThemeColors._borderColor);
        public Color BackgroundColor { get; set; } = Color.FromHex(AppThemeColors._backgroundColor);
        public Color CardBackgroundColor { get; set; } = Color.FromHex(AppThemeColors._cardBackgroundColor);


        #endregion

        //cari, stok, taksit, satis, kasa, banka, cek-senet, diger, gelir-gider
        string openedTree;
        public MainMenuPage()
        {
            BindingContext = this;
            InitializeComponent();
        }
        #region Raporlar/Cari
        private void btnMenuRaporlarCari_Clicked(object sender, EventArgs e)
        {
            if (RaporlarCariToggle.IsVisible)
            {
                RaporlarCariToggle.IsVisible = false;
                openedTree = null;
            }
            else
            {
                RaporlarCariToggle.IsVisible = true;
                MainScrollView.ScrollToAsync(MainScrollView.ScrollX, 600, true);
                openedTree = "cari";
                
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
            }
            else
            {
                RaporlarStokToggle.IsVisible = true;
                MainScrollView.ScrollToAsync(MainScrollView.ScrollX, 1000, true);
                openedTree = "stok";

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
                MainScrollView.ScrollToAsync(MainScrollView.ScrollX, 1200, true);
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
            }
            else
            {
                openedTree = "taksit";
                RaporlarTaksitToggle.IsVisible = true;
                MainScrollView.ScrollToAsync(MainScrollView.ScrollX, 1500, true);

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
            }
            else
            {
                openedTree = "satis";
                RaporlarSatisToggle.IsVisible = true;
                MainScrollView.ScrollToAsync(MainScrollView.ScrollX, 2000, true);

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
            }
            else
            {
                openedTree = "kasa";
                RaporlarKasaToggle.IsVisible = true;
                MainScrollView.ScrollToAsync(MainScrollView.ScrollX, 2000, true);

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
            }
            else
            {
                RaporlarBankaToggle.IsVisible = true;
                openedTree = "banka";
                MainScrollView.ScrollToAsync(MainScrollView.ScrollX, 3000, true);

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
            }
            else
            {
                RaporlarCekSenetToggle.IsVisible = true;
                MainScrollView.ScrollToAsync(MainScrollView.ScrollX, 5000, true);
                openedTree = "cek-senet";

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
            }
            else
            {
                RaporlarDigerToggle.IsVisible = true;
                MainScrollView.ScrollToAsync(MainScrollView.ScrollX, 5000, true);
                openedTree = "diger";

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
        private void btnMenuRaporlarGelirGider_Clicked(object sender, EventArgs e)
        {
            if (RaporlarGelirGiderToggle.IsVisible)
            {
                RaporlarGelirGiderToggle.IsVisible = false;
                openedTree = null;
            }
            else
            {
                RaporlarGelirGiderToggle.IsVisible = true;
                MainScrollView.ScrollToAsync(MainScrollView.ScrollX, 5000, true);
                openedTree = "gelir-gider";

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
        private void btnMenuRaporlarTreeView_Clicked(object sender, EventArgs e)
        {
            if (RaporlarToggle.IsVisible)
            {
                RaporlarToggle.IsVisible = false;
            }
            else
            {
                RaporlarToggle.IsVisible = true;
                MainScrollView.ScrollToAsync(MainScrollView.ScrollX, 5000, true);
            }
        }

        private void MainScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            lblScrollTest.Text = "ScrollY: " + MainScrollView.ScrollY;
        }
    }
}