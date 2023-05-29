using BY.Store.Domain.Entities;
using BY.Store.Infrastructure.Base.Repository;

namespace BY.Store.Infrastructure.DataAccess.Interfaces
{
    /// <summary>
    /// Contains custom operations to be used to access product tables.
    /// </summary>
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<Product> GetAll();
    }
}
