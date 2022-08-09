using bilsoft_mobil_app.Helper.API;
using bilsoft_mobil_app.Helper.App;
using bilsoft_mobil_app.Helper.JSONHelpers.User;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace bilsoft_mobil_app.Pages.Ajanda
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjandaEklePage : ContentPage
    {
        #region renk Bindleri
        public Color TextColor { get; set; } = Color.FromHex(AppThemeColors._textColor);
        public Color TextColorKoyu { get; set; } = Color.FromHex(AppThemeColors._textColorKoyu);
        public Color Success { get; set; } = Color.FromHex(AppThemeColors._success);
        public Color BorderColor { get; set; } = Color.FromHex(AppThemeColors._borderColor);
        public Color BackgroundColor { get; set; } = Color.FromHex(AppThemeColors._backgroundColor);
        public Color CardBackgroundColor { get; set; } = Color.FromHex(AppThemeColors._cardBackgroundColor);
        public Color Money { get; set; } = Color.FromHex(AppThemeColors._money);
        public Color MoneyBackground { get; set; } = Color.FromHex(AppThemeColors._moneyBackground);
        #endregion

        List<UserVeriler> _userList = new List<UserVeriler>();
        List<string> _userNameList = new List<string>();

        AjandaAddOrDeleteVeriler NewOrEditVeriler;
        bool isEdit = false;
        public AjandaEklePage(bool _isEdit, object _veri)
        {
            InitializeComponent();
            BindingContext = this;
            isEdit = _isEdit;
            getAllData((AjandaAddOrDeleteVeriler)_veri);
        }
        async Task getAllData(AjandaAddOrDeleteVeriler _veri)
        {
            Loodinglayout.IsVisible = true;
            LoodingActivity.IsRunning = true;

            //islem durumu
            pickerIslem.ItemsSource = new List<string>() { "Tamamlandı", "Tamamlanmadı" };

            #region User
            var clientUser = new RestClient(APIHelper.url + APIHelper.UserApiVeriler.UserApi + APIHelper.apiTypes.getall);
            var requestUser = new RestRequest();
            requestUser.AddHeader("Authorization", APIHelper.loginToken);
            requestUser.AddHeader("Content-Type", "application/json");
            var resUser = await clientUser.ExecuteAsync(requestUser, Method.Post);

            var userdata = JsonConvert.DeserializeObject<RootUser>(resUser.Content);

            _userList.Clear();
            _userNameList.Clear();
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
            #endregion

            //User
            pickerKullanici.ItemsSource = _userNameList;
            pickerKullanici.SelectedIndex = 0;

            //Edit
            #region Edit
            if (isEdit && _veri != null)
            {
                editModIslemDurumu.IsVisible = true;

                NewOrEditVeriler = _veri;
                entryFirma.Text = _veri.firma;
                entryAdSoyad.Text = _veri.adSoyad;
                entryTel.Text = _veri.tel;
                entryGSM.Text = _veri.cep;
                edtAciklama.Text = _veri.aciklama;
                pickerDate.Date = _veri.tarih;
                pickerTime.Time = new TimeSpan(_veri.tarih.Hour, _veri.tarih.Minute, _veri.tarih.Second);
                foreach (var item in _userList)
                {
                    if (_veri.userId == item.id)
                    {
                        pickerKullanici.SelectedItem = item.kullanici;
                    }
                }
                btnSil_Iptal.Text = "Sil";
                this.Title = "Düzenleme";
                if (_veri.okundu) pickerIslem.SelectedIndex = 0;
                else pickerIslem.SelectedIndex = 1;
            }
            #endregion

            //End
            Loodinglayout.IsVisible = false;
            LoodingActivity.IsRunning = false;
        }
        private void AciklamaEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length >= 50)
            {
                lblAciklamaLength.TextColor = Color.Red;
                if (e.NewTextValue.Length > 50)
                {
                    edtAciklama.Text = e.NewTextValue.Remove(50);
                }
            }
            else if (e.NewTextValue.Length < 50) lblAciklamaLength.TextColor = Color.Default;
            lblAciklamaLength.Text = "50/" + e.NewTextValue.Length.ToString();
        }
        private async void btnKaydet_Clicked(object sender, EventArgs e)
        {
            try
            {
                Loodinglayout.IsVisible = true;
                LoodingActivity.IsRunning = true;
                if (entryFirma.Text != null && entryAdSoyad.Text.Trim() != "" && entryAdSoyad.Text.Trim() != string.Empty)
                {
                    foreach (var item in _userList)
                    {
                        if (pickerKullanici.SelectedItem == item.kullanici)
                        {
                            if (!isEdit)
                            {
                                NewOrEditVeriler = new AjandaAddOrDeleteVeriler()
                                {
                                    firma = entryFirma.Text.Trim(),
                                    adSoyad = entryAdSoyad.Text.Trim(),
                                    tel = entryTel.Text.Trim(),
                                    cep = entryGSM.Text.Trim(),
                                    aciklama = edtAciklama.Text.Trim(),
                                    tarih = new DateTime(pickerDate.Date.Year, pickerDate.Date.Month, pickerDate.Date.Day, pickerTime.Time.Hours, pickerTime.Time.Minutes, pickerTime.Time.Seconds),
                                    id = 0,
                                    okundu = false,
                                    userId = item.id,
                                };
                            }
                            else
                            {
                                bool okundu = false;
                                //0 True 1 false
                                switch (pickerIslem.SelectedIndex)
                                {
                                    case 0:
                                        okundu = true;
                                        break;
                                    case 1:
                                        okundu = false;
                                        break;
                                }

                                NewOrEditVeriler = new AjandaAddOrDeleteVeriler()
                                {
                                    firma = entryFirma.Text.Trim(),
                                    adSoyad = entryAdSoyad.Text.Trim(),
                                    tel = entryTel.Text.Trim(),
                                    cep = entryGSM.Text.Trim(),
                                    aciklama = edtAciklama.Text.Trim(),
                                    tarih = new DateTime(pickerDate.Date.Year, pickerDate.Date.Month, pickerDate.Date.Day, pickerTime.Time.Hours, pickerTime.Time.Minutes, pickerTime.Time.Seconds),
                                    id = NewOrEditVeriler.id,
                                    okundu = okundu,
                                    userId = item.id,
                                };
                            }

                            var json = JsonConvert.SerializeObject(NewOrEditVeriler);

                            RestClient client;
                            if (isEdit) client = new RestClient(APIHelper.url + APIHelper.AjandaApiler.AjandaApi + APIHelper.apiTypes.update);
                            else client = new RestClient(APIHelper.url + APIHelper.AjandaApiler.AjandaApi + APIHelper.apiTypes.add);
                            RestRequest request = new RestRequest();
                            request.AddHeader("Authorization", APIHelper.loginToken);
                            request.AddHeader("Content-Type", "application/json");
                            request.AddJsonBody(json);

                            RestResponse res;
                            if (isEdit) res = await client.ExecuteAsync(request, Method.Put);
                            else res = await client.ExecuteAsync(request, Method.Post);
                            var data = JsonConvert.DeserializeObject<APIResponse>(res.Content);

                            if (data.success)
                            {
                                if (isEdit) DisplayAlert("", "Başarıyla Güncellendi.", "Kapat");
                                else DisplayAlert("", "Başarıyla eklendi.", "Kapat");
                                resetPage();
                                await Navigation.PopAsync();
                            }
                            else await DisplayAlert("Hata!", "Bir Hata Oluştu!\nHata Mesajı:\n" + data.message, "Tamam");
                        }
                    }
                }
                else
                {
                    DisplayAlert("Uyarı!", "Boş Veri Girmeyiniz!", "Tamam");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Uyarı!", "Bir Hata Oluştu. \nSistem Mesajı:\n" + ex.Message, "Tamam");
            }
        }
        async Task resetPage()
        {
            Loodinglayout.IsVisible = true;
            LoodingActivity.IsRunning = true;

            editModIslemDurumu.IsVisible = false;

            entryFirma.Text = String.Empty;
            entryAdSoyad.Text = String.Empty;
            entryTel.Text = String.Empty;
            entryGSM.Text = String.Empty;
            edtAciklama.Text = String.Empty;
            pickerDate.Date = DateTime.Now;
            pickerTime.Time = new TimeSpan(0, 0, 0, 0);
            await getAllData(null);

            Loodinglayout.IsVisible = false;
            LoodingActivity.IsRunning = false;
        }
        private async void btnSil_Iptal_Clicked(object sender, EventArgs e)
        {
            if (isEdit)
            {
                var res = await DisplayAlert("Uyarı!", "Veriyi silmek istiyormusunuz?", "Evet", "Hayır");
                if (res)
                {
                    Loodinglayout.IsVisible = true;
                    LoodingActivity.IsRunning = true;

                    var json = JsonConvert.SerializeObject(NewOrEditVeriler);

                    RestClient client = new RestClient(APIHelper.url + APIHelper.AjandaApiler.AjandaApi + APIHelper.apiTypes.delete);
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
            }
            else await Navigation.PopAsync();
        }

        private async void TestButton_Clicked(object sender, EventArgs e)
        {
            //_ = DisplayAlert("",
            //    pickerDate.Date.Year.ToString("00") + "-" +
            //    pickerDate.Date.Month.ToString("00") + "-" +
            //    pickerDate.Date.Day.ToString("00") + "T" +
            //    pickerTime.Time.Hours.ToString("00") + ":" +
            //    pickerTime.Time.Minutes.ToString("00") + ":" +
            //    pickerTime.Time.Seconds.ToString("00"), "ok");
            await getAllData(null);
        }

        private async void btnNotlar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AjandaNotlarPage(NewOrEditVeriler.id));
        }
    }
}