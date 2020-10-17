using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZBlog.Model
{
    [Table("category")]
    public class Category
    {
        public long Id { get; set; }


        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("slug_name")]
        public string SlugName { get; set; }

        public string Slug { get; set; }


        public string Thumbnail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("update_time")]
        public DateTime UpdateTime { get; set; }
    }
}