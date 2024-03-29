﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace bilsoft_mobil_app.Helper.API
{
    /* Demo Auth Data
     {
        "vergiNumarasi": "12345",
        "kullaniciAd": "demo",
        "kullaniciSifre": "demo",
        "veritabaniAd": "12345",
        "donemYil": "2022",
        "subeAd": "merkez",
        "apiKullaniciAdi": "bilsoft",
        "apiKullaniciSifre": "1234"
     }
     */

    public class APIHelper
    {
        public const string url = "https://apiv3.bilsoft.com/";
        public const string loginDonemGetirAPI = url + "api/Auth/GirisYapDonemGetir";
        public const string tokeApi = url + "api/Auth/GirisYap";

        public static class AjandaApiler
        {
            //Ajanda veriler
            public const string AjandaApi = "api/Ajanda";
            public const string AjandaNotlarApi = "api/AjandaNotlar";
        }

        public static class CariApiler
        {
            //Cari veriler
            public const string CariAdresApi = "api/CariAdresler";
            public const string CariBankaApi = "api/CariBanka";
            public const string CariGrupApi = "api/CariGrup";
            public const string CariIslApi = "api/CariIsl";
            public const string CariKartApi = "api/CariKart";
        }

        public static class UserApiVeriler
        {
            public const string UserApi = "api/User";
        }
        public static string loginData { get; set; }
        public static string loginMod { get; set; } = "demo";
        public static string loginToken { get; set; }
        public static string vergiNo { get; set; }
        public static string kullaniciAdi { get; set; }
        public static string kullaniciSifre { get; set; }
        public DateTime TokenBitisTime { get; set; } = new DateTime();
        public static string veritabaniAd { get; set; }
        public static string subeAd { get; set; }
        public static string apiKullaniciAdi = "bilsoft";
        public static string apiKullaniciSifre = "1234";
        public static List<string> logindonemYil { get; set; } = new List<string>();
        public static string secilenlogindonemYil { get; set; }
        public static string SonAcilanSayfa { get; set; }

        public static class apiTypes
        {
            public static string getall = "/getall";
            public static string getbyid = "/getbyid";
            public static string add = "/add";
            public static string addrange = "/addrange";
            public static string update = "/update";
            public static string updaterange = "/updaterange";
            public static string delete = "/delete";
            public static string deletebyid = "/deletebyid";
            public static string deleterange = "/deleterange";
        }
    }
}
