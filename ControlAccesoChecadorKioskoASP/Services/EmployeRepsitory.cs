using ControlAccesoChecadorKioskoASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ControlAccesoChecadorKioskoASP.Services
{
    public class EmployeRepsitory
    {
        public void Add(Employe employe)
        {
            using (var db = new ControlAccessCheckerContext())
            {
                db.Employes.Add(employe);
                db.SaveChanges();
            }
        }

        public void Update(Employe employe)
        {
            using (var db = new ControlAccessCheckerContext())
            {
                db.Employes.AddOrUpdate(employe);
                db.SaveChanges();
            }
        }

        public void Delete(int EmployeId)
        {
            using (var db = new ControlAccessCheckerContext())
            {
                //
            }
        }

        public Employe Get(int EmployeId)
        {
            using (var db = new ControlAccessCheckerContext())
            {
                return db.Employes.Where(x => x.EmployeId == EmployeId).FirstOrDefault();
            }
        }

        public List<Employe> RetriveAll()
        {
            using (var db = new ControlAccessCheckerContext())
            {
                return db.Employes.ToList();
            }
        }

        public Employe GetEmploye(int employeId)
        {
            using (var db = new ControlAccessCheckerContext())
            {
                return db.Employes.Find(employeId);
            }
        }
    }
}