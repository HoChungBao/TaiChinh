using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gold.Core.Entities
{
    public class Event
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        /// <summary>
        /// Tên sự kiện
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// dự đoán
        /// true: giá vàng tăng, +
        /// false: giá vàng giảm, -
        /// </summary>
        [Required]
        public bool IsPositiveFake { get; set; }
        [Required]
        public DateTime Date { get; set; }
        /// <summary>
        /// Điểm
        /// </summary>
        [Required]
        public int Point { get; set; }
        /// <summary>
        /// true: thế giới
        /// false: trong nước
        /// </summary>
        [Required]
        public bool IsWorld { get; set; }
        /// <summary>
        /// đường dẫn tin tức
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// true:good event 
        /// false: bad event
        /// </summary>
        [Required]
        public bool IsGood { get; set; }
        /// <summary>
        /// thực tế
        /// true : +
        /// false: -
        /// </summary>
        [Required]
        public bool IsPositiveReal { get; set; }
        /// <summary>
        /// Chính trị, kinh tế
        /// </summary>
        [Required]
        public string Field { get; set; }
    }
}
