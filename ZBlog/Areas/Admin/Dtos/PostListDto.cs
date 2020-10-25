using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZBlog.Config;
using ZBlog.Data.Entity;

namespace ZBlog.Areas.Admin.Dtos
{
    public class PostListDto
    {
        
        /// <summary>
        /// Status
        /// </summary>
        // [Required]
        public long Id { get; set; }

        /// <summary>
        /// title
        /// </summary>
        // [MaxLength(200)]
        // [Required]
        [Display(Name = "标题")]
        public string Title { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        // [Required]
        [Display(Name = "分类")]
        public long CategoryId { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [Display(Name = "标签")]
       
        public ICollection<PostTag> PostTags { get; set; }

        /// <summary>
        /// Slug
        /// </summary>
        // [MaxLength(100)]
        // [Required]
        [Column("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        // [Required]
        [Display(Name = "状态")]
        public PostType Status { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        [Display(Name = "创建时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd  HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// UpdateTime
        /// </summary>
        [Display(Name = "修改时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd  HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime UpdateTime { get; set; }
    }
}