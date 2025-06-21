using TuChambaPe.Shared.Domain.Repositories;
using System;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TuChambaPe.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext Context;

        /// <summary>
        ///     Default constructor for the base repository
        /// </summary>
        protected BaseRepository(AppDbContext context)
        {
            Context = context;
        }

        // inheritedDoc
        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        // inheritedDoc
        public async Task<TEntity?> FindByUidAsync(Guid uid)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var property = Expression.Property(parameter, "Uid");
            var equal = Expression.Equal(property, Expression.Constant(uid));
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equal, parameter);
            
            return await Context.Set<TEntity>().FirstOrDefaultAsync(lambda);
        }

        // inheritedDoc
        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        // inheritedDoc
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        // inheritedDoc
        public async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }
    }
}
