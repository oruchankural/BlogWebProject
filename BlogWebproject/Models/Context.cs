using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BlogWebproject.Models
{
    public class Context : DbContext
    {
       public DbSet <Blog> Blogs { get; set; }
       public DbSet <Mail> Mails { get; set; }
       public DbSet <Admin> Admins { get; set; }
       public DbSet <About> Abouts { get; set; }
    }
}