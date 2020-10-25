using System;
using System.ComponentModel.DataAnnotations;

namespace ZBlog.Areas.Admin.Dtos
{
    public class CategoryDto
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// Name
        /// </summary>
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// Slug
        /// </summary>
        [Display(Name = "Slug")]
        public string Slug { get; set; }
        
        /// <summary>
        /// create_time
        /// </summary>
        [Display(Name = "创建时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd  HH:mm:ss}", ApplyFormatInEditMode = true)]

        public DateTime CreateTime { get; set; }

        /// <summary>
        /// update_time
        /// </summary>
        [Display(Name = "修改时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd  HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime UpdateTime { get; set; }
    }
}