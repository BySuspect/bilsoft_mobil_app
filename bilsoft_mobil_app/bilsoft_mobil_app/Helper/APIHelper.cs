using System;
using System.Collections.Generic;
using System.Text;

namespace bilsoft_mobil_app.Helper
{
    public class APIHelper
    {
        public static string url = "https://apiv3.bilsoft.com/";
        public static string loginDonemGetirAPI = url + "api/Auth/GirisYapDonemGetir";
        public static string tokeApi = url + "api/Auth/GirisYap";
        public static string loginData { get; set; }
        public static string loginMod { get; set; } = "demo";
        public static string loginToken { get; set; }
        public static string vergiNo { get; set; }
        public static string kullaniciAdi { get; set; }
        public static string kullaniciSifre { get; set; }
        public static int totalCount { get; set; }
        public static string veritabaniAd { get; set; }
        public static string subeAd = "bilsoft";
        public static string apiKullaniciAdi = "bilsoft";
        public static string apiKullaniciSifre = "1234";
        public static List<String> logindonemYil { get; set; } = new List<string>();
}
}
