using ControlAccesoChecadorKioskoASP.Models;
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
    }
}