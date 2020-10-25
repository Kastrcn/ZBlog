using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZBlog.Areas.Admin.Params
{
    
    
    public class CategoryAddDto
    {
        
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