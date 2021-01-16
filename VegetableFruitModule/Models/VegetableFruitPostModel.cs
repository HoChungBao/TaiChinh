using Food.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegetableFruitModule.Models
{
    public class VegetableFruitPostModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public string VideoLink { get; set; }
        public bool? Status { get; set; }
        public long? CategoryId { get; set; }
        public VegetableFruitPostModel() { }
        public VegetableFruit InstanceEntity()
        {
            return new VegetableFruit()
            {
                Name = Name,
                CategoryId = CategoryId,
                Description = Description,
                ImageLink = ImageLink,
                VideoLink = VideoLink,
                Status = Status,

            };
        }
    }

}
