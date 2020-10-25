using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZBlog.Data.Entity
{
    [Table("comment")]
    public class Comment :EntityBase
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [MaxLength(150)]
        [Required]
        [Column("email")]
        public String Email { get; set; }

        /// <summary>
        /// WebSite
        /// </summary>
        [MaxLength(200)]
        [Column("website")]
        public String WebSite { get; set; }

        /// <summary>
        /// NickName
        /// </summary>
        [MaxLength(80)]
        [Column("nickname")]
        public String NickName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("PostId")]
        [Column("post_id")]
        [Required]
        public long PostId { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        [Column("content")]
        public string Content { get; set; }

        /// <summary>
        /// Reply
        /// </summary>
        [Column("reply")]
        public string Reply { get; set; }
        
        
        /// <summary>
        /// Reply
        /// </summary>
        [Column("ip_address")]
        public string IpAddress { get; set; }
        
        
    }
}