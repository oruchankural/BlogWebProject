using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BlogWebproject.Models;

namespace BlogWebproject.Controllers
{
  [Authorize]
    public class AdminController : Controller
    {
       
        // GET: Admin
        Context c = new Context();

    
        public ActionResult Index()
        {
            var blogsayisi = c.Blogs.Count().ToString();
            ViewBag.bn = blogsayisi;
            var about = c.Abouts.Count().ToString();
            ViewBag.ta = about;
            var mail = c.Mails.Count().ToString();
            ViewBag.tm = mail;
            return View();
        }

        public ActionResult Mail()
        {
            var mail = c.Mails.OrderByDescending(x=>x.MailID).ToList();
            return View(mail);
        }
        public ActionResult Maildetail(int id)
        {
            var mail = c.Mails.Where(x => x.MailID == id).ToList();
            return View(mail);
        }


        public ActionResult Blogs()
        {
            var blog = c.Blogs.ToList();
            return View(blog);
        }
        public ActionResult Blogdetail(int id)
        {
            var blogdetail = c.Blogs.Where(x=>x.BlogID == id).ToList();
            return View(blogdetail);
        }
        public ActionResult BlogShown(int id)
        {
            var ab = c.Blogs.Find(id);
            return View("BlogShown", ab);
          
        }
        public ActionResult Blogupdate (Blog h)
        {
            var abt = c.Blogs.Find(h.BlogID);
            abt.BlogTitle = h.BlogTitle;
            abt.BlogImage = h.BlogImage;
            abt.BlogText = h.BlogText;
            abt.BlogDatetime = h.BlogDatetime;
         
            c.SaveChanges();
            return RedirectToAction("Blogs","Admin");
            
        }
        public ActionResult Blogdelete (int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Blogs","Admin");
        }
        [HttpGet]
        public ActionResult NewBlog()
        {

            return View();
        }
        [HttpPost]
        public ActionResult NewBlog(Blog p)
        {
          
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Blogs","Admin");
        }
        public ActionResult Aboutdetails()
        {
            var about = c.Abouts.ToList();
            return View(about);
        }
        public ActionResult Aboutdelete(int id)
        {
            var b = c.Abouts.Find(id);
            c.Abouts.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Aboutdetails", "Admin");
        }
        [HttpGet]
        public ActionResult NewAbout()
        {

            return View();
        }
        [HttpPost]
        public ActionResult NewAbout(About p)
        {

            c.Abouts.Add(p);
            c.SaveChanges();
            return RedirectToAction("Aboutdetails", "Admin");
        }

        public ActionResult Aboutdetail(int id)
        {
            var about = c.Abouts.Where(x => x.AboutId == id).ToList();
            return View(about);
        }
        public ActionResult AboutdetailsShown(int id)
        {
            var ab = c.Abouts.Find(id);
            return View("AboutdetailsShown", ab);

        }
        public ActionResult Aboutdetailsupdate(About h)
        {
            var abt = c.Abouts.Find(h.AboutId);
            abt.Title = h.Title;
            abt.Year = h.Year;
            abt.Detail = h.Detail;
           

            c.SaveChanges();
            return RedirectToAction("Aboutdetails", "Admin");

        }
        public ActionResult AboutDelete(int id)
        {
            var b = c.Abouts.Find(id);
            c.Abouts.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Aboutdetails", "Admin");
        }


        public ActionResult Admin()
        {
            var username = (string)Session["Username"];
            var deger = c.Admins.FirstOrDefault(x => x.Username == username && x.Password == username);
            ViewBag.username = username;
            var sifre = c.Admins.Where(x => x.Username == username).Select(y => y.Password).FirstOrDefault();
            ViewBag.password = sifre;
            var email = c.Admins.Where(x => x.Username == username).Select(y => y.Email).FirstOrDefault();
            ViewBag.email = email;
            var namesur = c.Admins.Where(x => x.Username == username).Select(y => y.UserNameSurname).FirstOrDefault();
            ViewBag.name = namesur;
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login","Admin");
        }


        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login ()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Admin p)
        {
            var user = c.Admins.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if(user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                Session["Username"] = user.Username.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }

           
        }

    }
}