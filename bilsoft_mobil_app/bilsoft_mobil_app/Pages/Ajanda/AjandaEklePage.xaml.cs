using bilsoft_mobil_app.Helper.API;
using bilsoft_mobil_app.Helper.App;
using bilsoft_mobil_app.Helper.JSONHelpers.User;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public new Color BackgroundColor { get; set; } = Color.FromHex(AppThemeColors._backgroundColor);
        public Color CardBackgroundColor { get; set; } = Color.FromHex(AppThemeColors._cardBackgroundColor);
        public Color Money { get; set; } = Color.FromHex(AppThemeColors._money);
        public Color MoneyBackground { get; set; } = Color.FromHex(AppThemeColors._moneyBackground);
        #endregion

        List<UserVeriler> _userList = new List<UserVeriler>();
        List<string> _userNameList = new List<string>();
        public AjandaEklePage()
        {
            InitializeComponent();
            BindingContext = this;
            getAllData();
        }
        private void AciklamaEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length >= 50)
            {
                lblAciklamaLength.TextColor = Color.Red;
                if (e.NewTextValue.Length > 50) edtAciklama.Text = e.OldTextValue;
            }
            else if (e.NewTextValue.Length < 50) lblAciklamaLength.TextColor = Color.Default;
            lblAciklamaLength.Text = "50/" + e.NewTextValue.Length.ToString();
        }
        async Task getAllData()
        {
            Loodinglayout.IsVisible = true;
            LoodingActivity.IsRunning = true;

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

            //End
            Loodinglayout.IsVisible = false;
            LoodingActivity.IsRunning = false;
        }
        private void btnKaydet_Clicked(object sender, EventArgs e)
        {

        }

        private void btnSil_Iptal_Clicked(object sender, EventArgs e)
        {

        }

        private async void TestButton_Clicked(object sender, EventArgs e)
        {
            await getAllData();
        }
    }
}