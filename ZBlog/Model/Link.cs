using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZBlog.Model
{
    [Table("links")]
    public class Link
    {
        public long Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Team { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }

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