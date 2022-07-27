using System;
using System.Collections.Generic;
using System.Text;

namespace bilsoft_mobil_app.Helper.JSONHelpers.RootCari
{
    // RootCariAdressler res = JsonConvert.DeserializeObject<RootCariAdressler>(res);
    public class RootCariAdresslerDatum
    {
        public int id { get; set; }
        public int cariId { get; set; }
        public string yetkili { get; set; }
        public string tel { get; set; }
        public string cep { get; set; }
        public string sevkAdres { get; set; }
        public string mail { get; set; }
        public string postaKodu { get; set; }
        public string il { get; set; }
        public string ilce { get; set; }
        public object ulke { get; set; }
        public object cariKart { get; set; }
    }

    public class RootCariAdressler
    {
        public List<RootCariAdresslerDatum> data { get; set; }
        public int totalCount { get; set; }
        public bool success { get; set; }
        public object message { get; set; }
        public object code { get; set; }
    }

}
