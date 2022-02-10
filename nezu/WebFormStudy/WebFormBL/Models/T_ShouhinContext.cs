using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;

namespace WebFormBL.Models
{
    public class T_ShouhinContext : DbContext
    {
        public T_ShouhinContext() : base("WebFormBL")
        {
        }
        public DbSet<T_Shouhin> T_Shouhins { get; set; }
    }
}