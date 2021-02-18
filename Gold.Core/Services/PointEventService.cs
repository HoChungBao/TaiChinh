using Data.Core;
using Gold.Core.Entities;
using Gold.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold.Core.Services
{
    public class PointEventService : IPointEventService
    {
        public readonly IRepositoryWithTypedId<PointEvent, GoldContext> _repository;
        public PointEventService(IRepositoryWithTypedId<PointEvent, GoldContext> repository)
        {
            _repository = repository;
        }
        public void Add(PointEvent entity)
        {
            _repository.Add(entity);
        }

        public async Task AddAsync(PointEvent entity)
        {
            await _repository.AddAsync(entity);
        }

        public void AddRange(IEnumerable<PointEvent> entity)
        {
            _repository.AddRange(entity);
        }

        public async Task AddRangeAsync(IEnumerable<PointEvent> entity)
        {
            await _repository.AddRangeAsync(entity);
        }

        public Task<List<PointEvent>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public PointEvent GetId(long id)
        {
            return _repository.Query().FirstOrDefault(x=>x.Id==id);
        }

        public Task<PointEvent> GetIdAsync(long id)
        {
            return _repository.Query().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagingList<PointEvent>> GetPagingList(int page, int pageSize, string search)
        {
            var data = _repository.Query()
                 .Where(x => string.IsNullOrEmpty(search) || x.Name.Contains(search))
                 .OrderBy(x=>x.Point);

            return await PagingList.CreateAsync<PointEvent>(data, pageSize, page);
        }

        public void Remove(PointEvent entity)
        {
            throw new NotImplementedException();
        }
    }
}
