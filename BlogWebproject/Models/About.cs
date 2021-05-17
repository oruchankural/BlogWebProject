using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWebproject.Models
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }
        public string Year { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
    }
}