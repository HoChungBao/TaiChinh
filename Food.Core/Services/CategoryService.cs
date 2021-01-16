using Data.Core;
using Food.Core.Entities;
using Food.Core.Interfaces;
using Infrastructure.Util;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Core.Services
{
    public class CategoryService : ICategoryService
    {
        public readonly IRepositoryWithTypedId<Category, FoodContext> _repository;
        public ISlugService<Category, FoodContext> _slugService;
        public CategoryService(IRepositoryWithTypedId<Category, FoodContext> repository
            , ISlugService<Category, FoodContext> slugService)
        {
            _repository =repository;
            _slugService = slugService;
        }

        public void Add(Category entity)
        {
            entity.Date = DateTime.Now;
             _repository.Add(entity);
        }

        public async Task AddAsync(Category entity)
        {
            entity.Date = DateTime.Now;

            var slug =await _slugService.InstanceSlug(entity.Name,_repository);

            entity.Slug = slug;

            await _repository.AddAsync(entity);
        }

        public void AddRange(IEnumerable<Category> entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<Category> entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public Category GetId(long id)
        {
            return _repository.Query().FirstOrDefault(x => x.Id == id);
        }

        public async Task<Category> GetIdAsync(long id)
        {
            return await _repository.Query().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagingList<Category>> GetPagingList(int page, int pageSize, string search)
        {
            var data = _repository.Query()
                .Where(x => string.IsNullOrEmpty(search) || x.Name.Contains(search))
                .OrderByDescending(x=>x.Date);

            return await PagingList.CreateAsync<Category>(data, pageSize, page);
        }

        public void Remove(Category entity)
        {
            _repository.Remove(entity);
        
        }
    }
}
