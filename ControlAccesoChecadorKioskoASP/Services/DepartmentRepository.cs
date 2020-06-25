using ControlAccesoChecadorKioskoASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlAccesoChecadorKioskoASP.Services
{
    public class DepartmentRepository
    {
        public List<Department> RetriveAll()
        {
            using (var db = new ControlAccessCheckerContext())
            {
                return db.Departments.ToList();
            }
        }
    }
}