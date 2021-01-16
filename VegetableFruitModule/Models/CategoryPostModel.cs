using Food.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegetableFruitModule.Models
{
    public class CategoryPostModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public long? CategoryId { get; set; }
        public CategoryPostModel() { }
        public Category InstanceEntity()
        {
            return new Category()
            {
                Name = Name,
                CategoryId = CategoryId,
            };
        }
    }

}
