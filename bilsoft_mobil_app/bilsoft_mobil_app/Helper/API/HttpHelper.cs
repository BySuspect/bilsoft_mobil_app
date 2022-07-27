using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace bilsoft_mobil_app.Helper.API
{
    public class HttpHelper
    {

        public async Task<APIResponse> callAPI(string url, string json)
        {
            APIResponse res = new APIResponse();
            try
            {
                string content = string.Empty;
                var httpClient = new HttpClient();
                HttpResponseMessage httpResponse = null;
                if (string.IsNullOrWhiteSpace(json))
                {
                    httpResponse = await httpClient.GetAsync(url);
                }
                else
                {
                    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                    httpResponse = await httpClient.PostAsync(url, httpContent);

                }

                if (httpResponse.IsSuccessStatusCode)
                {
                    content = await httpResponse.Content.ReadAsStringAsync();
                    APIHelper.loginData = content;
                    res.data = content;

                }
                else
                {
                    content = await httpResponse.Content.ReadAsStringAsync();
                    res.data = content;
                }

                return res;
            }
            catch
            {
                res.data = "ERROR";
                return res;
            }
        }

    }
}