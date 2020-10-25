using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZBlog.Config;

namespace ZBlog.ViewModel
{
    public class PostViewModel
    {
        [Key] public long Id { get; set; }
        [Display(Name = "标题")] public string Title { get; set; }
        [Display(Name = "Slug")] public string Slug { get; set; }
        [Display(Name = "内容")] public string Context { get; set; }

        [Display(Name = "状态")]
        [EnumDataType(typeof(PostType))]
        public PostType Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "创建时间")]
        [Column("created_at")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd  HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "修改时间")]
        [Column("updated_at")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd  HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime UpdatedAt { get; set; }
    }
}