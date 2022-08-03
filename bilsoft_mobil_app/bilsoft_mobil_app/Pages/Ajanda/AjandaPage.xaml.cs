using bilsoft_mobil_app.Helper.API;
using bilsoft_mobil_app.Helper.JSONHelpers.RootAjanda;
using bilsoft_mobil_app.Helper.JSONHelpers.User;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bilsoft_mobil_app.Pages.Ajanda
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjandaPage : ContentPage
    {
        ObservableCollection<AjandaVeriler> _listItems = new ObservableCollection<AjandaVeriler>();
        List<UserVeriler> _userList = new List<UserVeriler>();
        List<RootProgramAyarListe> _programAyarList = new List<RootProgramAyarListe>();
        public AjandaPage()
        {
            //Test Verileri
            APIHelper.loginToken = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjI4OCIsInVuaXF1ZV9uYW1lIjoiMGMwNjNmY2QtNWY2Mi00Y2MzLTk4ODAtOWE5ZTg3N2Q5ZjllIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6ImRlbW8iLCJuYmYiOjE2NTk1MDY0NzEsImV4cCI6MTY1OTU0OTY2OCwiaXNzIjoid3d3LmJpbHNvZnQuY29tIiwiYXVkIjoid3d3LmJpbHNvZnQuY29tIn0.WDWTKuPCOBFisIp6qMg9oaGM8UlO52BFRBsMKL0puVw";
            APIHelper.kullaniciAdi = "demo";
            APIHelper.subeAd = "merkez";
            //Test Verileri End

            InitializeComponent();
        }

        async Task getAllData()
        {
            #region Ajanda
            var client = new RestClient(APIHelper.url + APIHelper.AjandaApiler.AjandaApi + APIHelper.apiTypes.getall);
            var request = new RestRequest();
            request.AddHeader("Authorization", APIHelper.loginToken);
            request.AddHeader("Content-Type", "application/json");
            var res = await client.ExecuteAsync(request, Method.Post);
            var data = JsonConvert.DeserializeObject<RootAjanda>(res.Content);

            foreach (var item in data.data)
            {
                _listItems.Add(new AjandaVeriler
                {
                    aciklama = item.aciklama,
                    adSoyad = item.adSoyad,
                    ajandaDosya = item.ajandaDosya,
                    cep = item.cep,
                    firma = item.firma,
                    id = item.id,
                    okundu = item.okundu,
                    tarih = item.tarih,
                    tel = item.tel,
                    user = item.user,
                    userId = item.userId
                });
            }
            #endregion
        }

        private async void TestButton_Clicked(object sender, EventArgs e)
        {
            var client = new RestClient(APIHelper.url + APIHelper.UserApiVeriler.UserApi + APIHelper.apiTypes.getall);
            var request = new RestRequest();
            request.AddHeader("Authorization", APIHelper.loginToken);
            request.AddHeader("Content-Type", "application/json");
            var res = await client.ExecuteAsync(request, Method.Post);

            var userdata = JsonConvert.DeserializeObject<RootUser>(res.Content);
            var progAyardata = JsonConvert.DeserializeObject<RootProgramAyarListe>(userdata.data[0].programAyarListe);

        }
    }
}