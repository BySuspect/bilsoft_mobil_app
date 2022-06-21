using bilsoft_mobil_app.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bilsoft_mobil_app.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private Users _users { get; set; }
        string _logindata;
        public LoginPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            await FirstStart();
        }
        private async void ResetBTN_Clicked(object sender, EventArgs e)
        {
            Preferences.Clear();
            await DisplayAlert("aaa", "Veriler Temizlendi", "aa");
        }
        private async void bt_login_Clicked(object sender, EventArgs e)
        {
            await userLogin();
        }

        [Obsolete]
        private void btn_sifreunuttum_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://bilsoft.net"));
        }
        private async Task userLogin()
        {
            try
            {
                Loodinglayout.IsVisible = true;
                LoodingActivity.IsVisible = true;
                LoodingActivity.IsRunning = true;


                string webURL = APIHelper.loginDonemGetirAPI;
                HttpHelper httpHelper = new HttpHelper();
                RootGirisYapDonemGetir GirisData;
                APIResponse res;
                #region sunucu GirisYapDonemGetir Gönderme
                GirisYapDonemGetirConvert();
                await Task.Delay(100);
                res = await httpHelper.callAPI(webURL, _logindata);
                GirisData = JsonConvert.DeserializeObject<RootGirisYapDonemGetir>(res.data.ToString());
                #endregion

                if (!GirisData.success)
                {
                    await DisplayAlert("Hata", GirisData.message.ToString(), "Tamam");
                }
                else
                {

                    APIHelper.vergiNo = entry_loginvergino.Text;
                    APIHelper.kullaniciAdi = entry_loginkullaniciadi.Text;
                    APIHelper.kullaniciSifre = entry_loginsifre.Text;
                    APIHelper.veritabaniAd = GirisData.data.firmaVeritabaniDTO[0].veritabaniAd;
                    for (int i = 0; i < GirisData.data.firmaVeritabaniDTO[0].firmaVeritabaniDonemDTO.Count; i++)
                    {
                        APIHelper.logindonemYil.Add(GirisData.data.firmaVeritabaniDTO[0].firmaVeritabaniDonemDTO[i].donemYil);
                    }

                    if (cb_benihatirla.IsChecked || cb_oturumuaciktut.IsChecked)
                    {
                        await beniHatırla();
                    }
                    GirisYapConvert();
                    await Task.Delay(100);
                    webURL = APIHelper.tokeApi;
                    res = await httpHelper.callAPI(webURL, _logindata);
                    RootGirisYapTokenAl tokenData = JsonConvert.DeserializeObject<RootGirisYapTokenAl>(res.data.ToString());

                    await DisplayAlert("aaa", "Giris Başarılı", "aaa");
                }             

                Loodinglayout.IsVisible = false;
                LoodingActivity.IsVisible = false;
                LoodingActivity.IsRunning = false;
            }
            catch
            {
                Loodinglayout.IsVisible = false;
                LoodingActivity.IsVisible = false;
                LoodingActivity.IsRunning = false;
            }

        }
        public Users users
        {
            get { return _users; }
            set { }
        }
        async Task beniHatırla()
        {
            if(cb_benihatirla.IsChecked) Preferences.Set("BeniHatirlaChecked", true);
            if(cb_oturumuaciktut.IsChecked) Preferences.Set("OturumuAcikTutChecked", true);
            Preferences.Set("BeniHatirlaVergiNo", entry_loginvergino.Text);
            Preferences.Set("BeniHatirlaKullaniciAdi", entry_loginkullaniciadi.Text);
            Preferences.Set("BeniHatirlaKullaniciSifre", entry_loginsifre.Text);
            await DisplayAlert("aaa", "Veriler Kaydedildi", "aa");
        }
        async Task FirstStart()
        {
            Loodinglayout.IsVisible = true;
            LoodingActivity.IsVisible = true;
            LoodingActivity.IsRunning = true;

            if (Preferences.Get("BeniHatirlaChecked", false))
            {
                entry_loginvergino.Text = Preferences.Get("BeniHatirlaVergiNo", "");
                entry_loginkullaniciadi.Text = Preferences.Get("BeniHatirlaKullaniciAdi", "");
                entry_loginsifre.Text = Preferences.Get("BeniHatirlaKullaniciSifre", "");
                cb_benihatirla.IsChecked = true;
                await DisplayAlert("aaa", "Veriler Alındı", "aa");
            }

            Loodinglayout.IsVisible = false;
            LoodingActivity.IsVisible = false;
            LoodingActivity.IsRunning = false;
        }
        void GirisYapDonemGetirConvert()
        {
            //Sunucu boş veri olduğunda mesaj döndürüyor.
            //if (entry_loginvergino!=null&&entry_loginkullaniciadi.Text!=null&&entry_loginsifre!=null) 
            _logindata = "{ \"vergiNumarasi\": \"" + entry_loginvergino.Text + "\",\"kullaniciAdi\": \"" + entry_loginkullaniciadi.Text + "\",\"kullaniciSifre\": \"" + entry_loginsifre.Text + "\"}";

        }
        void GirisYapConvert()
        {
            _logindata = "{\"vergiNumarasi\":\"" + APIHelper.vergiNo + "\",\"kullaniciAd\":\"" + APIHelper.kullaniciAdi + "\",\"kullaniciSifre\":\"" + APIHelper.kullaniciSifre + "\",\"veritabaniAd\":\"" + APIHelper.veritabaniAd + "\",\"donemYil\":\"2022\",\"subeAd\":\"" + APIHelper.subeAd + "\",\"apiKullaniciAdi\":\"" + APIHelper.apiKullaniciAdi + "\",\"apiKullaniciSifre\":\"" + APIHelper.apiKullaniciSifre + "\"}";
        }

        private void btn_ucretsizdene_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_demogiris_Clicked(object sender, EventArgs e)
        {

        }

    }
}