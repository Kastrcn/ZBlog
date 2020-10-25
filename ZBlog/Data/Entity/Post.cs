using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZBlog.Config;

namespace ZBlog.Data.Entity
{
    [Table("post")]
    public class Post:EntityBase
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        [Required]
        [ForeignKey("CategoryId")]
        [Column("category_id")]
        public long CategoryId { get; set; }

        /// <summary>
        /// title
        /// </summary>
        [MaxLength(200)]
        [Required]
        [Column("title")]
        public string Title { get; set; }

        /// <summary>
        /// Slug
        /// </summary>
        [MaxLength(100)]
        [Required]
        [Column("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Context
        /// </summary>
        [Required]
        [Column("context")]
        public string Context { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [Required]
        [Column("status")]
        public PostType Status { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        [Required]
        [ForeignKey("AccountId")]
        [Column("account_id")]
        public long AccountId { get; set; }
        
        
        public ICollection<PostTag> PostTags { get; set; }

    }
}