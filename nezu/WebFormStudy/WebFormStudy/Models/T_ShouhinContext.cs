using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebFormStudy.Models
{
    public class T_ShouhinContext : DbContext
    {
        public DbSet<T_Shouhin> T_Shouhins { get; set; }       
    }

}