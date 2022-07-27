using System;
using System.Collections.Generic;
using System.Text;

namespace bilsoft_mobil_app.Helper.JSONHelpers.RootCari
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class RootCariBankaDatum
    {
        public int id { get; set; }
        public int cariId { get; set; }
        public string bankaAdi { get; set; }
        public string bankaSube { get; set; }
        public string subeNo { get; set; }
        public string iban { get; set; }
        public string hesapNo { get; set; }
        public string kullaniciAdi { get; set; }
        public string subeAdi { get; set; }
        public object cariKart { get; set; }
    }

    public class RootCariBanka
    {
        public List<RootCariBankaDatum> data { get; set; }
        public int totalCount { get; set; }
        public bool success { get; set; }
        public object message { get; set; }
        public object code { get; set; }
    }
}
