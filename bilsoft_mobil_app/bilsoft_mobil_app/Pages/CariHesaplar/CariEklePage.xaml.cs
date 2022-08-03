using bilsoft_mobil_app.Helper.API;
using bilsoft_mobil_app.Helper.App;
using bilsoft_mobil_app.Helper.JSONHelpers.RootCari;
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

        /* tüm Entry adları
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
        int _id = 0;
        string _mod;
        public CariEklePage(string mod, object _list)
        {
            ////Test Verileri
            //APIHelper.loginToken = "--";
            //APIHelper.kullaniciAdi = "demo";
            //APIHelper.subeAd = "merkez";
            ////Test Verileri End


            InitializeComponent();
            BindingContext = this;
            Loodinglayout.IsVisible = true;
            LoodingActivity.IsRunning = true;
            MainScrollView.ScrollToAsync(0, 0, false);
            getGruplar();
            _mod = mod;

            _listItemsSource.Clear();
            if (mod == "Edit")
            {
                EditMode(_list);
            }
            else
                resetPage();
            Loodinglayout.IsVisible = false;
            LoodingActivity.IsRunning = false;
        }
        async Task getGruplar()
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
        async Task EditMode(object _list)
        {
            this.Title = "Düzenleme";
            lblTitle.Text = "Düzenle";
            //btnAddSevkAdrs.IsVisible = false;
            await getGruplar();
            foreach (var item in _list as List<CariHesaplarListItems>)
            {
                _id = item.id;
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
                    faturaUlke = item.faturaUlke,
                    personelMi = 0,
                    resimYolu = null,
                    seciliPketiketi = null,
                    varsayilanKasa = "",
                    varsayilanVadeGunu = item.varsayilanVadeGunu,
                });
                entryAd.Text = item.faturaUnvan;
                pickerGrup.SelectedIndex = cbItems.IndexOf(item.grup);
                entryYetkili.Text = item.yetkili;
                numRiskLimit.Value = Convert.ToInt16(item.riskLimiti);
                numVadeTarih.Value = item.varsayilanVadeGunu;
                entryTel.Text = item.tel;
                entryCepTel.Text = item.cep;
                entryFax.Text = item.fax;
                entryMail.Text = item.mail;
                entryWeb.Text = item.webAdresi;
                entryPostaKod.Text = item.postakodu;
                entryVergiDairesi.Text = item.vergiDairesi;
                entryVergiNo.Text = item.vergiNo;
                entrySicil.Text = item.ticaretsicilno;
                entryUlke.Text = item.faturaUlke;
                entryIl.Text = item.faturaIl;
                entryIlce.Text = item.faturaIlce;
                entryAdres.Text = item.adres;
                entrySevkAdres.Text = item.faturaAdres;
                entryCariKod.Text = item.cariKod;
                switch (item.riskIslemi)
                {
                    case "yaptır":
                        _rbYaptir.IsChecked = true;
                        break;
                    case "yaptırma":
                        _rbYaptirma.IsChecked = true;
                        break;
                    case "onayal":
                        _rbOnayAl.IsChecked = true;
                        break;
                }
                RiskIslemValue = item.riskIslemi;
            }
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

        private async void btnKaydet_Clicked(object sender, EventArgs e)
        {
            Loodinglayout.IsVisible = true;
            LoodingActivity.IsRunning = true;
            if (pickerGrup.SelectedItem == null) pickerGrup.SelectedIndex = 0;

            _listItemsSource.Clear();
            _listItemsSource.Add(new CariEkleVeriler
            {
                id = _id,
                faturaUnvan = entryAd.Text,
                adres = entryAdres.Text,
                cariKod = entryCariKod.Text,
                cep = entryCepTel.Text,
                faturaAdres = entryAdres.Text,
                faturaIl = entryIl.Text,
                faturaIlce = entryIlce.Text,
                fax = entryFax.Text,
                grup = pickerGrup.SelectedItem.ToString(),
                kullaniciAdi = APIHelper.kullaniciAdi,
                mail = entryMail.Text,
                postakodu = entryPostaKod.Text,
                riskIslemi = RiskIslemValue,
                riskLimiti = numRiskLimit.Value.ToString(),
                varsayilanVadeGunu = Convert.ToInt16(numVadeTarih.Value),
                sevkAdresi = entrySevkAdres.Text,
                subeAdi = APIHelper.subeAd,
                tel = entryTel.Text,
                ticaretsicilno = entrySicil.Text,
                vergiDairesi = entryVergiDairesi.Text,
                vergiNo = entryVergiNo.Text,
                webAdresi = entryWeb.Text,
                yetkili = entryYetkili.Text,
                faturaUlke = entryUlke.Text,
                aciklama = "",
                cariaciklama = "",
                cariN11Id = null,
                personelMi = 0,
                resimYolu = null,
                seciliPketiketi = null,
                varsayilanKasa = "",
            });

            var json = JsonConvert.SerializeObject(_listItemsSource[0]).ToString().Trim(new char[] { '[', ']' });

            RestClient client;
            if (_mod == "Edit") client = new RestClient(APIHelper.url + APIHelper.CariApiler.CariKartApi + APIHelper.apiTypes.update);
            else client = new RestClient(APIHelper.url + APIHelper.CariApiler.CariKartApi + APIHelper.apiTypes.add);
            RestRequest request = new RestRequest();
            request.AddHeader("Authorization", APIHelper.loginToken);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(json);

            RestResponse resCariGrup;
            if (_mod == "Edit") resCariGrup = await client.ExecuteAsync(request, Method.Put);
            else resCariGrup = await client.ExecuteAsync(request, Method.Post);
            var dataCariGrup = JsonConvert.DeserializeObject<APIResponse>(resCariGrup.Content);

            if (dataCariGrup.success)
            {
                if (_mod == "Edit") DisplayAlert("", "Başarıyla Güncellendi.", "Kapat");
                else DisplayAlert("", "Başarıyla eklendi.", "Kapat");
                resetPage();
                await Navigation.PopAsync();
            }
            else await DisplayAlert("Hata!", "Bir Hata Oluştu!\nHata Mesajı:\n" + dataCariGrup.message, "Tamam");
            Loodinglayout.IsVisible = false;
            LoodingActivity.IsRunning = false;
        }

        public string RiskIslemValue
        {
            get;
            set;
        }
        private async void btnSil_Clicked(object sender, EventArgs e)
        {
            if (_mod == "Edit")
            {
                Loodinglayout.IsVisible = true;
                LoodingActivity.IsRunning = true;

                var json = JsonConvert.SerializeObject(_listItemsSource[0]).ToString().Trim(new char[] { '[', ']' });

                RestClient client = new RestClient(APIHelper.url + APIHelper.CariApiler.CariKartApi + APIHelper.apiTypes.delete);
                RestRequest request = new RestRequest();
                request.AddHeader("Authorization", APIHelper.loginToken);
                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(json);

                RestResponse resCariGrup = await client.ExecuteAsync(request, Method.Post);
                var dataCariGrup = JsonConvert.DeserializeObject<APIResponse>(resCariGrup.Content);

                if (dataCariGrup.success)
                {
                    DisplayAlert("", "Başarıyla Silindi.", "Kapat");
                    resetPage();
                    await Navigation.PopAsync();
                }
                else await DisplayAlert("Hata!", "Bir Hata Oluştu!\nHata Mesajı:\n" + dataCariGrup.message, "Tamam");
                Loodinglayout.IsVisible = false;
                LoodingActivity.IsRunning = false;
            }
            else
                resetPage();
        }
        void resetPage()
        {
            entryAd.Text = "";
            pickerGrup.SelectedIndex = -1;
            entryYetkili.Text = "";
            numRiskLimit.Value = 0;
            numVadeTarih.Value = 1;
            _rbYaptir.IsChecked = true;
            RiskIslemValue = "yaptır";
            entryTel.Text = "";
            entryCepTel.Text = "";
            entryFax.Text = "";
            entryMail.Text = "";
            entryWeb.Text = "";
            entryPostaKod.Text = "";
            entryVergiDairesi.Text = "";
            entryVergiNo.Text = "";
            entrySicil.Text = "";
            entryUlke.Text = "";
            entryIl.Text = "";
            entryIlce.Text = "";
            entryAdres.Text = "";
            entrySevkAdres.Text = "";
            entryCariKod.Text = "";
        }

        private void btnTest_Clicked(object sender, EventArgs e)
        {
            /* Test */
            RiskIslemValue = "yaptırma";
            _rbYaptirma.IsChecked = true;
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
            entryVergiNo.Text = "215215";
            entrySicil.Text = "Test";
            entryUlke.Text = "Test";
            entryIl.Text = "Test";
            entryIlce.Text = "Test";
            entryAdres.Text = "Test";
            entrySevkAdres.Text = "Test";
            entryCariKod.Text = "Test";
        }
    }
}