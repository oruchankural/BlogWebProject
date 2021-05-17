using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWebproject.Models;

namespace BlogWebproject.Controllers
{
    public class ContactController : Controller
    {
        Context c = new Context();
        // GET: Contact
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Mail p)
        {
            if (ModelState.IsValid)
            {


                c.Mails.Add(p);
                c.SaveChanges();
                return View();
            }
            else
            {
                return View();
            }
         
        }
    }
}