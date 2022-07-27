using System;
using System.Collections.Generic;
using System.Text;

namespace bilsoft_mobil_app.Helper.Veriler
{
    public class CariAdresVeriler
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
}
