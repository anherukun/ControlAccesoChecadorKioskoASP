using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ControlAccesoChecadorKioskoASP.Models
{
    public class ControlAccessCheckerContext : DbContext
    {
        public ControlAccessCheckerContext() : base("DefaultConnection")
        {

        }

        public DbSet<Employe> Employes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<AccessRegistry> AccessRegistries { get; set; }
    }
}