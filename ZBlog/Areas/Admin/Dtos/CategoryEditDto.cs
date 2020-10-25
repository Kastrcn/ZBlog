using System.ComponentModel.DataAnnotations;

namespace ZBlog.Areas.Admin.Params
{
    
    public class CategoryEditDto
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public long Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [Display(Name = "名称")]
        [MaxLength(80)]
        public string Name { get; set; }

        /// <summary>
        /// Slug
        /// </summary>
        [MaxLength(100)]
        [Required]
        [Display(Name = "slug")]
        public string Slug { get; set; }
    }
}