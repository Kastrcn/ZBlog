using System;
using System.ComponentModel.DataAnnotations;

namespace ZBlog.Areas.Admin.Dtos
{
    public class LinkAddDto
    {
        /// <summary>
        /// logo
        /// </summary>
        [Display(Name = "品牌")]
        public string Logo { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Display(Name = "名称")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Priority
        /// </summary>
        [Required]
        [Display(Name = "优先")]
        public int Priority { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        [Display(Name = "地址")]
        [Url]
        [Required]
        public string Url { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Display(Name = "描述")]
        public string Description { get; set; }
        
    }
}