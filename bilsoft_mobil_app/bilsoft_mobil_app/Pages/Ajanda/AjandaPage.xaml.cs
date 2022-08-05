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

        List<AjandaVeriler> _mainItemslist = new List<AjandaVeriler>();
        ObservableCollection<AjandaVeriler> _listItems = new ObservableCollection<AjandaVeriler>();
        List<UserVeriler> _userList = new List<UserVeriler>();
        List<string> _userNameList = new List<string>();
        //List<RootProgramAyarListe> _programAyarList = new List<RootProgramAyarListe>();
        public AjandaPage()
        {
            InitializeComponent();
            BindingContext = this;

            pickerBildirimler.ItemsSource = new List<string>() { "Tüm Bildirimler", "Tamamlanan Bildirimler", "Tamamlanmayan Bildirimler" };
            pickerBildirimler.SelectedIndex = 0;

            //Ocak ayındamı deilmi kontrol
            try
            {
                if (DateTime.Now.Month - 1 != 0)
                    dpickerBaslangic.Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, DateTime.Now.Day);
                else dpickerBaslangic.Date = new DateTime(DateTime.Now.Year - 1, 12, DateTime.Now.Day);
            }
            catch { dpickerBaslangic.Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day); }

            dpickerBitis.Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await getAllData();
        }
        async Task getAllData()
        {
            Loodinglayout.IsVisible = true;
            LoodingActivity.IsRunning = true;

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

            //UserAyarlar Liste Dönüştürme
            //
            ////Eski Method
            ////string SonaEkleRes = userdata.data[0].programAyarListe.Insert(userdata.data[0].programAyarListe.Length, "}");
            ////string FinalRes = SonaEkleRes.Insert(0, "{ \"data\": ");
            //
            //var progAyardata = JsonConvert.DeserializeObject<RootProgramAyarListe>("{ \"data\": " + userdata.data[0].programAyarListe + "}");

            #endregion

            //User
            pickerKullanici.ItemsSource = _userNameList;
            pickerKullanici.SelectedIndex = 0;

            //Ajanda
            await listePropertiesCheck();
            listBildirm.ItemsSource = _mainItemslist;

            //End
            Loodinglayout.IsVisible = false;
            LoodingActivity.IsRunning = false;
        }

        private async void TestButton_Clicked(object sender, EventArgs e)
        {
            await getAllData();
            DisplayAlert("", (Guid.NewGuid()).ToString(), "ok");
        }

        private void InceleButton_Clicked(object sender, EventArgs e)
        {
            Loodinglayout.IsVisible = true;
            LoodingActivity.IsRunning = true;

            //Sayfa yönelndirme

            Loodinglayout.IsVisible = false;
            LoodingActivity.IsRunning = false;

        }

        private void listBildirm_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listBildirm.SelectedItem = null;
        }

        private async void entrySearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.NewTextValue))
            {
                var _list = new List<AjandaVeriler>();
                var _uniqueList = new List<AjandaVeriler>();

                await listePropertiesCheck();

                _list.AddRange(_mainItemslist.Where(x => x.adSoyad.ToLower().Contains(e.NewTextValue.ToLower())).ToList());
                _list.AddRange(_mainItemslist.Where(x => x.firma.ToLower().Contains(e.NewTextValue.ToLower())).ToList());
                _list.AddRange(_mainItemslist.Where(x => x.tel.ToLower().Contains(e.NewTextValue.ToLower())).ToList());
                _list.AddRange(_mainItemslist.Where(x => x.cep.ToLower().Contains(e.NewTextValue.ToLower())).ToList());
                _list.AddRange(_mainItemslist.Where(x => x.aciklama.ToLower().Contains(e.NewTextValue.ToLower())).ToList());

                for (int i = 0; i < _list.Count; i++)
                {
                    if (_list[i] == null) continue;
                    if (duplicateCheck(_list[i], _uniqueList))
                    {
                        continue;
                    }
                    else
                    {
                        _uniqueList.Add(_list[i]);
                    }
                }
                listBildirm.ItemsSource = new ObservableCollection<AjandaVeriler>(_uniqueList);
            }
            else
                listBildirm.ItemsSource = _mainItemslist;
        }

        bool duplicateCheck(object _item, List<AjandaVeriler> _list)
        {
            foreach (var item in _list)
            {
                if (_item == null) return false;
                if (item == _item)
                {
                    return true;
                }
            }
            return false;
        }
        async Task listePropertiesCheck()
        {
            if (pickerKullanici.SelectedItem == "Hepsi")
            {
                switch (pickerBildirimler.SelectedItem)
                {
                    case "Tüm Bildirimler":
                        _mainItemslist = _listItems.Where(x => (x.tarih >= dpickerBaslangic.Date && x.tarih <= dpickerBitis.Date)).ToList();
                        break;

                    case "Tamamlanan Bildirimler":
                        _mainItemslist = _listItems.Where(x => ((x.tarih >= dpickerBaslangic.Date && x.tarih <= dpickerBitis.Date) && x.okundu == true)).ToList();
                        break;

                    case "Tamamlanmayan Bildirimler":
                        _mainItemslist = _listItems.Where(x => ((x.tarih >= dpickerBaslangic.Date && x.tarih <= dpickerBitis.Date) && x.okundu == false)).ToList();
                        break;
                }
            }
            else
            {
                foreach (var item in _userList)
                {
                    if (item.kullanici == pickerKullanici.SelectedItem)
                    {
                        switch (pickerBildirimler.SelectedItem)
                        {
                            case "Tüm Bildirimler":
                                _mainItemslist = _listItems.Where(x => ((x.tarih >= dpickerBaslangic.Date && x.tarih <= dpickerBitis.Date) && x.userId == item.id)).ToList();
                                break;

                            case "Tamamlanan Bildirimler":
                                _mainItemslist = _listItems.Where(x => ((x.tarih >= dpickerBaslangic.Date && x.tarih <= dpickerBitis.Date) && x.okundu == true && x.userId == item.id)).ToList();
                                break;

                            case "Tamamlanmayan Bildirimler":
                                _mainItemslist = _listItems.Where(x => ((x.tarih >= dpickerBaslangic.Date && x.tarih <= dpickerBitis.Date) && x.okundu == false && x.userId == item.id)).ToList();
                                break;
                        }
                    }
                }
            }
            //Demo sadece tarihe göre listeliyor
            //_mainItemslist = _listItems.Where(x => (x.tarih >= dpickerBaslangic.Date && x.tarih <= dpickerBitis.Date)).ToList();

        }

        private async void btnSearch_Clicked(object sender, EventArgs e)
        {
            Loodinglayout.IsVisible = true;
            LoodingActivity.IsRunning = true;

            entrySearch.Text = "";
            await listePropertiesCheck();
            listBildirm.ItemsSource = _mainItemslist;

            Loodinglayout.IsVisible = false;
            LoodingActivity.IsRunning = false;
        }

        private void expListHeader_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }
    }
}