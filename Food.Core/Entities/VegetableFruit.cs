using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Food.Core.Entities
{
    public partial class VegetableFruit
    {
        public VegetableFruit()
        {
            InversePriceNavigation = new HashSet<Price>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        [MaxLength(200)]
        public string Slug { get; set; }
        public Guid? User { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public string VideoLink { get; set; }
        public bool? Status { get; set; }
        public long? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Price> InversePriceNavigation { get; set; }
    }
}
