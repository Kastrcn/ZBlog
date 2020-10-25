using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZBlog.Config;
using ZBlog.Data.Entity;

namespace ZBlog.Areas.Admin.ViewModel
{
    public class PostDetailsViewModel
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        public string CategoryName { get; set; }
        public string Tags { get; set; }
        public string Title { get; set; }

        public string Slug { get; set; }
        public string Context { get; set; }
        public string Status { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        [Display(Name = "创建时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd  HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// UpdateTime
        /// </summary>
        [Display(Name = "修改时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd  HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime UpdateTime { get; set; }
    }
}