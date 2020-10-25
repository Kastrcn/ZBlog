using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZBlog.Data.Entity
{
    [Table("account")]
    public class Account : EntityBase
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// username
        /// </summary>
        [Required]
        [Display(Name = "用户名")]
        [Column("user_name")]
        [MaxLength(120)]
        public string UserName { get; set; }

        /// <summary>
        /// password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Column("password")]
        [Display(Name = "密码")]
        [MaxLength(256)]
        public string Password { get; set; }

        [Required]
        [Column("email")]
        [MaxLength(200)]
        public string Email { get; set; }
        
        [Required]
        [Column("nickname")]
        [MaxLength(100)]
        public string NickName { get; set; }
        
    }
}