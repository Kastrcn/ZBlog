using System.ComponentModel.DataAnnotations;

namespace ZBlog.Config
{
    public enum PostType
    {
        [Display(Name = "Male")]Male = 1,
        [Display(Name = "Female N")]Female = 2,
        [Display(Name = "Other")]Other = 3 
    }
}