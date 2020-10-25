using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZBlog.Config;

namespace ZBlog.Areas.Admin.Dtos
{
    public class PostAddDto
    {
        
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
        public List<int> TagIds { get; set; }
        
        /// <summary>
        /// title
        /// </summary>
        // [MaxLength(200)]
        // [Required]
        [Display(Name = "标题")]
        public string Title { get; set; }

        /// <summary>
        /// Slug
        /// </summary>
        // [MaxLength(100)]
        // [Required]
        [Column("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Context
        /// </summary>
        // [Required]
        [Display(Name = "内容")]
        public string Context { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        // [Required]
        [Display(Name = "状态")]
        public PostType Status { get; set; }
        
        /// <summary>
        /// create_time
        /// </summary>
        // [Required]
        [Display(Name = "创建时间")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// update_time
        /// </summary>
        // [Required]
        [Display(Name = "修改时间")]
        public DateTime? UpdateTime { get; set; }

    }
}