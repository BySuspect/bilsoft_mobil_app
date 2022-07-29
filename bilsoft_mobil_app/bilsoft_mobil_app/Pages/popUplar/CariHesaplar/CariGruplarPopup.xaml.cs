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
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bilsoft_mobil_app.Pages.popUplar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CariGruplarPopup : Popup
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
        public ObservableCollection<CariGuruplarListVeriler> _listItemsSource = new ObservableCollection<CariGuruplarListVeriler>();

        public List<string> ResultList = new List<string>();

        public int sonId { get; set; }
        public CariGruplarPopup()
        {
            BindingContext = this;
            InitializeComponent();
            RefreshList();
        }
        async Task RefreshList()
        {
            Loodinglayout.IsVisible = true;
            LoodingActivity.IsRunning = true;

            var client = new RestClient(APIHelper.url + APIHelper.CariGrupApi + apiTypes.getall);
            var request = new RestRequest();
            request.AddHeader("Authorization", APIHelper.loginToken);
            request.AddHeader("Content-Type", "application/json");
            var resCariGrup = await client.ExecuteAsync(request, Method.Post);
            var dataCariGrup = JsonConvert.DeserializeObject<RootCariGrup>(resCariGrup.Content);

            ObservableCollection<CariHesaplarPickerItems> _pickerlistItemsSource = new ObservableCollection<CariHesaplarPickerItems>();

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

            _listItemsSource.Clear();
            for (int i = 0; i < _pickerlistItemsSource.Count; i++)
            {
                _listItemsSource.Add(new CariGuruplarListVeriler
                {
                    id = _pickerlistItemsSource[i].ID,
                    grup = _pickerlistItemsSource[i].grupAd,
                    kullaniciAdi = _pickerlistItemsSource[i].kullaniciAd,
                    subeAdi = _pickerlistItemsSource[i].subeAd,
                    btnId = "btn" + i,
                    sira = i + 1
                });
                if (_pickerlistItemsSource[i].ID > sonId) sonId = _pickerlistItemsSource[i].ID;
            }
            GrupListView.ItemsSource = _listItemsSource;

            Loodinglayout.IsVisible = false;
            LoodingActivity.IsRunning = false;
        }
        async Task DeleteOnList(string id)
        {
            try
            {
                Loodinglayout.IsVisible = true;
                LoodingActivity.IsRunning = true;

                foreach (var item in _listItemsSource)
                {
                    if (item.btnId == id)
                    {
                        string deleteData = "{\"id\":" + item.id + ",\"grup\":\"" + item.grup + "\",\"kullaniciAdi\":\"" + APIHelper.kullaniciAdi + "\",\"subeAdi\":\"" + APIHelper.subeAd + "\"}";

                        RestClient client = new RestClient(APIHelper.url + APIHelper.CariGrupApi + apiTypes.delete);
                        RestRequest request = new RestRequest();
                        request.AddHeader("Authorization", APIHelper.loginToken);
                        request.AddHeader("Content-Type", "application/json");
                        request.AddJsonBody(deleteData);
                        var resCariGrup = await client.ExecuteAsync(request, Method.Post);
                        var dataCariGrup = JsonConvert.DeserializeObject<APIResponse>(resCariGrup.Content);
                        if (dataCariGrup.success)
                        {
                            _listItemsSource.Remove(item);
                            await RefreshList();
                            break;
                        }
                        else
                            throw new Exception(dataCariGrup.message);
                        break;
                    }
                }

                Loodinglayout.IsVisible = false;
                LoodingActivity.IsRunning = false;
                //_listItemsSource.Clear();
                //for (int i = 0; i < GrupListNames.Count(); i++)
                //{
                //    RefeshList(i, GrupListNames[i]);
                //}
                //if (_listItemsSource.Count > 0) GrupListView.ItemsSource = _listItemsSource;
                //else GrupListView.ItemsSource = null;
            }
            catch (Exception ex)
            {
                Loodinglayout.IsVisible = false;
                LoodingActivity.IsRunning = false;
                throw new Exception(ex.Message);
            }
        }
        async Task AddOnList()
        {
            try
            {
                int denemeCount = 0;
            repeat:
                if (denemeCount > 5)
                {
                    AlertView.show("Hata", "Çok Fazla yeniden denendi!", "Tamam");
                }
                Loodinglayout.IsVisible = true;
                LoodingActivity.IsRunning = true;

                string deleteData = "{\"id\":" + 0 + ",\"grup\":\"" + entryYeniGrup.Text.Trim() + "\",}";

                RestClient client = new RestClient(APIHelper.url + APIHelper.CariGrupApi + apiTypes.add);
                RestRequest request = new RestRequest();
                request.AddHeader("Authorization", APIHelper.loginToken);
                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(deleteData);
                var resCariGrup = await client.ExecuteAsync(request, Method.Post);
                var dataCariGrup = JsonConvert.DeserializeObject<APIResponse>(resCariGrup.Content);
                if (dataCariGrup.success)
                {
                    denemeCount = 0;
                    AlertView.show("", "Başarıyla Eklendi!", "Tamam");
                    await RefreshList();
                    YeniGrupView.IsVisible = false;
                }
                else
                {
                    bool alertRes = await AlertView.showAsync("Hata", dataCariGrup.message, "Yeniden Dene", "İptal");
                    if (alertRes)
                    {
                        denemeCount++;
                        goto repeat;
                    }
                }

                Loodinglayout.IsVisible = false;
                LoodingActivity.IsRunning = false;
                YeniGrupView.IsVisible = false;
                //_listItemsSource.Clear();
                //for (int i = 0; i < GrupListNames.Count(); i++)
                //{
                //    RefeshList(i, GrupListNames[i]);
                //}
                //if (_listItemsSource.Count > 0) GrupListView.ItemsSource = _listItemsSource;
                //else GrupListView.ItemsSource = null;
            }
            catch (Exception ex)
            {
                Loodinglayout.IsVisible = false;
                LoodingActivity.IsRunning = false;
                throw new Exception(ex.Message);
            }
        }
        private async void YeniGrupKaydet_Clicked(object sender, EventArgs e)
        {
            entryYeniGrup.Unfocus();
            if (entryYeniGrup.Text != null && entryYeniGrup.Text.Trim() != "" && !string.IsNullOrEmpty(entryYeniGrup.Text.Trim()))
            {
                YeniGrupView.IsVisible = false;
                await AddOnList();
            }
            else
            {
                AlertView.show("Hata", "Boş veri girmeyiniz!", "Tamam");
                entryYeniGrup.Unfocus();
            }
        }

        private void YeniGrupIptal_Clicked(object sender, EventArgs e)
        {
            entryYeniGrup.Unfocus();
            YeniGrupView.IsVisible = false;
            entryYeniGrup.Text = "";
        }

        private void btnYeniGrup_Clicked(object sender, EventArgs e)
        {
            YeniGrupView.IsVisible = true;
        }

        private void csbArama_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(e.NewTextValue))
                    GrupListView.ItemsSource = new ObservableCollection<CariGuruplarListVeriler>((IEnumerable<CariGuruplarListVeriler>)_listItemsSource.Where(x => x.grup.ToLower().StartsWith(e.NewTextValue.ToLower())).OrderBy(x => x).ToList());
                else
                    GrupListView.ItemsSource = _listItemsSource;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnListEdit_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnListDelete_Clicked(object sender, EventArgs e)
        {
            Loodinglayout.IsVisible = true;
            LoodingActivity.IsRunning = true;
            var btn = sender as Button;
            await DeleteOnList(btn.AutomationId);
            Loodinglayout.IsVisible = false;
            LoodingActivity.IsRunning = false;
        }


        private void btnDismissPopUp_Clicked(object sender, EventArgs e)
        {
            Dismiss(null);
        }
    }
}