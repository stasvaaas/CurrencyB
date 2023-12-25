using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace CurrencyB
{
    internal class CurrencyDbContext :DbContext
    {
        public DbSet<Currency> Currencies { get; set; }
        public string DbPath { get; }

        public CurrencyDbContext()
        {
            //this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data source=currencies.db");
            base.OnConfiguring(options);
        }
    }
}
