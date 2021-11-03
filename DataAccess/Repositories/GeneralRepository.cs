using DataAccess.Interfaces;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace DataAccess.Repositories
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        private readonly DbSet<T> _table = null;
        private readonly MasterContext _masterContext;

        public GeneralRepository(MasterContext masterContext)
        {
            _masterContext = masterContext;
            _table = _masterContext.Set<T>();
        }

        public async Task InsertAsync(T model, CancellationToken token)
        {
            await _table.AddAsync(model, token);
            await _masterContext.SaveChangesAsync(token);
        }

        public async Task RemoveAsync(T model, CancellationToken token)
        {
            _table.Remove(model);
            await _masterContext.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(T model, CancellationToken token)
        {
            _table.Update(model);
            await _masterContext.SaveChangesAsync(token);
        }

        public async Task<List<T>> GetAllAsync(CancellationToken token)
        {
            return await _table.ToListAsync(token);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> condition,
            CancellationToken token)
        {
            return await _table.Where(condition).ToListAsync(token);
        }

        public async Task<List<T>> GetAllAsync<TKey>(
            Expression<Func<T, bool>> condition,
            Expression<Func<T, TKey>> orderBy,
            CancellationToken token
        )
        {
            return await _table.Where(condition).OrderBy(orderBy).ToListAsync(token);
        }

        public async Task<List<T>> GetAllIncludeAsync<TKey>(
            Expression<Func<T, bool>> condition,
            Expression<Func<T, TKey>> include,
            CancellationToken token
        )
        {
            return await _table
                .Where(condition)
                .Include(include)
                .ToListAsync(token);
        }

        public async Task<T> GetOneAsync(Expression<Func<T, bool>> condition,
            CancellationToken token)
        {
            return await _table.Where(condition).FirstOrDefaultAsync(token);
        }

        public async Task<double?> AverageAsync(
            Expression<Func<T, bool>> condition,
            Expression<Func<T, int?>> selector,
            CancellationToken token
        )
        {
            return await _table.Where(condition).AverageAsync(selector, token);
        }

        public void DetachEntity(T model)
        {
            _masterContext.Entry(model).State = EntityState.Detached;
        }
    }
}