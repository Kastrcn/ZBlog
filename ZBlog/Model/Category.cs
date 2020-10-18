using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZBlog.Model
{
    [Table("category")]
    public class Category
    {
        public long Id { get; set; }


        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "slug_name")]
        [Column("slug_name")]
        public string SlugName { get; set; }
        [Display(Name = "Slug")]
        public string Slug { get; set; }

        [Display(Name = "图片")]
        public string Thumbnail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "创建时间")]
        [Column("create_time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd  HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "修改时间")]
        [Column("update_time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd  HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime UpdateTime { get; set; }
    }
}