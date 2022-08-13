using Nancy.Json;
using RestSharp;
using System.Text;
using zixie_crypto_GetData;

Exchange[] ex = new Exchange[1];

ex = Exchanges.ex();

foreach (Exchange items in ex)
{
    Console.WriteLine($"Exchange name: {items.Name}");
}


var client = new RestClient("https://api.diadata.org/v1/symbols");
var request = new RestRequest("https://api.diadata.org/v1/symbols", Method.Get);
request.AddHeader("Content-Type", "application/json");
var d = client.Execute(request).Content;

string str = d;
string[] mystring = str.Split(',');
Crypto cr = new Crypto();
foreach (var item in mystring)
{
  
        var resp = item.Replace("\"", "").Replace("[", "").Replace("]", "");
    var url = "https://api.diadata.org/v1/quotation/"+ resp;
    cr.Name = GetQuotation.cr(url).Name;
    cr.Symbol = GetQuotation.cr(url).Symbol;
    cr.Price = GetQuotation.cr(url).Price;

    Console.WriteLine($"Name: {cr.Name}");
    Console.WriteLine($"Symbol: {cr.Symbol}");
    Console.WriteLine($"Price: {cr.Price}");
    Thread.Sleep(1000);
}
