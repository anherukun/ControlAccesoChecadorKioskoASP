using ControlAccesoChecadorKioskoASP.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ControlAccesoChecadorKioskoASP.Services
{
    public class AccessRegistryRepository
    {
        public List<AccessRegistry> RetriveByDepartment(int departmentId)
        {
            using (var db = new ControlAccessCheckerContext())
            {
                return db.AccessRegistries.Where(x => x.Department.DepartmentId == departmentId)
                    .Include(x => x.Department)
                    .Include(x => x.Employe).OrderByDescending(x => x.AccessRegistryId).ToList() ;
            }
        }

        public void Add(AccessRegistry registry)
        {
            using (var db = new ControlAccessCheckerContext())
            {
                db.AccessRegistries.Add(registry);
                db.SaveChanges();
            }
        }
    }
}