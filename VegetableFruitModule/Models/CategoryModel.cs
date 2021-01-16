using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegetableFruitModule.Models
{
    public class CategoryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public DateTime? Date { get; set; }
        public Guid? User { get; set; }
        public long? CategoryId { get; set; }
    }
}
