using Gold.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldModule.Models
{
    public class EventPostModel
    {
        public long Id { get; set; }
      
        public string Name { get; set; }
    
        public bool IsPositiveFake { get; set; }
    
        public int Point { get; set; }
             
        public bool IsWorld { get; set; }
      
        public string Url { get; set; }
     
        public bool IsGood { get; set; }
      
        public bool IsPositiveReal { get; set; }
       
        public string Field { get; set; }
        public Event InstanceEntity()
        {
            return new Event()
            {
                Name = Name,
                IsGood = IsGood,
                IsPositiveFake = IsPositiveFake,
                IsWorld = IsWorld,
                Point = Point,
                Url = Url,
                Field = Field,
            };
        }
    }
}
