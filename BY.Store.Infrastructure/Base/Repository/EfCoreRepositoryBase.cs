using BY.Store.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BY.Store.Infrastructure.Base.Repository
{
    /// <summary>
    /// Entity Framework is the class in which the ORM tool is included as a generic.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TContext"></typeparam>
    public class EfEntityReporsitoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        #region Queries

        /// <summary>
        /// Returns a single record of the given entity from the database using entity framework core.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IQueryable<TEntity>> Get(Expression<Func<TEntity, bool>> filter)
        {
            //using (var context = new TContext()) // InMemoryDb ile çalışma nedeniyle kapalı.
            var context = new TContext();
            return await Task.FromResult(context.Set<TEntity>().Where(filter).AsQueryable());
        }

        /// <summary>
        /// Returns the list record of the given entity from the database using entity framework core.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IQueryable<TEntity>> GetList(Expression<Func<TEntity, bool>>? filter = null)
        {
            //using (var context = new TContext()) // InMemoryDb ile çalışma nedeniyle kapalı.
            var context = new TContext();
            return await Task.FromResult(filter == null
                ? context.Set<TEntity>().AsQueryable()
                : context.Set<TEntity>().Where(filter).AsQueryable());
        }
        #endregion

        #region Commands

        /// <summary>
        /// Adds the given entity to the database using entity framework core.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<TEntity> Add(TEntity entity)
        {
            //using (var context = new TContext()) // InMemoryDb ile çalışma nedeniyle kapalı.
            var context = new TContext();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChangesAsync();

            return Task.FromResult(entity);
        }


        /// <summary>
        /// Removes the given entity from the database using entity framework core.
        /// </summary>
        /// <param name="entity"></param>
        public Task<TEntity> Delete(TEntity entity)
        {
            //using (var context = new TContext()) // InMemoryDb ile çalışma nedeniyle kapalı.
            var context = new TContext();
            var removedEntity = context.Entry(entity);
            removedEntity.State = EntityState.Deleted;
            context.SaveChangesAsync();

            return Task.FromResult(entity);
        }

        /// <summary>
        /// Updates the given entity in the database using entity framework core.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<TEntity> Update(TEntity entity)
        {
            //using (var context = new TContext()) // InMemoryDb ile çalışma nedeniyle kapalı.
            var context = new TContext();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChangesAsync();

            return Task.FromResult(entity);
        }
    }

    #endregion
}
