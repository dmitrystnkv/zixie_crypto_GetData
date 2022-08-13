using System.Text;
using Nancy.Json;
using RestSharp;

namespace zixie_crypto_GetData
{
    public class GetQuotation
    {
        public static Crypto cr(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            var r = client.Execute(request).Content;
            var Content = new StringContent(r.ToString(), Encoding.UTF8, "application/json");
            JavaScriptSerializer js = new JavaScriptSerializer();
            Crypto cr = js.Deserialize<Crypto>(r);
            return cr;
        }
    }

}





