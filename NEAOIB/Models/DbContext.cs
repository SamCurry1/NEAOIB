using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NEAOIB.Models
{
    public class OurDbContext : DbContext
    {
        public DbSet <Account> Account { get; set; }
    }
}