using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Core.Data
{
    public class RepositoryWithTypedId<T, TContext> : IRepositoryWithTypedId<T, TContext>
        where T : class
        where TContext : DbContext
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _table;
        public RepositoryWithTypedId(TContext context)
        {
            _context =context;
            _table = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _table.Add(entity);
            SaveChanges();
        }

        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
            await SaveChangesAsync();
        }

        public void AddRange(IEnumerable<T> entity)
        {
            _table.AddRange(entity);
            SaveChanges();
        }

        public async Task AddRangeAsync(IEnumerable<T> entity)
        {
            await _table.AddRangeAsync(entity);
            await SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _table.ToListAsync();
        }
        public IQueryable<T> Query()
        {
            return _table;
        }

        public void Remove(T entity)
        {
            _table.Remove(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
