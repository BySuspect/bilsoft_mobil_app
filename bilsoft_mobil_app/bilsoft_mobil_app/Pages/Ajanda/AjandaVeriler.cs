using System;
using System.Collections.Generic;
using System.Text;

namespace bilsoft_mobil_app.Pages.Ajanda
{
    public class AjandaVeriler
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string adSoyad { get; set; }
        public string firma { get; set; }
        public string tel { get; set; }
        public string cep { get; set; }
        public string aciklama { get; set; }
        public DateTime tarih { get; set; }
        public bool okundu { get; set; }
        public object user { get; set; }
        public List<object> ajandaDosya { get; set; }
    }
}
