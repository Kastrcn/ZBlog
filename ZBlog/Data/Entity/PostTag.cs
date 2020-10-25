using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZBlog.Data.Entity
{
    [Table("post_tag")]
    public class PostTag
    {
        /// <summary>
        /// PostId
        /// </summary>
        [Column("post_id")]
        public long PostId { get; set; }
        
        public Post Post { get; set; }
        /// <summary>
        /// TagId
        /// </summary>
        [Column("tag_id")]
        public long TagId { get; set; }
        public Tag Tag { get; set; }
    }
}