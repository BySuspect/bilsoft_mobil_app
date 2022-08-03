using bilsoft_mobil_app.Helper.API;
using bilsoft_mobil_app.Helper.App;
using bilsoft_mobil_app.Helper.JSONHelpers.RootCari;
using bilsoft_mobil_app.Pages.CariHesaplar;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
         * pickerGrup
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
        ObservableCollection<CariEkleVeriler> _listItemsSource = new ObservableCollection<CariEkleVeriler>();
        List<string> cbItems = new List<string>();
        public CariEklePopup(string mod, object _list)
        {
            InitializeComponent();
            BindingContext = this;
            MainScrollView.ScrollToAsync(0, 0, false);
            getGruplar();
            if (mod == "Edit")
            {
                btnAddSevkAdrs.IsVisible = false;
                foreach (var item in _list as List<CariHesaplarListItems>)
                {
                    _listItemsSource.Add(new CariEkleVeriler
                    {
                        id = item.id,
                        faturaUnvan = item.cariad,
                        adres = item.adres,
                        cariKod = item.cariKod,
                        cep = item.cep,
                        faturaAdres = item.faturaAdres,
                        faturaIl = item.faturaIl,
                        faturaIlce = item.faturaIlce,
                        fax = item.fax,
                        grup = item.grup,
                        kullaniciAdi = item.kullaniciAdi,
                        mail = item.mail,
                        postakodu = item.postakodu,
                        riskIslemi = item.riskIslemi,
                        riskLimiti = item.riskLimiti,
                        sevkAdresi = item.sevkAdresi,
                        subeAdi = item.subeAdi,
                        tel = item.tel,
                        ticaretsicilno = item.ticaretsicilno,
                        vergiDairesi = item.vergiDairesi,
                        vergiNo = item.vergiNo,
                        webAdresi = item.webAdresi,
                        yetkili = item.yetkili,
                        aciklama = "",
                        cariaciklama = "",
                        cariN11Id = null,
                        faturaUlke = null,
                        personelMi = 0,
                        resimYolu = null,
                        seciliPketiketi = null,
                        varsayilanKasa = "",
                        varsayilanVadeGunu = 5,
                    });
                }
                //EditMode();
            }
        }
        async void getGruplar()
        {
            var client = new RestClient(APIHelper.url + APIHelper.CariApiler.CariGrupApi + APIHelper.apiTypes.getall);
            var request = new RestRequest();
            request.AddHeader("Authorization", APIHelper.loginToken);
            request.AddHeader("Content-Type", "application/json");
            var resCariGrup = await client.ExecuteAsync(request, Method.Post);
            var dataCariGrup = JsonConvert.DeserializeObject<RootCariGrup>(resCariGrup.Content);
            cbItems.Clear();
            foreach (var item in dataCariGrup.data)
            {
                cbItems.Add(item.grup);
            }
            pickerGrup.ItemsSource = cbItems;
        }
        async Task EditMode()
        {
            _listItemsSource[0].yetkili = "aaaaaaaaaaaaaaaa";
            _listItemsSource[0].faturaUnvan = "TESTEST";
            _listItemsSource[0].id = 0;
            var json = JsonConvert.SerializeObject(_listItemsSource[0]).ToString().Trim(new char[] { '[', ']' });

            RestClient client = new RestClient(APIHelper.url + APIHelper.CariApiler.CariKartApi + APIHelper.apiTypes.add);
            RestRequest request = new RestRequest();
            request.AddHeader("Authorization", APIHelper.loginToken);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(json);
            var resCariGrup = await client.ExecuteAsync(request, Method.Post);
            var dataCariGrup = JsonConvert.DeserializeObject<APIResponse>(resCariGrup.Content);
        }
        private void ComboBox_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            pickerGrup.Text = pickerGrup.SelectedItem.ToString();
        }

        private void btnAddSevkAdrs_Clicked(object sender, EventArgs e)
        {
            sevkAdresEkleView.IsVisible = true;
        }

        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            entryAd.Unfocus();
            pickerGrup.Unfocus();
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
        private void pickerGrup_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.NewTextValue))
                pickerGrup.ItemsSource = cbItems.Where(x => x.ToLower().StartsWith(e.NewTextValue.ToLower())).OrderBy(x => x).ToList();
            else
                pickerGrup.ItemsSource = cbItems;
        }
        private void btnAdressIptal_Clicked(object sender, EventArgs e)
        {
            sevkAdresEkleView.IsVisible = false;
        }

        private void btnAdressSec_Clicked(object sender, EventArgs e)
        {

        }
    }
}