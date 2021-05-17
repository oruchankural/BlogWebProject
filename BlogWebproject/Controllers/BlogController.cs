using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWebproject.Models;

namespace BlogWebproject.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        // GET: Blog
        public PartialViewResult Index()
        {
            var blog = c.Blogs.ToList();
            return PartialView(blog);
        }

        public ActionResult Blogdetails (int id)
        {
            var blog = c.Blogs.Where(x => x.BlogID == id).ToList();
            return View(blog);
        }
    }
}