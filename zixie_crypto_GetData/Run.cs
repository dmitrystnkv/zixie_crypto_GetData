using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using zixie.Data;

namespace zixie_crypto_GetData
{
    public class Run
    {
        public void RunAll()
        {
         
            using (zixieContext db = new zixieContext())
            {
                Exchange[] ex = new Exchange[1];
                //db.Crypto.ExecuteSqlCommand("");
                ex = Exchanges.ex();
                
                foreach (Exchange items in ex)
                {
                    Console.WriteLine($"Exchange name: {items.Name}");
                }


                //GetSymbols gs = new GetSymbols();

                string str = GetSymbols.Sb().Result;
                var mystring = str.Split(',');
                var blacklist = (from s in db.BlackListSymbols select new string[] { s.Name });
                List<string> newstr = new List<string>();
                List<string> symb = new List<string>();
                for(int s=0;s<mystring.Length;s++) 
                {
                    //Console.WriteLine(mystring[s].Replace("\"", "").Replace("[", "").Replace("]", ""));
                    mystring[s] = mystring[s].Replace("\"", "").Replace("[", "").Replace("]", "");
                }
                //foreach(var item in symb)
                //{
                //    Console.WriteLine(item);
                //}
                int i = 0;
                foreach(var item in blacklist)
                {
                    newstr.Add(item.FirstOrDefault());
                    i++;
                }
                //foreach(var item in newstr)
                //{
                //    Console.WriteLine($"BlackList: {item}");
                //}
                var mystring1 = mystring.Except(newstr);
                //var a = newstr;
                //var b = symb;
                //a.Except(b);
                //foreach (var item in mystring)
                //{
                //    Console.WriteLine($"mystring: {item}");
                //}
                //Console.ReadLine();
                
                foreach (var item in mystring1)
                {
                    if (item.Length > 0)
                    {
                        var resp = item.Replace("\"", "").Replace("[", "").Replace("]", "");
                        var r = Regex.IsMatch(resp, @"^[a-zA-Z0-9]+$");
                        if (r)
                        {   
                            
                            Console.WriteLine("");
                            Console.WriteLine($"resp: '{resp}', '{resp.Length}'");
                            Console.WriteLine("");
                            var url = "https://api.diadata.org/v1/quotation/" + resp;
                            Crypto cr = new Crypto();
                            cr.Id = null;
                            Crypto cr_get = new Crypto();
                            cr_get = GetQuotation.cr(url).Result;
                            
                            
                            if (cr_get.Name is not null && cr_get.Name != "null")
                            {
                                cr.Symbol = cr_get.Symbol;
                                cr.Name = cr_get.Name;
                                cr.Address = cr_get.Address;
                                cr.Blockchain = cr_get.Blockchain;
                                cr.Price = cr_get.Price;
                                cr.PriceYesterday = cr_get.PriceYesterday;
                                cr.VolumeYesterdayUSD = cr_get.VolumeYesterdayUSD;
                                cr.Time = DateTime.Now.ToString();
                                cr.Source = cr_get.Source;
                                    Console.WriteLine($"Symbol: {cr.Symbol}");
                                    Console.WriteLine($"Name: {cr.Name}");
                                    Console.WriteLine($"Address: {cr.Address}");
                                    Console.WriteLine($"Blockchain: {cr.Blockchain}");
                                    Console.WriteLine($"Price: {cr.Price}");
                                    Console.WriteLine($"PriceYesterday: {cr.PriceYesterday}");
                                    Console.WriteLine($"VolumeYesterdayUSD: {cr.VolumeYesterdayUSD}");
                                    Console.WriteLine($"Time: {cr.Time}");
                                    Console.WriteLine($"Name: {cr.Name}");
                                    Console.WriteLine($"Source: {cr.Source}");
                                //Thread.Sleep(100);
                                //db.ExecuteStoreCommand("SET IDENTITY_INSERT [dbo].[MyUser] ON");
                                db.Crypto.AddRange(cr);
                                    db.SaveChanges();
                                }
                            else
                            {
                                Console.WriteLine($"RESP: {resp}");

                                BlackListSymbols bl = new BlackListSymbols();
                                bl.Name = resp;
                                //Console.WriteLine(cr.Id);
                                db.BlackListSymbols.Add(bl);
                                db.SaveChanges();
                                Console.WriteLine($"Blacklist added: {resp}");

                            }

                        }
                        else
                        {
                            Console.WriteLine($"RESP: {resp}");
                            
                                BlackListSymbols bl = new BlackListSymbols();
                                bl.Name = resp;
                                //Console.WriteLine(cr.Id);
                                db.BlackListSymbols.Add(bl);
                                db.SaveChanges();
                                Console.WriteLine($"Blacklist added: {resp}");
                            
                        }
                        }
                    }
                
            }
            RunAll();
            }
        }
}
