using ControlAccesoChecadorKioskoASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlAccesoChecadorKioskoASP.Services
{
    public class EmployeRepsitory
    {
        public List<Employe> RetriveAll()
        {
            using (var db = new ControlAccessCheckerContext())
            {
                return db.Employes.ToList();
            }
        }
    }
}