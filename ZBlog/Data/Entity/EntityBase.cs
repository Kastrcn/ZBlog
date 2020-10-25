using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZBlog.Data.Entity
{
    public class EntityBase
    {
        /// <summary>
        /// create_time
        /// </summary>
        [Required]
        [Column("create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// update_time
        /// </summary>
        [Required]
        [Column("update_time")]
        public DateTime UpdateTime { get; set; }
    }
}