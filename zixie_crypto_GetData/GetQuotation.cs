using System.Text;
using Nancy.Json;
using Newtonsoft.Json;
using RestSharp;

namespace zixie_crypto_GetData
{
    public class GetQuotation
    {
        //var task1 = 
        public static async Task<Crypto> cr(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            var r = client.ExecuteAsync(request).Result.Content;
            if (r is not null)
            {
                var Content = new StringContent(r.ToString(), Encoding.UTF8, "application/json");
                JavaScriptSerializer js = new JavaScriptSerializer();
                Crypto cr = js.Deserialize<Crypto>(r);
                return cr;
            }
            else
            {
                Crypto cr = new Crypto();
                cr.Name = "null";
                return cr;
            }
            
        }
    }

}





