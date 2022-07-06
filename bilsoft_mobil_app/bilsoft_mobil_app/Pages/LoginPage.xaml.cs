using bilsoft_mobil_app.CustomItems;
using bilsoft_mobil_app.Helper;
using bilsoft_mobil_app.Pages.MainView;
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

        public BorderlessPicker Picker { get => pickerDonem; set => pickerDonem = value; }

        public string Title { get => pickerDonem.Title; set => pickerDonem.Title = value; }

        public System.Collections.IList ItemsSource { get => pickerDonem.ItemsSource; set => pickerDonem.ItemsSource = value; }


        private Users _users { get; set; }
        string _logindata;
        RootGirisYapTokenAl tokenData;
        public LoginPage()
        {
            BindingContext = this;
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            await FirstStart();
        }
        private async void ResetBTN_Clicked(object sender, EventArgs e)
        {
            Preferences.Clear();
            APIHelper.logindonemYil.Clear();
            await DisplayAlert("aaa", "Veriler Temizlendi", "aa");
        }

        [Obsolete]
        private async void bt_login_Clicked(object sender, EventArgs e)
        {
            await userLogin();
        }

        [Obsolete]
        private void btn_sifreunuttum_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://bilsoft.net"));
        }

        [Obsolete]
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
                    string[] donemYillar = new string[GirisData.data.firmaVeritabaniDTO[0].firmaVeritabaniDonemDTO.Count];
                    APIHelper.vergiNo = entry_loginvergino.Text;
                    APIHelper.kullaniciAdi = entry_loginkullaniciadi.Text;
                    APIHelper.kullaniciSifre = entry_loginsifre.Text;
                    APIHelper.veritabaniAd = GirisData.data.firmaVeritabaniDTO[0].veritabaniAd;
                    for (int i = 0; i < GirisData.data.firmaVeritabaniDTO[0].firmaVeritabaniDonemDTO.Count; i++)
                    {
                        donemYillar[i] = GirisData.data.firmaVeritabaniDTO[0].firmaVeritabaniDonemDTO[i].donemYil;
                        APIHelper.logindonemYil.Add(GirisData.data.firmaVeritabaniDTO[0].firmaVeritabaniDonemDTO[i].donemYil);
                    }

                    pickerDonem.ItemsSource = donemYillar;

                    btnDonemPopupIptal.Clicked += (s, e) =>
                    {
                        GirisDonemLayout.IsVisible = false; 
                        Loodinglayout.IsVisible = false;
                        LoodingActivity.IsVisible = false;
                        LoodingActivity.IsRunning = false;
                    };


                    btnDonemPopupOnayla.Clicked += async (s, e) =>
                    {
                        if (pickerDonem.SelectedItem != null)
                        {
                            Loodinglayout.IsVisible = true;
                            LoodingActivity.IsVisible = true;
                            LoodingActivity.IsRunning = true;
                            APIHelper.loginMod = "Login";
                            GirisYapConvert(pickerDonem.SelectedItem.ToString(), entrySubeAd.Text);
                            await Task.Delay(100);
                            webURL = APIHelper.tokeApi;
                            res = await httpHelper.callAPI(webURL, _logindata);
                            tokenData = JsonConvert.DeserializeObject<RootGirisYapTokenAl>(res.data.ToString());
                            APIHelper.secilenlogindonemYil = Picker.SelectedItem.ToString();
                            if (tokenData.message == null)
                            {
                                if (cb_benihatirla.IsChecked)
                                {
                                    beniHatırla();
                                }
                                if (cb_oturumuaciktut.IsChecked)
                                {
                                    oturumuAciktut();
                                }
                                await Navigation.PushModalAsync(new MainPage(), false);/**/
                            }
                            else
                                await DisplayAlert("Hata", tokenData.message.ToString(), "Tamam");
                            
                            Loodinglayout.IsVisible = false;
                            LoodingActivity.IsVisible = false;
                            LoodingActivity.IsRunning = false;
                        }
                        else
                        {
                            await DisplayAlert("Hata", "Hatalı Giriş", "Tamam");
                        }
                    };
                    GirisDonemLayout.IsVisible = true;

                    /*string action = await DisplayActionSheet("Dönem Seçiniz", "İptal","Çıkış", donemYillar);
                    if (action != "İptal" && action !="Çıkış")
                     {
                         GirisYapConvert(action);
                         await Task.Delay(100);
                         webURL = APIHelper.tokeApi;
                         res = await httpHelper.callAPI(webURL, _logindata);
                         RootGirisYapTokenAl tokenData = JsonConvert.DeserializeObject<RootGirisYapTokenAl>(res.data.ToString());

                         await Navigation.PushAsync(new MainMDPage(APIHelper.loginMod,"index"), true);
                     }
                     else if (action == "Çıkış")
                     {
                         Preferences.Clear();
                         APIHelper.vergiNo = null;
                         APIHelper.kullaniciAdi = null;
                         APIHelper.kullaniciSifre = null;
                         APIHelper.veritabaniAd = null;
                         APIHelper.logindonemYil.Clear();
                     }/**/
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
            Preferences.Set("BeniHatirlaChecked", true);
            Preferences.Set("BeniHatirlaVergiNo", entry_loginvergino.Text);
            Preferences.Set("BeniHatirlaKullaniciAdi", entry_loginkullaniciadi.Text);
            Preferences.Set("BeniHatirlaKullaniciSifre", entry_loginsifre.Text);
        }

        async Task oturumuAciktut()
        {
            Preferences.Set("OturumuAcikTut", true);
            Preferences.Set("OturumuAcikTutVergiNo", entry_loginvergino.Text);
            Preferences.Set("OturumuAcikTutKAd", entry_loginkullaniciadi.Text);
            Preferences.Set("OturumuAcikTutKsifre", entry_loginsifre.Text);
            Preferences.Set("OturumuAcikTutDonem", pickerDonem.SelectedItem.ToString());
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
            }

            if (Preferences.Get("OturumuAcikTut", false))
            {
                try
                {
                    Loodinglayout.IsVisible = true;
                    LoodingActivity.IsVisible = true;
                    LoodingActivity.IsRunning = true;

                    cb_oturumuaciktut.IsChecked = true;
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
                        string[] donemYillar = new string[GirisData.data.firmaVeritabaniDTO[0].firmaVeritabaniDonemDTO.Count];
                        APIHelper.vergiNo = entry_loginvergino.Text;
                        APIHelper.kullaniciAdi = entry_loginkullaniciadi.Text;
                        APIHelper.kullaniciSifre = entry_loginsifre.Text;
                        APIHelper.veritabaniAd = GirisData.data.firmaVeritabaniDTO[0].veritabaniAd;
                        for (int i = 0; i < GirisData.data.firmaVeritabaniDTO[0].firmaVeritabaniDonemDTO.Count; i++)
                        {
                            donemYillar[i] = GirisData.data.firmaVeritabaniDTO[0].firmaVeritabaniDonemDTO[i].donemYil;
                            APIHelper.logindonemYil.Add(GirisData.data.firmaVeritabaniDTO[0].firmaVeritabaniDonemDTO[i].donemYil);
                        }
                        APIHelper.loginMod = "Login";
                        GirisYapConvert(Preferences.Get("OturumuAcikTutDonem", "Yok"), entrySubeAd.Text);
                        await Task.Delay(100);
                        webURL = APIHelper.tokeApi;
                        res = await httpHelper.callAPI(webURL, _logindata);
                        tokenData = JsonConvert.DeserializeObject<RootGirisYapTokenAl>(res.data.ToString());

                        if (tokenData.message == null)
                        {
                            APIHelper.secilenlogindonemYil = Preferences.Get("OturumuAcikTutDonem", "Yok");
                            await Navigation.PushModalAsync(new MainPage(),false);/**/
                        }
                        else
                            await DisplayAlert("Hata", tokenData.message.ToString(), "Tamam");

                    }
                }
                catch
                {
                    await DisplayAlert("Hata", "Giriş Yapılırken Hata Oluştu Tekrar Deneyiniz", "Tamam");
                }
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
        void GirisYapConvert(string yil,string subeAd)
        {
            _logindata = "{\"vergiNumarasi\":\"" + APIHelper.vergiNo + "\",\"kullaniciAd\":\"" + APIHelper.kullaniciAdi + "\",\"kullaniciSifre\":\"" + APIHelper.kullaniciSifre + "\",\"veritabaniAd\":\"" + APIHelper.veritabaniAd + "\",\"donemYil\":\"" + yil + "\",\"subeAd\":\"" + subeAd + "\",\"apiKullaniciAdi\":\"" + APIHelper.apiKullaniciAdi + "\",\"apiKullaniciSifre\":\"" + APIHelper.apiKullaniciSifre + "\"}";
        }

        private void btn_ucretsizdene_Clicked(object sender, EventArgs e)
        {

        }

        private async void btn_demogiris_Clicked(object sender, EventArgs e)
        {
            Loodinglayout.IsVisible = true;
            LoodingActivity.IsVisible = true;
            LoodingActivity.IsRunning = true;
            APIHelper.loginMod = "demo";
            await Navigation.PushModalAsync(new MainPage(), false);/**/
            Loodinglayout.IsVisible = false;
            LoodingActivity.IsVisible = false;
            LoodingActivity.IsRunning = false;
        }

        private async void TestBTN_Clicked(object sender, EventArgs e)
        {

        }

        private void btnDonemPickerOpen_Clicked(object sender, EventArgs e)
        {
            pickerDonem.Focus();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}