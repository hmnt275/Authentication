using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Authentication.Models
{
    public class SqlDbContex:DbContext
    {
        public SqlDbContex() : base("name=SqlConnection")
        {
        }
        public DbSet<User> Users { get; set; }
    }
}