using System;
using System.ComponentModel.DataAnnotations;

namespace ZBlog.Areas.Admin.Dtos
{
    public class LinkListDto
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// logo
        /// </summary>
        [Display(Name = "品牌")]
        public string Logo { get; set; }

        [Display(Name = "名称")] [Required] public string Name { get; set; }

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