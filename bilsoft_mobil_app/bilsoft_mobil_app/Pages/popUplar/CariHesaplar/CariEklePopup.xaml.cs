using bilsoft_mobil_app.CustomItems;
using bilsoft_mobil_app.Helper.App;
using bilsoft_mobil_app.Pages.popUplar.CariHesaplar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bilsoft_mobil_app.Pages.popUplar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CariEklePopup : Popup
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

        /* tüm Entry adları
         * entryAd
         * cbGrup
         * entryYetkili
         * entryRiskLimit
         * entryVadeTarih
         * entryTel
         * entryCepTel
         * entryFax
         * entryMail
         * entryWeb
         * entryPostaKod
         * entryVergiDairesi
         * entryVergiNo
         * entrySicil
         * entryUlke
         * entryIl
         * entryIlce
         * entryAdres
         * entryCariKod
         */
        ObservableCollection<SevkAdresiVeriler> _listItemsSource = new ObservableCollection<SevkAdresiVeriler>();
        public CariEklePopup(string mod, object list)
        {
            InitializeComponent();
            BindingContext = this;
            MainScrollView.ScrollToAsync(0, 0, false);
            cbGrup.BindingContext = new cbGrupViewModel();
        }
        private void ComboBox_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            cbGrup.Text = cbGrup.SelectedItem.ToString();
        }

        private void btnAddSevkAdrs_Clicked(object sender, EventArgs e)
        {
            sevkAdresEkleScrollView.IsVisible = true;
        }

        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            entryAd.Unfocus();
            cbGrup.Unfocus();
            entryYetkili.Unfocus();
            numRiskLimit.Unfocus();
            numVadeTarih.Unfocus();
            entryTel.Unfocus();
            entryCepTel.Unfocus();
            entryFax.Unfocus();
            entryMail.Unfocus();
            entryWeb.Unfocus();
            entryPostaKod.Unfocus();
            entryVergiDairesi.Unfocus();
            entryVergiNo.Unfocus();
            entrySicil.Unfocus();
            entryUlke.Unfocus();
            entryIl.Unfocus();
            entryIlce.Unfocus();
            entryAdres.Unfocus();
            entryCariKod.Unfocus();
        }
        cbGrupViewModel cbGrupViewModel = new cbGrupViewModel();
        private void cbGrup_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.NewTextValue))
                cbGrup.ItemsSource = cbGrupViewModel.ItemsSource.Where(x => x.ToLower().StartsWith(e.NewTextValue.ToLower())).OrderBy(x => x).ToList();
            else
                cbGrup.ItemsSource = cbGrupViewModel.ItemsSource;
        }
        private void btnAdressIptal_Clicked(object sender, EventArgs e)
        {
            sevkAdresEkleScrollView.IsVisible = false;
        }

        private void btnAdressSec_Clicked(object sender, EventArgs e)
        {

        }
    }
    public class cbGrupViewModel
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
        public List<string> ItemsSource { get; set; }
        public cbGrupViewModel()
        {
            ItemsSource = new List<string>()
            {
                "Personel",
                "Müşteri",
                "Toptancı",
                "Alıcı",
                "Satıcı",
                "Satış"
            };
        }
    }
}