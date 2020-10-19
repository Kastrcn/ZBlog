using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZBlog.Model
{
    [Table("comment")]
    public class Comment
    {
        public long Id { get; set; }
        public String Email { get; set; }
        public String WebSite { get; set; }
        public String NickName { get; set; }
        [Column("post_id")]
        public long PostId { get; set; }
        public string Content { get; set; }
        public string Reply { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("create_time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd  HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("update_time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd  HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime UpdateTime { get; set; }
     
    }
}