using System;
using System.Collections.Generic;
using System.Text;

namespace bilsoft_mobil_app.Helper.JSONHelpers.RootCari
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class DatumRootCariGrup
    {
        public int id { get; set; }
        public string grup { get; set; }
        public string kullaniciAdi { get; set; }
        public string subeAdi { get; set; }
    }

    public class RootCariGrup
    {
        public List<DatumRootCariGrup> data { get; set; }
        public int totalCount { get; set; }
        public bool success { get; set; }
        public object message { get; set; }
        public object code { get; set; }
    }
}
