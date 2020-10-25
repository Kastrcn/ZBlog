using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZBlog.Data.Entity
{
    [Table("link")]
    public class Link:EntityBase
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [Column("id")]
        public long Id { get; set; }
        /// <summary>
        /// Logo
        /// </summary>
        [Column("logo")]
        public string Logo { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Column("name")]
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Priority
        /// </summary>
        [Column("priority")]
        [Required]
        public int Priority { get; set; }
        /// <summary>
        /// Url
        /// </summary>
        [Column("url")]
        [Required]
        public string Url { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [Column("description")]
        public string Description { get; set; }
    }
}