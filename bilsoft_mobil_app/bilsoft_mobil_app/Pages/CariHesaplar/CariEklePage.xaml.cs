using bilsoft_mobil_app.Helper.API;
using bilsoft_mobil_app.Helper.App;
using bilsoft_mobil_app.Helper.JSONHelpers.RootCari;
using bilsoft_mobil_app.Pages.CariHesaplar;
using bilsoft_mobil_app.Pages.popUplar.CariHesaplar;
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

namespace bilsoft_mobil_app.Pages.CariHesaplar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CariEklePage : ContentPage
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

        /* tüm Entry adları */
        /* 
         * entryAd
         * pickerGrup
         * entryYetkili
         * numRiskLimit
         * numVadeTarih
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
         * entrySevkAdres
         * entryCariKod
         * 
         */
        ObservableCollection<CariEkleVeriler> _listItemsSource = new ObservableCollection<CariEkleVeriler>();
        List<string> cbItems = new List<string>();
        public CariEklePage(string mod, object _list)
        {
            //Test Verileri
            APIHelper.loginToken = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjI4OCIsInVuaXF1ZV9uYW1lIjoiMDczOTYwODgtNGU2Mi00OGMzLWEwYzAtYzg0Y2Y3NWQwZTI0IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6ImRlbW8iLCJuYmYiOjE2NTk0MjI1MzYsImV4cCI6MTY1OTQ2NTczNSwiaXNzIjoid3d3LmJpbHNvZnQuY29tIiwiYXVkIjoid3d3LmJpbHNvZnQuY29tIn0.SdkQWZWQQ5LAQuLmCWMqVv8r4B4DwP_RV2jpUawnSME";
            APIHelper.kullaniciAdi = "demo";
            APIHelper.subeAd = "merkez";
            //Test Verileri End

            InitializeComponent();
            BindingContext = this;
            MainScrollView.ScrollToAsync(0, 0, false);
            getGruplar();
            _listItemsSource.Clear();
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
            var client = new RestClient(APIHelper.url + APIHelper.CariGrupApi + apiTypes.getall);
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

            RestClient client = new RestClient(APIHelper.url + APIHelper.CariKartApi + apiTypes.add);
            RestRequest request = new RestRequest();
            request.AddHeader("Authorization", APIHelper.loginToken);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(json);
            var resCariGrup = await client.ExecuteAsync(request, Method.Post);
            var dataCariGrup = JsonConvert.DeserializeObject<APIResponse>(resCariGrup.Content);
        }
        private void ComboBox_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            //pickerGrup.Text = pickerGrup.SelectedItem.ToString();
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
            //Şuanda Devre Dışı 
            if (!String.IsNullOrEmpty(e.NewTextValue))
                pickerGrup.ItemsSource = cbItems.Where(x => x.ToLower().StartsWith(e.NewTextValue.ToLower())).OrderBy(x => x).ToList();
            else
                pickerGrup.ItemsSource = cbItems;
        }
        private void btnAdressIptal_Clicked(object sender, EventArgs e)
        {
            //Şuanda Devre Dışı 
            sevkAdresEkleView.IsVisible = false;
        }

        private void btnAdressSec_Clicked(object sender, EventArgs e)
        {
            //Şuanda Devre Dışı 
        }

        private void btnKaydet_Clicked(object sender, EventArgs e)
        {


            resetPage();
        }

        public string RiskIslemValue
        {
            get;
            set;
        }
        private void btnSil_Clicked(object sender, EventArgs e)
        {
            resetPage();
        }
        void resetPage()
        {
            //entryAd.Text = "";
            //pickerGrup.SelectedIndex = -1;
            //entryYetkili.Text = "";
            //numRiskLimit.Value = 0;
            //numVadeTarih.Value = 1;
            //entryTel.Text = "";
            //entryCepTel.Text = "";
            //entryFax.Text = "";
            //entryMail.Text = "";
            //entryWeb.Text = "";
            //entryPostaKod.Text = "";
            //entryVergiDairesi.Text = "";
            //entryVergiNo.Text = "";
            //entrySicil.Text = "";
            //entryUlke.Text = "";
            //entryIl.Text = "";
            //entryIlce.Text = "";
            //entryAdres.Text = "";
            //entrySevkAdres.Text = "";
            //entryCariKod.Text = "";

            /* Test */

            RiskIslemValue = "yaptırma";
            entryAd.Text = "Test";
            pickerGrup.SelectedIndex = 2;
            entryYetkili.Text = "Test";
            numRiskLimit.Value = 24;
            numVadeTarih.Value = 24;
            entryTel.Text = "Test";
            entryCepTel.Text = "Test";
            entryFax.Text = "Test";
            entryMail.Text = "Test";
            entryWeb.Text = "Test";
            entryPostaKod.Text = "Test";
            entryVergiDairesi.Text = "Test";
            entryVergiNo.Text = "Test";
            entrySicil.Text = "Test";
            entryUlke.Text = "Test";
            entryIl.Text = "Test";
            entryIlce.Text = "Test";
            entryAdres.Text = "Test";
            entrySevkAdres.Text = "Test";
            entryCariKod.Text = "Test";
        }

        private void btnTest_Clicked(object sender, EventArgs e)
        {

        }
    }
}