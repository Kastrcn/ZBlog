using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using ZBlog.Data.Entity;

namespace ZBlog.Model
{
    public class Account
    
    {

        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "用户名")]
        [Column("user_name")]
        [MaxLength(120)]
        public String UserName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Column("password")]
        [Display(Name= "密码")]
        [MaxLength(256)]
        public String Password { get; set; }
    }
}