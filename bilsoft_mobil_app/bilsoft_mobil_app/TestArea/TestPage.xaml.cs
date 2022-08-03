using bilsoft_mobil_app.CustomItems;
using bilsoft_mobil_app.Helper;
using bilsoft_mobil_app.Helper.API;
using bilsoft_mobil_app.TestArea;
using Microcharts;
using Newtonsoft.Json;
using RestSharp;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace bilsoft_mobil_app
{
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
            //Test Verileri
            APIHelper.loginToken = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjI4OCIsInVuaXF1ZV9uYW1lIjoiMGMwNjNmY2QtNWY2Mi00Y2MzLTk4ODAtOWE5ZTg3N2Q5ZjllIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6ImRlbW8iLCJuYmYiOjE2NTk1MDY0NzEsImV4cCI6MTY1OTU0OTY2OCwiaXNzIjoid3d3LmJpbHNvZnQuY29tIiwiYXVkIjoid3d3LmJpbHNvZnQuY29tIn0.WDWTKuPCOBFisIp6qMg9oaGM8UlO52BFRBsMKL0puVw";
            APIHelper.kullaniciAdi = "demo";
            APIHelper.subeAd = "merkez";
            //Test Verileri End
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var client = new RestClient(APIHelper.url + "api/Raporlar/getall");
            var request = new RestRequest();
            request.AddHeader("Authorization", APIHelper.loginToken);
            request.AddHeader("Content-Type", "application/json");
            var res = await client.ExecuteAsync(request, Method.Post);

            var data = JsonConvert.DeserializeObject<RootTest>(res.Content);

            //var welcome5 = testXml.FromJson(data.data[0].frx);
        }
    }
}
