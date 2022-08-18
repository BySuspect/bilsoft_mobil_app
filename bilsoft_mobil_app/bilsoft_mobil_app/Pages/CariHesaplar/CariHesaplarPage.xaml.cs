using Android.App;
using bilsoft_mobil_app.Helper.API;
using bilsoft_mobil_app.Helper.App;
using bilsoft_mobil_app.Helper.JSONHelpers.RootCari;
using bilsoft_mobil_app.Helper.Veriler;
using bilsoft_mobil_app.Pages.CariHesaplar;
using bilsoft_mobil_app.Pages.MainView;
using bilsoft_mobil_app.Pages.popUplar;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using APIHelper = bilsoft_mobil_app.Helper.API.APIHelper;
using APIResponse = bilsoft_mobil_app.Helper.API.APIResponse;

namespace bilsoft_mobil_app.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CariHesaplarPage : ContentPage
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


        ObservableCollection<CariHesaplarPickerItems> _pickerlistItemsSource = new ObservableCollection<CariHesaplarPickerItems>();
        ObservableCollection<CariHesaplarListItems> _listItemsSource = new ObservableCollection<CariHesaplarListItems>();


        #region main
        public CariHesaplarPage()
        {
            popupResultHelper.cariGrupPopupListHelper.AddRange(new string[] { "Hepsi", "PERSONEL", "MÜŞTERİ", "TOPTANCI", "ALICI", "SATICI", "SATIŞ" });
            BindingContext = this;
            InitializeComponent();
            pickerCariListe.SelectedIndex = 0;
            //pickerCariListe.SelectedItem = "Hepsi";
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await GetAllData();
        }
        public IEnumerable pickerItemsSource
        {
            get
            {
                return popupResultHelper.cariGrupPopupListHelper;
            }
            set
            {
                popupResultHelper.cariGrupPopupListHelper = value as List<string>;
                pickerCariListe.ItemsSource = value as List<string>;
            }
        }

        //Kullanım dışı
        //void pickerListeRefesh()
        //{
        //    popupResultHelper.cariGrupPopupListHelper.Clear();
        //    popupResultHelper.cariGrupPopupListHelper.Add("Hepsi");
        //    foreach (var item in popupResultHelper.cariGrupPopupListHelper)
        //    {
        //        popupResultHelper.cariGrupPopupListHelper.Add(item);
        //    }
        //    pickerCariListe.ItemsSource = popupResultHelper.cariGrupPopupListHelper;
        //    pickerCariListe.SelectedIndex = 0;
        //}
        private async void CariEditButton_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var test = btn.AutomationId;

            var _list = new List<CariHesaplarListItems>();
            foreach (var item in _listItemsSource)
            {
                if (item.btnId == btn.AutomationId)
                {
                    _list.Add(item);
                    break;
                }
            }

            Loodinglayout.IsVisible = true;
            LoodingActivity.IsRunning = true;
            await Navigation.PushAsync(new CariEklePage("Edit", _list), true);
            //Popup popup = new CariEklePopup("Yeni", null);
            //await App.Current.MainPage.Navigation.ShowPopupAsync(popup);
            GetAllData();
            Loodinglayout.IsVisible = false;
            LoodingActivity.IsRunning = false;
        }
        private void CariAcButton_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var test = btn.AutomationId;
        }
        private async void btnYeniCari_Clicked(object sender, EventArgs e)
        {
            Loodinglayout.IsVisible = true;
            LoodingActivity.IsRunning = true;
            await Navigation.PushAsync(new CariEklePage("Yeni", null), true);
            //Popup popup = new CariEklePopup("Yeni", null);
            //await App.Current.MainPage.Navigation.ShowPopupAsync(popup);
            GetAllData();
            Loodinglayout.IsVisible = false;
            LoodingActivity.IsRunning = false;
        }

        private async void btnGruplar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Popup popup = new CariGruplarPopup();
                await App.Current.MainPage.Navigation.ShowPopupAsync(popup);
                GetAllData();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void pickerCariListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (pickerCariListe.SelectedItem)
            {
                case "Hepsi":
                    CariListView.ItemsSource = _listItemsSource;
                    break;

                default:
                    if (pickerCariListe.SelectedItem != null)
                        CariListView.ItemsSource = new ObservableCollection<CariHesaplarListItems>(_listItemsSource.Where(x => x.grup.ToLower().StartsWith(pickerCariListe.SelectedItem.ToString().ToLower())).ToList());
                    break;
            }
        }

        private async void btnMahsupFisi_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CariHesapMahsupFisiPage(), true);
        }

        private async void btnRaporlar_Clicked(object sender, EventArgs e)
        {
            var res = await DisplayActionSheet("Raporlar", "iptal", "iptal", new string[] { "Cari Ekstre", "Cari İşlem Raporu", "Cari Rapor", "BA-BS Raporu", "Cari Mutabakat Raporu" });
            switch (res)
            {
                case "Cari Ekstre":
                    break;

                case "Cari İşlem Raporu":
                    break;

                case "Cari Rapor":
                    break;

                case "BA-BS Raporu":
                    break;

                case "Cari Mutabakat Raporu":
                    break;

                default:
                    break;
            }
        }
        private async Task GetAllData()
        {
            try
            {
                Loodinglayout.IsVisible = true;
                LoodingActivity.IsRunning = true;

                RestClient client;
                RestRequest request;


                _pickerlistItemsSource.Clear();
                popupResultHelper.cariGrupPopupListHelper.Clear();
                popupResultHelper.cariGrupPopupListHelper.Add("Hepsi");

                CariListView.ItemsSource = null;
                _listItemsSource.Clear();

                #region CariAdresler //Kapalı
                //client = new RestClient(APIHelper.url + APIHelper.CariAdresApi + apiTypes.getall);
                //request = new RestRequest();
                //request.AddHeader("Authorization", APIHelper.loginToken);
                //request.AddHeader("Content-Type", "application/json");
                //var resCariAdresler = await client.ExecuteAsync(request, Method.Post);
                //var dataCariAdresler = JsonConvert.DeserializeObject<RootCariAdressler>(resCariAdresler.Content);

                //Yanlis listeleme
                //for (int i = 0; i < dataCariAdresler.data.Count; i++)
                //{
                //    _listItemsSource.Add(new CariHesaplarListItems
                //    {
                //        btnID = "btn" + i,
                //        yetkili = dataCariAdresler.data[i].yetkili,
                //        cariId = dataCariAdresler.data[i].cariId,
                //        id = dataCariAdresler.data[i].id,
                //        cep = dataCariAdresler.data[i].cep,
                //        tel = dataCariAdresler.data[i].tel,
                //        ulke = dataCariAdresler.data[i].ulke,
                //        il = dataCariAdresler.data[i].il,
                //        ilce = dataCariAdresler.data[i].ilce,
                //        sevkAdres = dataCariAdresler.data[i].sevkAdres,
                //        cariKart = dataCariAdresler.data[i].cariKart,
                //        mail = dataCariAdresler.data[i].mail,
                //        postaKodu = dataCariAdresler.data[i].postaKodu,
                //        Bakiye = "---------₺",
                //        CariAd = "---------",
                //        SIRA = i + 1
                //    });
                //}

                #endregion

                #region CariBanka //Kapalı
                //client = new RestClient(APIHelper.url + APIHelper.CariBankaApi + apiTypes.getall);
                //request = new RestRequest();
                //request.AddHeader("Authorization", APIHelper.loginToken);
                //request.AddHeader("Content-Type", "application/json");
                //var resCariBanka = await client.ExecuteAsync(request, Method.Post);
                //var dataCariBanka = JsonConvert.DeserializeObject<RootCariBanka>(resCariBanka.Content);
                #endregion

                #region CariGrup
                client = new RestClient(APIHelper.url + APIHelper.CariApiler.CariGrupApi + APIHelper.apiTypes.getall);
                request = new RestRequest();
                request.AddHeader("Authorization", APIHelper.loginToken);
                request.AddHeader("Content-Type", "application/json");
                var resCariGrup = await client.ExecuteAsync(request, Method.Post);
                var dataCariGrup = JsonConvert.DeserializeObject<RootCariGrup>(resCariGrup.Content);

                for (int i = 0; i < dataCariGrup.data.Count(); i++)
                {
                    _pickerlistItemsSource.Add(new CariHesaplarPickerItems
                    {
                        grupAd = dataCariGrup.data[i].grup,
                        ID = dataCariGrup.data[i].id,
                        kullaniciAd = dataCariGrup.data[i].kullaniciAdi,
                        subeAd = dataCariGrup.data[i].subeAdi
                    });
                }

                _pickerlistItemsSource = new ObservableCollection<CariHesaplarPickerItems>(_pickerlistItemsSource.OrderBy(i => i.ID));

                foreach (var item in _pickerlistItemsSource)
                {
                    popupResultHelper.cariGrupPopupListHelper.Add(item.grupAd);
                }

                #endregion

                #region CariIsl //Apide kapalı
                //client = new RestClient(APIHelper.url + APIHelper.CariIslApi + apiTypes.getall);
                //request = new RestRequest();
                //request.AddHeader("Authorization", APIHelper.loginToken);
                //request.AddHeader("Content-Type", "application/json");
                //var resCariIsl = await client.ExecuteAsync(request, Method.Post);
                //var dataCariIsl = JsonConvert.DeserializeObject<RootCariIsl>(resCariIsl.Content);
                #endregion

                #region CariKartlar
                client = new RestClient(APIHelper.url + APIHelper.CariApiler.CariKartApi + APIHelper.apiTypes.getall);
                request = new RestRequest();
                request.AddHeader("Authorization", APIHelper.loginToken);
                request.AddHeader("Content-Type", "application/json");
                var resCariKartlar = await client.ExecuteAsync(request, Method.Post);
                var dataCariKartlar = JsonConvert.DeserializeObject<RootCariKartlar>(resCariKartlar.Content);

                string test = "";

                for (int i = 0; i < dataCariKartlar.data.Count; i++)
                {
                    if (dataCariKartlar.data[i].grup == null) dataCariKartlar.data[i].grup = dataCariKartlar.data[i].yetkili + "=Null";
                    test += dataCariKartlar.data[i].grup + "\n";
                    _listItemsSource.Add(new CariHesaplarListItems
                    {
                        id = dataCariKartlar.data[i].id,
                        bakiye = "#₺",
                        btnId = "btn&" + i,
                        SIRA = i + 1,
                        adres = dataCariKartlar.data[i].adres,
                        cariad = dataCariKartlar.data[i].faturaUnvan,
                        cariKod = dataCariKartlar.data[i].cariKod,
                        cep = dataCariKartlar.data[i].cep,
                        faturaAdres = dataCariKartlar.data[i].faturaAdres,
                        faturaIl = dataCariKartlar.data[i].faturaIl,
                        faturaIlce = dataCariKartlar.data[i].faturaIlce,
                        faturaUnvan = dataCariKartlar.data[i].faturaUnvan,
                        fax = dataCariKartlar.data[i].fax,
                        grup = dataCariKartlar.data[i].grup,
                        mail = dataCariKartlar.data[i].mail,
                        kullaniciAdi = dataCariKartlar.data[i].kullaniciAdi,
                        postakodu = dataCariKartlar.data[i].postakodu,
                        riskIslemi = dataCariKartlar.data[i].riskIslemi,
                        riskLimiti = dataCariKartlar.data[i].riskLimiti,
                        sevkAdresi = dataCariKartlar.data[i].sevkAdresi,
                        subeAdi = dataCariKartlar.data[i].subeAdi,
                        tel = dataCariKartlar.data[i].tel,
                        ticaretsicilno = dataCariKartlar.data[i].ticaretsicilno,
                        vergiDairesi = dataCariKartlar.data[i].vergiDairesi,
                        vergiNo = dataCariKartlar.data[i].vergiNo,
                        webAdresi = dataCariKartlar.data[i].webAdresi,
                        yetkili = dataCariKartlar.data[i].yetkili,
                        varsayilanVadeGunu = dataCariKartlar.data[i].varsayilanVadeGunu,
                        faturaUlke = dataCariKartlar.data[i].faturaUlke,
                    });
                }

                ///test içindi
                //await DisplayAlert("", test, "Ok");
                #endregion


                //List<object> test = new List<object>();
                //test.Add(dataCariKartlar);
                //test.Add(dataCariAdresler);
                //test.Add(dataCariBanka);
                //test.Add(dataCariGrup);

                /**/

                pickerItemsSource = new List<string>(popupResultHelper.cariGrupPopupListHelper);
                pickerCariListe.SelectedIndex = 0;
                CariListView.ItemsSource = _listItemsSource;

                Loodinglayout.IsVisible = false;
                LoodingActivity.IsRunning = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace + "\n" + ex.InnerException + "\n" + ex.Data);
                Console.WriteLine("");
                Console.WriteLine("");

                throw new Exception(ex.Message);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MainPage();
            return true;
        }

        #endregion

        #region Test Area
        private async void Button_Clicked(object sender, EventArgs e)
        {

        }
        #endregion

    }
}