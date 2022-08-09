using bilsoft_mobil_app.Helper.API;
using bilsoft_mobil_app.Helper.App;
using bilsoft_mobil_app.Helper.JSONHelpers.User;
using bilsoft_mobil_app.Helper.JSONHelpers.RootAjanda;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;
using System.Linq;

namespace bilsoft_mobil_app.Pages.Ajanda
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjandaNotlarPage : ContentPage
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

        List<AjandaNotVerilerDatum> _mainItemslist = new List<AjandaNotVerilerDatum>();
        ObservableCollection<AjandaNotVeriler> _listItems = new ObservableCollection<AjandaNotVeriler>();

        AjandaNotVerilerDatum NewNotVeriler;
        int ajandaId = 0;
        public AjandaNotlarPage(int id)
        {
            InitializeComponent();
            BindingContext = this;
            ajandaId = id;
            GetAll();
        }
        async Task GetAll()
        {
            Loodinglayout.IsVisible = true;
            LoodingActivity.IsRunning = true;
            try
            {

                #region Notlar
                var clientAjanda = new RestClient(APIHelper.url + APIHelper.AjandaApiler.AjandaNotlarApi + APIHelper.apiTypes.getall);
                var requestAjanda = new RestRequest();
                requestAjanda.AddHeader("Authorization", APIHelper.loginToken);
                requestAjanda.AddHeader("Content-Type", "application/json");
                var resAjanda = await clientAjanda.ExecuteAsync(requestAjanda, Method.Post);
                var dataAjanda = JsonConvert.DeserializeObject<RootAjandaNotVeriler>(resAjanda.Content);

                _listItems.Clear();
                _mainItemslist.Clear();

                foreach (var item in dataAjanda.data)
                {
                    //await DisplayAlert("", item.tarih + "", "ok");
                    _listItems.Add(new AjandaNotVeriler
                    {
                        btnid = "btn" + item.id,
                        id = item.id,
                        ajandaId = item.ajandaId,
                        notlar = item.notlar,
                    });
                    _mainItemslist.Add(new AjandaNotVerilerDatum
                    {
                        id = item.id,
                        ajandaId = item.ajandaId,
                        notlar = item.notlar,
                    });
                }
                #endregion

                lvNotlar.ItemsSource = _listItems.Where(x => x.ajandaId == ajandaId.ToString()).OrderBy(x => x.id).ToList();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Hata!", "Hata oluştu! \nHata Mesajı: " + ex.Message, "Tamam");
                await Navigation.PopAsync();
            }
            Loodinglayout.IsVisible = false;
            LoodingActivity.IsRunning = false;
        }
        private void edtNot_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length >= 250)
            {
                lblNotLength.TextColor = Color.Red;
                if (e.NewTextValue.Length > 250)
                {
                    edtNot.Text = e.NewTextValue.Remove(250);
                }
            }
            else if (e.NewTextValue.Length < 250) lblNotLength.TextColor = Color.Default;
            lblNotLength.Text = "250/" + e.NewTextValue.Length.ToString();
        }

        private async void btnKaydet_Clicked(object sender, EventArgs e)
        {
            Loodinglayout.IsVisible = true;
            LoodingActivity.IsRunning = true;
            try
            {
                if (edtNot.Text != null && edtNot.Text.Trim() != "" && edtNot.Text.Trim() != string.Empty)
                {
                    NewNotVeriler = new AjandaNotVerilerDatum()
                    {
                        notlar = edtNot.Text,
                        ajandaId = this.ajandaId.ToString(),
                        id = 0,
                    };
                    var json = JsonConvert.SerializeObject(NewNotVeriler);

                    RestClient client = new RestClient(APIHelper.url + APIHelper.AjandaApiler.AjandaNotlarApi + APIHelper.apiTypes.add);
                    RestRequest request = new RestRequest();
                    request.AddHeader("Authorization", APIHelper.loginToken);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddJsonBody(json);

                    RestResponse res = await client.ExecuteAsync(request, Method.Post);

                    var data = JsonConvert.DeserializeObject<APIResponse>(res.Content);

                    if (data.success)
                    {
                        DisplayAlert("", "Başarıyla eklendi.", "Kapat");
                        edtNot.Text = String.Empty;
                        GetAll();
                    }
                    else await DisplayAlert("Hata!", "Bir Hata Oluştu!\nHata Mesajı:\n" + data.message, "Tamam");
                }
                else
                {
                    DisplayAlert("Hata!", "Boş Veri Girmeyiniz.", "Tamam");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Hata!", "Hata oluştu! \nHata Mesajı: " + ex.Message, "Tamam");
            }
            Loodinglayout.IsVisible = false;
            LoodingActivity.IsRunning = false;
        }

        private void NotSilButton_Clicked(object sender, EventArgs e)
        {

        }

        private void btnTest_Clicked(object sender, EventArgs e)
        {
            GetAll();
        }
    }
}