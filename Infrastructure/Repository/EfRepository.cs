using ApplicationCore.SeedWork;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    /// <summary>
    /// RepositoryBase<T> implements <see cref="IRepositoryBase<T>"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EfRepository<T> : IEfRepository<T> where T : Entity
    {
        protected readonly CardContext _context;
        private readonly DbSet<T> dbSet;

        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="context"></param>
        public EfRepository(CardContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        /// <inheritdoc/>
        public async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyList<T>> FindAsync()
        {
            List<T> getAsyncList = await dbSet.ToListAsync<T>();
            return getAsyncList;
        }

        public virtual Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(dbSet.AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var queryableResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return Task.FromResult(
                (IReadOnlyList<T>)queryableResult
                    .Where(spec.Criteria)
                    .ToList()
                    .AsReadOnly());
        }

        /// <inheritdoc/>
        public async Task<T> FindByIdAsync(Guid id)
        {
            T getAsync = await dbSet.FindAsync(id);
            return getAsync;
        }

        /// <inheritdoc/>
        public async Task<T> UpdateAsync(T entity)
        {
            EntityEntry<T> updated = dbSet.Update(entity);
            T getUpdated = await FindByIdAsync(updated.Entity.Id);
            return getUpdated;
        }

        /// <inheritdoc/>
        public async void DeleteAsync(Guid id)
        {
            T getDeleted = await FindByIdAsync(id);
            dbSet.Remove(getDeleted);
        }
    }
}

