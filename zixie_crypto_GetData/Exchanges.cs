using Nancy.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zixie_crypto_GetData
{
    public class Exchanges
    {
        public static Exchange[] ex()
        {
            var client = new RestClient("https://api.diadata.org/v1/exchanges");
            var request = new RestRequest("https://api.diadata.org/v1/exchanges", Method.Get);
            request.AddHeader("Content-Type", "application/json");
            var r = client.Execute(request).Content;
            var Content = new StringContent(r.ToString(), Encoding.UTF8, "application/json");
            JavaScriptSerializer js = new JavaScriptSerializer();
            Exchange[] ex = js.Deserialize<Exchange[]>(r);
            return ex;
        }
    }
}
