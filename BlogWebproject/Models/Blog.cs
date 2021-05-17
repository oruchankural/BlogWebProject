using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWebproject.Models
{
    public class Blog
    {

        [Key]
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        [AllowHtml]
        public string BlogText { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogDatetime { get; set; }
    }
}