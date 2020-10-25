using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZBlog.Data.Entity
{
    [Table("config")]
    public class Config
    {
       
        [Key]
        [Required]
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column("data")]
        public string Data { get; set; }
    }
}