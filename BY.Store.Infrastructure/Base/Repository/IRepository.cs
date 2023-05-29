using BY.Store.Domain.Interfaces;
using System.Linq.Expressions;

namespace BY.Store.Infrastructure.Base.Repository
{
    /// <summary>
    /// Represents the class to allow processing of database records.
    /// </summary>
    public interface IRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Returns a single record of the given entity from the database.
        /// </summary>
        Task<IQueryable<T>> Get(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Returns the list record of the given entity from the database.
        /// </summary>
        Task<IQueryable<T>> GetList(Expression<Func<T, bool>>? filter = null);

        /// <summary>
        /// Adds the given entity to the database.
        /// </summary>
        Task<T> Add(T entity);

        /// <summary>
        /// Updates the given entity in the database.
        /// </summary>
        Task<T> Update(T entity);

        /// <summary>
        /// Removes the given entity from the database.
        /// </summary>
        Task<T> Delete(T entity);
    }
}
