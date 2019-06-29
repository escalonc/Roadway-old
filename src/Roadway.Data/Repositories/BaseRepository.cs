﻿using Microsoft.EntityFrameworkCore;
using Roadway.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
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
        protected RoadwayContext Context { get; set; }

        /// <summary>
        /// When is override in a deriver type, returns all the elements in the entity set.
        /// </summary>
        /// <returns>
        /// An <see cref="IQueryable"/> for all the elements in the entity set
        /// </returns>
        public virtual IQueryable<TEntity> All() {

            return Context.Set<TEntity>();
        }
        
        public virtual IQueryable<TEntity> All(int page, int size) {

            return Context.Set<TEntity>().Page(page, size);
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
        public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return All().Where(predicate);
        }

        /// <summary>
        /// Projects each element of a sequence into a new form.
        /// </summary>
        /// <param name="predicate">
        /// A sequence of values to project.
        /// </param>
        /// <typeparam name="TResult">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// An <see cref="IQueryable"/> whose elements are the result of invoking a projection function on each element of source.
        /// </returns>
        public virtual IQueryable<TResult> Project<TResult>(Expression<Func<TEntity, TResult>> predicate)
        {
            return All().Select(predicate);
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
        public virtual async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Filter(predicate).FirstAsync();
        }

        /// <summary>
        /// /// Search entities in asynchronous way.
        /// </summary>
        /// <param name="keys">Entity identifier.</param>
        /// <returns>A task of the entity.</returns>
        public virtual async Task<TEntity> FindAsync(params object[] keys)
        {
            return await FindAsync(CancellationToken.None, keys);
        }

        /// <summary>
        /// Search entities in asynchronous way.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="keys">Entity identifier.</param>
        /// <returns>A task of the entity.</returns>
        public virtual async Task<TEntity> FindAsync(CancellationToken token, params object[] keys) =>
            await ((DbSet<TEntity>)All()).FindAsync(token, keys);

        /// <summary>
        /// Returns the first element of the entity set with the specified condition, or a default value if the entity set contains no elements.
        /// </summary>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <returns>
        /// default value, if the source is empty; otherwise, the first element in source.
        /// </returns>
        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
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
        public virtual async Task Create(TEntity entity)
        {
            var entry = Context.Entry(entity);
            entry.State = EntityState.Added;
            await SaveChangesAsync();
        }

        /// <summary>
        /// Marks the entity as modified.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The entity with its state marked as modified.
        /// </returns>
        public virtual async Task Update(TEntity entity)
        {
            var entry = Context.Entry(entity);
            entry.State = EntityState.Modified;
            await SaveChangesAsync();
        }

        /// <summary>
        /// Marks the entity as deleted.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The entity with its state marked as deleted.
        /// </returns>
        public virtual async Task Delete(TEntity entity)
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
        public virtual Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}
