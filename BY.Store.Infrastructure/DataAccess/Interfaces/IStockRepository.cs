using BY.Store.Domain.Entities;
using BY.Store.Infrastructure.Base.Repository;

namespace BY.Store.Infrastructure.DataAccess.Interfaces
{
    /// <summary>
    /// Contains custom operations to be used to access stock tables.
    /// </summary>
    public interface IStockRepository : IRepository<Stock>
    {
        IQueryable<Stock> GetAll();
    }
}
