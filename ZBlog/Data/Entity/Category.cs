using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZBlog.Data.Entity
{
    [Table("category")]
    public class Category : EntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }


        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [MaxLength(80)]
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Slug
        /// </summary>
        [MaxLength(100)]
        [Required]
        [Column("slug")]
        public string Slug { get; set; }
    }
}