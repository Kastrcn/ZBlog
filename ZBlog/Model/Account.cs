using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ZBlog.Model
{
    [Table("account")]
    public class Account
    {

        public long Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "用户名")]
        public String UserName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name= "密码")]
        public String Password { get; set; }
    }
}