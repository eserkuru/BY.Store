using BY.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BY.Store.Infrastructure.DataAccess.Internal.EntityFrameworkCore.Contexts
{
    public class InMemoryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDb");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
    }
}
