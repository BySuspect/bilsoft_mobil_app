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
        public static string loginData;
        public static string loginToken;
        public static string vergiNo;
        public static string kullaniciAdi;
        public static string kullaniciSifre;
        public static int totalCount;
        public static string veritabaniAd;
        public static string subeAd = "bilsoft";
        public static string apiKullaniciAdi = "bilsoft";
        public static string apiKullaniciSifre = "1234";
        public static List<String> logindonemYil = new List<string>();
    }
}
