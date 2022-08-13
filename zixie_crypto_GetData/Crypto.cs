using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zixie_crypto_GetData
{
    public class Crypto
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Blockchain { get; set; }
        public float Price { get; set; }
        public float PriceYesterday { get; set; }
        public float VolumeYesterdayUSD { get; set; }
        public DateTime Time { get; set; }
        public string Source { get; set; }
    }
}
