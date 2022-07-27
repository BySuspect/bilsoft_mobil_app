using System;
using System.Collections.Generic;
using System.Text;

namespace bilsoft_mobil_app.Helper.JSONHelpers
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Datagiris
    {
        public List<FirmaVeritabaniDTO> firmaVeritabaniDTO { get; set; }
    }

    public class FirmaVeritabaniDonemDTO
    {
        public string donemYil { get; set; }
    }

    public class FirmaVeritabaniDTO
    {
        public string veritabaniAd { get; set; }
        public List<FirmaVeritabaniDonemDTO> firmaVeritabaniDonemDTO { get; set; }
    }

    public class RootGirisYapDonemGetir
    {
        public Datagiris data { get; set; }
        public int totalCount { get; set; }
        public bool success { get; set; }
        public object message { get; set; }
        public object code { get; set; }
    }


}
