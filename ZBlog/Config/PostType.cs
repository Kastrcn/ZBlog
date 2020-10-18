using System.ComponentModel.DataAnnotations;

namespace ZBlog.Config
{
    public enum PostType
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "草稿")] Draft = 0,

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "发布")] Publish = 1,
        // [Display(Name = "Other")]Other = 3 
    }
}