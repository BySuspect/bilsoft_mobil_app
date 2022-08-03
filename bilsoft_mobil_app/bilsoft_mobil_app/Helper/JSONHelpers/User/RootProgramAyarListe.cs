using System;
using System.Collections.Generic;
using System.Text;

namespace bilsoft_mobil_app.Helper.JSONHelpers.User
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class DatumProgramAyarListe
    {
        public string AyarAdi { get; set; }
        public string AyarDeger { get; set; }
    }

    public class RootProgramAyarListe
    {
        public List<DatumProgramAyarListe> data { get; set; }
    }


}
