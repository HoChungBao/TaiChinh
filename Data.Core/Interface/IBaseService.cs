using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Core
{
    public interface IBaseService<T,TId> where T : class where TId: struct
    {
        void Add(T entity);
        Task AddAsync(T entity);

        void AddRange(IEnumerable<T> entity);
        Task AddRangeAsync(IEnumerable<T> entity);

        void Remove(T entity);
        Task<List<T>> GetAllAsync();

        Task<T> GetIdAsync(TId id);
        T GetId(TId id);
        Task<PagingList<T>> GetPagingList(int page, int pageSize, string search);
    }
}
