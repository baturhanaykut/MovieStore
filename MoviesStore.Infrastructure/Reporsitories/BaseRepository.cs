using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using MovieStore_Domain.Entities;
using MovieStore_Domain.Repository;
using MovieStore_Infrastructure.ApllicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Infrastructure.Reporsitories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {

        private readonly ApplicationDbContext _context;
        protected DbSet<TEntity> _table;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        public async Task<bool> Add(TEntity entity)
        {
            await _table.AddAsync(entity);
            return await Save() > 0;
        }

        public async Task<bool> Any(Expression<Func<TEntity, bool>> expression)
        {
            return await _table.AnyAsync(expression);
        }

        public async Task<bool> Delete(TEntity entity)
        {
            return await Save() > 0;
        }
              
       
        public async Task<TEntity> GetDefault(Expression<Func<TEntity, bool>> expression)
        {
            return await _table.FirstOrDefaultAsync(expression);
        }

        public async Task<List<TEntity>> GetDefaults(Expression<Func<TEntity, bool>> expression)
        {
            return await _table.Where(expression).ToListAsync();
        }

        public async Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _table; // Select * from Post

            if (where is not null)
            {
                query = query.Where(where);  // Select * from Post where GenreId=3
            }
            if (include is not null)
            {
                query = include(query);
            }
            if (orderBy is not null)
            {
                return await orderBy(query).Select(select).FirstOrDefaultAsync();
            }
            else
                return await query.Select(select).FirstOrDefaultAsync();
        }

        public async Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _table;
            if (where is not null)
            {
                query = query.Where(where);
            }
            if (include is not null)
            {
                query = include(query);
            }
            if (orderBy is not null)
            {
                return await orderBy(query).Select(select).ToListAsync();
            }
            else
                return await query.Select(select).ToListAsync();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State=EntityState.Modified;
            return await Save() > 0;
        }
    }
}
