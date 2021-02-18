using Gold.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldModule.Models
{
    public class PointEventPostModel
    {
      
        public long Id { get; set; }
    
        public string Name { get; set; }
     
        public int Point { get; set; }

        public PointEvent InstanceEntity()
        {
            return new PointEvent()
            {
                Name = Name,
                Point = Point,
            };
        }
    }
}
