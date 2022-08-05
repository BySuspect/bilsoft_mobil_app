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
