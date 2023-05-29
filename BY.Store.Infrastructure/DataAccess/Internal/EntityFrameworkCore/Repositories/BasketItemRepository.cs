using BY.Store.Domain.Entities;
using BY.Store.Infrastructure.Base.Repository;
using BY.Store.Infrastructure.DataAccess.Interfaces;
using BY.Store.Infrastructure.DataAccess.Internal.EntityFrameworkCore.Contexts;

namespace BY.Store.Infrastructure.DataAccess.Internal.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Contains custom operations to be used to access basket tables.
    /// </summary>
    public class BasketItemRepository : EfEntityReporsitoryBase<BasketItem,InMemoryDbContext>, IBasketItemRepository
    {
    }
}