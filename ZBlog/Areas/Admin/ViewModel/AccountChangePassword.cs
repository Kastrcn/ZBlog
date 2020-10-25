using System;
using System.ComponentModel.DataAnnotations;

namespace ZBlog.Areas.Admin.ViewModel
{
    public class AccountChangePassword
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "旧密码")]
        public string OldPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string Password { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "两次密码不一致")]
        public string ConfirmPassword { get; set; }
    }
}