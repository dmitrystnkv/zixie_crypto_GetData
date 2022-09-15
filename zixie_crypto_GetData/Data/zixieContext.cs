#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace zixie.Data
{
    public partial class zixieContext : DbContext
    {
        public zixieContext()
        {
        }

        public zixieContext(DbContextOptions<zixieContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=zixie;Trusted_Connection=True;");
            }
        }
        public DbSet<zixie_crypto_GetData.Crypto> Crypto { get; set; }
        public DbSet<zixie_crypto_GetData.Exchange> Exchange { get; set; }
        public DbSet<zixie_crypto_GetData.Symbol> Symbol { get; set; }
        public DbSet<zixie_crypto_GetData.BlackListSymbols> BlackListSymbols { get; set; }
    }
}
