using System.ComponentModel.DataAnnotations;

namespace ZBlog.Params
{
    
    public class CommentParam
    {
        
        
        [Required]
        public string PostId { get; set; }
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [Display(Name= "昵称")]
        public string Nickname { get; set; }
        
        [Display(Name= "网站")]
        public string Website { get; set; }
        [Required]
        [Display(Name= "内容")]
        public string Context { get; set; }
    }
}