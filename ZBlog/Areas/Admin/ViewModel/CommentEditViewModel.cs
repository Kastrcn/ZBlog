using System.ComponentModel.DataAnnotations;

namespace ZBlog.Areas.Admin.ViewModel
{
    public class CommentEditViewModel
    {
        /// <summary>
        /// id
        /// </summary>
        [Required]
        public long Id { get; set; }
        
        /// <summary>
        /// Reply
        /// </summary>
        [Required]
        [Display(Name = "回复")]
        public string Reply { get; set; }
    }
}