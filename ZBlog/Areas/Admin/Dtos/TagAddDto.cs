using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZBlog.Areas.Admin.Dtos
{
    public class TagAddDto
    {

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [MaxLength(80)]
        [Display(Name ="名称")]
        [Column("name")]
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