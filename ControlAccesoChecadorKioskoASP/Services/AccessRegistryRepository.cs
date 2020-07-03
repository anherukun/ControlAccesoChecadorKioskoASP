using ControlAccesoChecadorKioskoASP.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ControlAccesoChecadorKioskoASP.Services
{
    public class AccessRegistryRepository
    {
        public List<AccessRegistry> RetriveByDepartment(int departmentId, int count)
        {
            using (var db = new ControlAccessCheckerContext())
            {
                return db.AccessRegistries.Where(x => x.Department.DepartmentId == departmentId)
                    .Include(x => x.Department)
                    .Include(x => x.Employe).OrderByDescending(x => x.AccessRegistryId).Take(count).ToList();
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

        public void Update(AccessRegistry registry)
        {
            using (var db = new ControlAccessCheckerContext())
            {
                db.AccessRegistries.AddOrUpdate(registry);
                db.SaveChanges();
            }
        }

        public AccessRegistry GetRegistry(int accessRegistryId)
        {
            using (var db = new ControlAccessCheckerContext())
            {
                return db.AccessRegistries.Find(accessRegistryId);
            }
        }
    }
}