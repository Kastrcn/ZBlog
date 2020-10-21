using System;
using System.ComponentModel.DataAnnotations;

namespace ZBlog.ViewModel
{
    public class CommentViewModel
    {
        [Display(Name = "邮箱")]
        [EmailAddress]
        [Required(ErrorMessage = "邮箱不能为空！")]
        public String Email { get; set; }
        [Display(Name = "网址")]
        public String WebSite { get; set; }
        [Display(Name = "昵称")]
        [Required(ErrorMessage = "昵称不能为空！")]
        public String NickName { get; set; }
        [Required]
        public long PostId { get; set; }
        [Display(Name = "内容")]
        [MinLength(8,ErrorMessage = "内容太短！")]
        [Required(ErrorMessage = "内容不能为空！")]
        public string Content { get; set; }
    }
}