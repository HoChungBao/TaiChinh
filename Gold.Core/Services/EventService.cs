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
    public class EventService : IEventService
    {
        public readonly IRepositoryWithTypedId<Event, GoldContext> _repository;
        public EventService(IRepositoryWithTypedId<Event, GoldContext> repository)
        {
            _repository = repository;
        }
        public void Add(Event entity)
        {
            entity.Date = DateTime.Now;
            _repository.Add(entity);
        }

        public async Task AddAsync(Event entity)
        {
            entity.Date = DateTime.Now;
            await _repository.AddAsync(entity);
        }

        public void AddRange(IEnumerable<Event> entity)
        {
            _repository.AddRange(entity);
        }

        public async Task AddRangeAsync(IEnumerable<Event> entity)
        {
            await _repository.AddRangeAsync(entity);
        }

        public Task<List<Event>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public async Task<List<Event>> GetEventFromDateToDate(DateTime datefrom, DateTime dateto)
        {
            return await _repository.Query()
                .Where(x => x.Date.Date >= datefrom.Date && dateto.Date >= x.Date.Date)
                .AsNoTracking()
                .ToListAsync();
        }

        public Event GetId(long id)
        {
            return _repository.Query().FirstOrDefault(x => x.Id == id);
        }

        public Task<Event> GetIdAsync(long id)
        {
            return _repository.Query().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagingList<Event>> GetPagingList(int page, int pageSize, string search)
        {
            var data = _repository.Query()
               .Where(x => string.IsNullOrEmpty(search) || x.Name.Contains(search))
               .OrderByDescending(x => x.Date);

            return await PagingList.CreateAsync<Event>(data, pageSize, page);
        }

        public void Remove(Event entity)
        {
            _repository.Remove(entity);
        }
    }
}
