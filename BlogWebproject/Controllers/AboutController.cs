using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWebproject.Models;

namespace BlogWebproject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Context c = new Context();
        public ActionResult Index()
        {
          
            return View();
        }

        public PartialViewResult AboutDetails ()
        {
            var aboutdetails = c.Abouts.ToList();
            return PartialView(aboutdetails);
        }
    }
}