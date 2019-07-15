using Microsoft.EntityFrameworkCore;
using Roadway.Data.Contexts;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Roadway.Infrastructure.Pagination;

namespace Roadway.Data.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected BaseRepository(
            RoadwayContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        private RoadwayContext Context { get; }

        /// <summary>
        /// When is override in a deriver type, returns all the elements in the entity set.
        /// </summary>
        /// <returns>
        /// An <see cref="IQueryable"/> for all the elements in the entity set
        /// </returns>
        public IQueryable<TEntity> All() {

            return Context.Set<TEntity>();
        }
        
        public IQueryable<TEntity> All(int? page, int? size) {

            return Context.Set<TEntity>().Page(page ?? 0, size ?? 10);
        }


        /// <summary>
        /// Filters an entity set of values based on a predicate.
        /// </summary>
        /// <param name="predicate">
        ///     An expression to test each element for a condition.
        /// </param>
        /// <returns>
        /// An <see cref="IQueryable"/> that contains elements from the input sequence that satisfy the condition specified by predicate.
        /// </returns>
        public IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return All().Where(predicate);
        }

        /// <summary>
        /// Returns the first element of a sequence.
        /// </summary>
        /// <param name="predicate">
        /// An expression to return the first element of a condition.
        /// </param>
        /// <returns>
        /// The first element that satisfies the condition.
        /// </returns>
        public async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Filter(predicate).FirstAsync();
        }

        /// <summary>
        /// /// Search entities in asynchronous way.
        /// </summary>
        /// <param name="keys">Entity identifier.</param>
        /// <returns>A task of the entity.</returns>
        public async Task<TEntity> FindAsync(params object[] keys)
        {
            return await ((DbSet<TEntity>)All()).FindAsync(keys);
        }


        /// <summary>
        /// Returns the first element of the entity set with the specified condition, or a default value if the entity set contains no elements.
        /// </summary>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <returns>
        /// default value, if the source is empty; otherwise, the first element in source.
        /// </returns>
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await All().FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Marks the entity as added
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The entity with its state marked as added.
        /// </returns>
        public async Task<TEntity> Create(TEntity entity)
        {
            var entry = Context.Entry(entity);
            entry.State = EntityState.Added;
            await SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Marks the entity as modified.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        /// The entity with its state marked as modified.
        /// </returns>
        public async Task Update(TEntity entity)
        {
            var entry = Context.Entry(entity);
            entry.State = EntityState.Modified;
            await SaveChangesAsync();
        }

        /// <summary>
        /// Marks the entity as deleted.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        /// The entity with its state marked as deleted.
        /// </returns>
        public async Task Delete(TEntity entity)
        {
            var entry = Context.Entry(entity);
            entry.State = EntityState.Deleted;
            await SaveChangesAsync();
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}
