using Data.Core;
using Food.Core.Entities;
using Food.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Core.Services
{
    public class VegetableService : IVegetableService
    {
        public readonly IRepositoryWithTypedId<VegetableFruit, FoodContext> _repository;
        public ISlugService<VegetableFruit, FoodContext> _slugService;
        public VegetableService(IRepositoryWithTypedId<VegetableFruit, FoodContext> repository
            , ISlugService<VegetableFruit, FoodContext> slugService)
        {
            _repository = repository;
            _slugService = slugService;
        }
        public void Add(VegetableFruit entity)
        {
            entity.Date = DateTime.Now;
            entity.Slug = _slugService.InstanceSlug(entity.Name, _repository).Result;
            _repository.Add(entity);
        }

        public async Task AddAsync(VegetableFruit entity)
        {
            entity.Date = DateTime.Now;
            entity.Slug = await _slugService.InstanceSlug(entity.Name, _repository);
            await _repository.AddAsync(entity);
        }

        public void AddRange(IEnumerable<VegetableFruit> entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<VegetableFruit> entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VegetableFruit>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public VegetableFruit GetId(long id)
        {
            return _repository.Query().FirstOrDefault(x => x.Id == id);
        }

        public async Task<VegetableFruit> GetIdAsync(long id)
        {
            return await _repository.Query().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(VegetableFruit entity)
        {
            _repository.Remove(entity);

        }

        public async Task<PagingList<VegetableFruit>> GetPagingList(int page, int pageSize, string search)
        {
            var data = _repository.Query()
                .Where(x => string.IsNullOrEmpty(search) || x.Name.Contains(search))
                .OrderByDescending(x => x.Date);

            return await PagingList.CreateAsync<VegetableFruit>(data, pageSize, page);
        }
    }
}
