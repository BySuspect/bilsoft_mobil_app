using System;
using System.Collections.Generic;
using System.Text;

namespace bilsoft_mobil_app.Helper.JSONHelpers.RootCari
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class DatumRootCariKartlar
    {
        public int id { get; set; }
        public string grup { get; set; }
        public string yetkili { get; set; }
        public string tel { get; set; }
        public string cep { get; set; }
        public string adres { get; set; }
        public string mail { get; set; }
        public string fax { get; set; }
        public string faturaIl { get; set; }
        public string faturaIlce { get; set; }
        public string faturaAdres { get; set; }
        public string vergiDairesi { get; set; }
        public string vergiNo { get; set; }
        public string faturaUnvan { get; set; }
        public string webAdresi { get; set; }
        public string postakodu { get; set; }
        public string riskLimiti { get; set; }
        public string riskIslemi { get; set; }
        public string sevkAdresi { get; set; }
        public string kullaniciAdi { get; set; }
        public string subeAdi { get; set; }
        public string ticaretsicilno { get; set; }
        public string cariKod { get; set; }
        public object cariN11Id { get; set; }
        public object resimYolu { get; set; }
        public int personelMi { get; set; }
        public string seciliPketiketi { get; set; }
        public string cariaciklama { get; set; }
        public string varsayilanKasa { get; set; }
        public int varsayilanVadeGunu { get; set; }
        public object aciklama { get; set; }
        public string faturaUlke { get; set; }
        public List<object> fatura { get; set; }
        public List<object> hizlisatisayar { get; set; }
        public List<object> taksitIsl { get; set; }
        public List<object> tmpFatura { get; set; }
        public object cariIsl { get; set; }
        public List<object> cariKartEticaret { get; set; }
        public List<object> cariKodlar { get; set; }
        public List<object> cariNot { get; set; }
        public List<object> bankaIsl { get; set; }
        public List<object> cariAdresler { get; set; }
        public List<object> cariBanka { get; set; }
        public List<object> taksit { get; set; }
        public List<object> kasalarIsl { get; set; }
    }

    public class RootCariKartlar
    {
        public List<DatumRootCariKartlar> data { get; set; }
        public int totalCount { get; set; }
        public bool success { get; set; }
        public object message { get; set; }
        public object code { get; set; }
    }


}
