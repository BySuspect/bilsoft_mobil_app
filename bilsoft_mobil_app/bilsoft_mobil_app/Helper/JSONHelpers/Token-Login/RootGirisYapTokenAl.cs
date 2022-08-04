using System;
using System.Collections.Generic;
using System.Text;

namespace bilsoft_mobil_app.Helper.JSONHelpers
{

    public class Datatoken
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
        public string subeAd { get; set; }
        public string donemYil { get; set; }
    }

    public class RootGirisYapTokenAl
    {
        public Datatoken data { get; set; }
        public int totalCount { get; set; }
        public bool success { get; set; }
        public object message { get; set; }
        public object code { get; set; }
    }
}
