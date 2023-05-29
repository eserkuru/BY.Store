using BY.Store.Domain.Entities;
using BY.Store.Infrastructure.Base.Repository;
using BY.Store.Infrastructure.DataAccess.Interfaces;
using BY.Store.Infrastructure.DataAccess.Internal.EntityFrameworkCore.Contexts;

namespace BY.Store.Infrastructure.DataAccess.Internal.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Contains custom operations to be used to access product tables.
    /// </summary>
    public class ProductRepository : EfEntityReporsitoryBase<Product, InMemoryDbContext>, IProductRepository
    {
        public IQueryable<Product> GetAll()
        {
            return new List<Product>
            {
                new Product{ Id=1, Name = "Pantolon", Price = 499.99 },
                new Product{ Id=2, Name = "Ceket", Price = 1299.99 },
                new Product{ Id=3, Name = "Mont", Price = 3899.99 },
            }.AsQueryable();
        }
    }
}