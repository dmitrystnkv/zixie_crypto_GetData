using Nancy.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zixie_crypto_GetData
{
    public class GetSymbols
    {
        public static async Task<string>? Sb()
        {
            var client = new RestClient("https://api.diadata.org/v1/symbols");
            var request = new RestRequest("https://api.diadata.org/v1/symbols", Method.Get);
            request.AddHeader("Content-Type", "application/json");
            var sb = client.ExecuteAsync(request).Result.Content;
            return sb;
        }
    }
}
