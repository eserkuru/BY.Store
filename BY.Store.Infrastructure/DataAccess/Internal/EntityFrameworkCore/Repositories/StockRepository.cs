using BY.Store.Domain.Entities;
using BY.Store.Infrastructure.Base.Repository;
using BY.Store.Infrastructure.DataAccess.Interfaces;
using BY.Store.Infrastructure.DataAccess.Internal.EntityFrameworkCore.Contexts;

namespace BY.Store.Infrastructure.DataAccess.Internal.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Contains custom operations to be used to access product tables.
    /// </summary>
    public class StockRepository : EfEntityReporsitoryBase<Stock, InMemoryDbContext>, IStockRepository
    {
        public IQueryable<Stock> GetAll()
        {
            return new List<Stock>
            {
                new Stock{ Id=1, ProductId = 1, Quantity = 10},
                new Stock{ Id=2, ProductId = 2, Quantity = 6},
                new Stock{ Id=3, ProductId = 3, Quantity = 3},
            }.AsQueryable();
        }
    }
}