using bilsoft_mobil_app.Helper.API;
using bilsoft_mobil_app.Helper.App;
using bilsoft_mobil_app.Helper.JSONHelpers.RootAjanda;
using bilsoft_mobil_app.Helper.JSONHelpers.User;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bilsoft_mobil_app.Pages.Ajanda
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjandaPage : ContentPage
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

        ObservableCollection<AjandaVeriler> _listItems = new ObservableCollection<AjandaVeriler>();
        List<UserVeriler> _userList = new List<UserVeriler>();
        List<string> _userNameList = new List<string>();
        //List<RootProgramAyarListe> _programAyarList = new List<RootProgramAyarListe>();
        public AjandaPage()
        {
            //Test Verileri
            APIHelper.loginToken = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjI4OCIsInVuaXF1ZV9uYW1lIjoiMTk3MGZlMzMtOTUwMC00ZDllLThlY2UtYzI5ZWIxMWQwMDQ3IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6ImRlbW8iLCJuYmYiOjE2NTk1OTY1MjcsImV4cCI6MTY1OTYzOTcyNSwiaXNzIjoid3d3LmJpbHNvZnQuY29tIiwiYXVkIjoid3d3LmJpbHNvZnQuY29tIn0.uPmIp58bDdng59BFyaQxbT3EruVtYGfgTxj5a832V2A";
            APIHelper.kullaniciAdi = "demo";
            APIHelper.subeAd = "merkez";
            //Test Verileri End

            InitializeComponent();
            BindingContext = this;

            pickerBildirimler.ItemsSource = new List<string>() { "Tüm Bildirimler", "Tamamlanan Bildirimler", "Tamamlanmayan Bildirimler" };
            pickerBildirimler.SelectedIndex = 0;

            dpickerBaslangic.Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, DateTime.Now.Day);
            dpickerBitis.Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await getAllData();
        }
        async Task getAllData()
        {
            #region Ajanda
            var clientAjanda = new RestClient(APIHelper.url + APIHelper.AjandaApiler.AjandaApi + APIHelper.apiTypes.getall);
            var requestAjanda = new RestRequest();
            requestAjanda.AddHeader("Authorization", APIHelper.loginToken);
            requestAjanda.AddHeader("Content-Type", "application/json");
            var resAjanda = await clientAjanda.ExecuteAsync(requestAjanda, Method.Post);
            var dataAjanda = JsonConvert.DeserializeObject<RootAjanda>(resAjanda.Content);

            _listItems.Clear();

            foreach (var item in dataAjanda.data)
            {
                _listItems.Add(new AjandaVeriler
                {
                    btnid = "btn" + item.id,
                    aciklama = item.aciklama,
                    adSoyad = item.adSoyad,
                    ajandaDosya = item.ajandaDosya,
                    cep = item.cep,
                    firma = item.firma,
                    id = item.id,
                    okundu = item.okundu,
                    tarih = new DateTime(item.tarih.Year, item.tarih.Month, item.tarih.Day),
                    tel = item.tel,
                    user = item.user,
                    userId = item.userId
                });
            }

            listBildirm.ItemsSource = _listItems;
            #endregion

            #region User
            var clientUser = new RestClient(APIHelper.url + APIHelper.UserApiVeriler.UserApi + APIHelper.apiTypes.getall);
            var requestUser = new RestRequest();
            requestUser.AddHeader("Authorization", APIHelper.loginToken);
            requestUser.AddHeader("Content-Type", "application/json");
            var resUser = await clientUser.ExecuteAsync(requestUser, Method.Post);

            var userdata = JsonConvert.DeserializeObject<RootUser>(resUser.Content);

            _userList.Clear();
            _userNameList.Clear();
            _userNameList.Add("Hepsi");
            foreach (var item in userdata.data)
            {
                _userNameList.Add(item.kullanici);
                _userList.Add(new UserVeriler
                {
                    id = item.id,
                    kullanici = item.kullanici,
                    sifre = item.sifre
                });
            }

            pickerKullanici.ItemsSource = _userNameList;
            pickerKullanici.SelectedIndex = 0;

            //UserAyarlar Liste Dönüştürme
            //
            ////Eski Method
            ////string SonaEkleRes = userdata.data[0].programAyarListe.Insert(userdata.data[0].programAyarListe.Length, "}");
            ////string FinalRes = SonaEkleRes.Insert(0, "{ \"data\": ");
            //
            //var progAyardata = JsonConvert.DeserializeObject<RootProgramAyarListe>("{ \"data\": " + userdata.data[0].programAyarListe + "}");

            #endregion
        }

        private async void TestButton_Clicked(object sender, EventArgs e)
        {
            await getAllData();
        }

        private void InceleButton_Clicked(object sender, EventArgs e)
        {

        }

        private void listBildirm_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listBildirm.SelectedItem = null;
        }
    }
}