using System;
using System.Collections.Generic;
using System.Text;

namespace bilsoft_mobil_app.TestArea
{
    // RootTest data = JsonConvert.DeserializeObject<RootTest>(res);
    public class Datum
    {
        public int id { get; set; }
        public string adi { get; set; }
        public string frx { get; set; }
    }

    public class RootTest
    {
        public List<Datum> data { get; set; }
        public int totalCount { get; set; }
        public bool success { get; set; }
        public object message { get; set; }
        public object code { get; set; }
    }
}
