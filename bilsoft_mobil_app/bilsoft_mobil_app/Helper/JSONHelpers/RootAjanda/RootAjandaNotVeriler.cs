using System;
using System.Collections.Generic;
using System.Text;

namespace bilsoft_mobil_app.Helper.JSONHelpers.RootAjanda
{
    // var myDeserializedClass = JsonConvert.DeserializeObject<RootAjandaNotVeriler>(myJsonResponse);
    public class AjandaNotVerilerDatum
    {
        public int id { get; set; }
        public string ajandaId { get; set; }
        public string notlar { get; set; }
    }

    public class RootAjandaNotVeriler
    {
        public List<AjandaNotVerilerDatum> data { get; set; }
        public int totalCount { get; set; }
        public bool success { get; set; }
        public object message { get; set; }
        public object code { get; set; }
    }

}
