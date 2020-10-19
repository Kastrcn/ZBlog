using System;
using System.ComponentModel.DataAnnotations;

namespace ZBlog.ViewModel
{
    public class CommentViewModel
    {
        [Display(Name = "邮箱")]
        [EmailAddress]
        [Required]
        public String Email { get; set; }
        [Display(Name = "网址")]
        public String WebSite { get; set; }
        [Display(Name = "昵称")]
        [Required]
        public String NickName { get; set; }
        [Required]
        public long PostId { get; set; }
        [Display(Name = "内容")]
        [Required]
        public string Content { get; set; }
    }
}