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

        //cari-stok
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
                openedTree = "";
            }
            else
            {
                RaporlarCariToggle.IsVisible = true;
                MainScrollView.ScrollToAsync(MainScrollView.ScrollX, 600, true);
                openedTree = "cari";
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
                openedTree = "";
            }
            else
            {
                RaporlarStokToggle.IsVisible = true;
                MainScrollView.ScrollToAsync(MainScrollView.ScrollX, 1000, true);
                openedTree = "stok";
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
                RaporlarTaksitToggle.IsVisible = false;
            }
            else
            {
                RaporlarTaksitToggle.IsVisible = true;
                MainScrollView.ScrollToAsync(MainScrollView.ScrollX, 1500, true);
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
                RaporlarSatisToggle.IsVisible = false;
            }
            else
            {
                RaporlarSatisToggle.IsVisible = true;
                MainScrollView.ScrollToAsync(MainScrollView.ScrollX, 2000, true);
            }
        }

        private void btnMenuRaporlarSatisRaporu_Clicked(object sender, EventArgs e)
        {

        }

        private void btnMenuRaporlarSatisGrafigi_Clicked(object sender, EventArgs e)
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
                MainScrollView.ScrollToAsync(MainScrollView.ScrollX, 300, true);
            }
        }

    }
}