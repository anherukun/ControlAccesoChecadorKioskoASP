using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ControlAccesoChecadorKioskoASP.Models
{
    public class ControlAccessCheckerContext : DbContext
    {
#if DEBUG
        public ControlAccessCheckerContext() : base("DefaultConnectionMySQL")
        {

        }
#else
        public ControlAccessCheckerContext() : base("DefaultConnectionMySQL-PROD")
        {

        }
#endif
        static ControlAccessCheckerContext()
        {
            DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        }

        public DbSet<Employe> Employes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<AccessRegistry> AccessRegistries { get; set; }
    }
}