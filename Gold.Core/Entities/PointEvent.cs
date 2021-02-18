using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gold.Core.Entities
{
    /// <summary>
    /// Bảng lưu điểm sự kiện
    /// </summary>
    public class PointEvent
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        /// <summary>
        /// Nomal, Middle, Hight
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Point { get; set; }
    }
}
