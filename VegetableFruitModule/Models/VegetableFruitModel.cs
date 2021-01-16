using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegetableFruitModule.Models
{
    public class VegetableFruitModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public string Slug { get; set; }
        public Guid? User { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public string VideoLink { get; set; }
        public bool? Status { get; set; }
        public long? CategoryId { get; set; }
    }
}
