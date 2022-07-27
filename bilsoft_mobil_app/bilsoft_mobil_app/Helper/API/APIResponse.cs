using System;
using System.Collections.Generic;
using System.Text;

namespace bilsoft_mobil_app.Helper.API
{
    public class APIResponse
    {
        public object data { get; set; }
        public string message { get; set; }
        public string code { get; set; }
        public bool success { get; set; }
        public int totalCount { get; set; }
    }
}