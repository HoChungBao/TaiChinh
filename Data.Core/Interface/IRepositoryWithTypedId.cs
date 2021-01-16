using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Core
{
    //T: Kiểu để truyền vào hoặc trả về dymamic
    //TId: Kiểu truyền vào của implement interface
    public interface IRepositoryWithTypedId<T,TContext>
        where T: class
       where TContext : DbContext
    {
        IQueryable<T> Query();

        void Add(T entity);
        Task AddAsync(T entity);

        void AddRange(IEnumerable<T> entity);
        Task AddRangeAsync(IEnumerable<T> entity);

        IDbContextTransaction BeginTransaction();

        void SaveChanges();

        Task SaveChangesAsync();

        void Remove(T entity);
        Task<List<T>> GetAllAsync();
    }
}
