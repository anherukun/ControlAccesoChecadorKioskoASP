using ControlAccesoChecadorKioskoASP.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ControlAccesoChecadorKioskoASP.Services
{
    public class AccessRegistryRepository
    {
        // ES NECESARIO INSERTAR FUNCION EN DB: Create FUNCTION TruncateTime(dateValue DateTime) RETURNS date return Date(dateValue);
        public List<AccessRegistry> RetriveAll(DateTime dateStart, DateTime dateEnd)
        {
            using (var db = new ControlAccessCheckerContext())
            {
                return db.AccessRegistries.Where(x => DbFunctions.TruncateTime(x.Date) >= dateStart && DbFunctions.TruncateTime(x.Date) <= dateEnd)
                    .Include(x => x.Department)
                    .Include(x => x.Employe).OrderByDescending(x => x.AccessRegistryId).ToList();
            }
        }
        public List<AccessRegistry> RetriveByDepartment(int departmentId, int count)
        {
            using (var db = new ControlAccessCheckerContext())
            {
                return db.AccessRegistries.Where(x => x.DepartmentId == departmentId)
                    .Include(x => x.Department)
                    .Include(x => x.Employe).OrderByDescending(x => x.AccessRegistryId).Take(count).ToList();
            }
        }
        public List<AccessRegistry> RetriveByDepartment(int departmentId, DateTime dateStart, DateTime dateEnd)
        {
            using (var db = new ControlAccessCheckerContext())
            {
                return db.AccessRegistries.Where(x => x.DepartmentId == departmentId)
                    .Where(x => DbFunctions.TruncateTime(x.Date) >= dateStart && DbFunctions.TruncateTime(x.Date) <= dateEnd)
                    .Include(x => x.Department)
                    .Include(x => x.Employe).OrderByDescending(x => x.AccessRegistryId).ToList();
            }
        }
        public List<AccessRegistry> RetriveByEmploye(int employeId, DateTime dateStart, DateTime dateEnd)
        {
            using (var db = new ControlAccessCheckerContext())
            {
                return db.AccessRegistries.Where(x => x.EmployeId == employeId)
                    .Where(x => DbFunctions.TruncateTime(x.Date) >= dateStart && DbFunctions.TruncateTime(x.Date) <= dateEnd)
                    .Include(x => x.Department)
                    .Include(x => x.Employe).OrderByDescending(x => x.AccessRegistryId).ToList();
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

        public static List<List<object>> GetCompleteMatrix(List<AccessRegistry> accessRegistries)
        {
            List<List<object>> matrix = new List<List<object>>();

            // ACCESSREGISTRYID | DEPARTMENTID | EMPLOYEID | EMPLOYENAME | DEPARTMENTNAME | DATE(QUERYDATE) | INGRESSTICKS | INGRESSDATE | INGRESSTIME | EGRESSTICKS | EGRESSDATE | EGRESSTIME | INTIME

            matrix.Add(new List<object> { "ACCESSREGISTRYID", "DEPARTMENTID", "EMPLOYEID", "EMPLOYENAME", "DEPARTMENTNAME", "DATE(QUERYDATE)", "INGRESSTICKS",
                "INGRESSDATE", "INGRESSTIME", "EGRESSTICKS", "EGRESSDATE", "EGRESSTIME", "INTIME"});

            foreach (var item in accessRegistries)
            {
                string diferenceHours = "--";
                string diferenceMinutes = "--";

                if (item.EgressTicks != 0)
                {
                    DateTime EgressDateTime = new DateTime(item.EgressTicks);

                    int hh = new DateTime(item.EgressTicks).Subtract(new DateTime(item.IngressTicks)).Hours
                        + (new DateTime(item.EgressTicks).Subtract(new DateTime(item.IngressTicks)).Days * 24);
                    int mm = new DateTime(item.EgressTicks).Subtract(new DateTime(item.IngressTicks)).Minutes;
                    diferenceHours = hh > 10 ? $"{hh}" : $"0{hh}";
                    diferenceMinutes = mm > 10 ? $"{mm}" : $"0{mm}";
                }

                matrix.Add(new List<object> { item.AccessRegistryId, item.DepartmentId, item.EmployeId, item.Employe.Name, item.Department.Name, item.Date, item.IngressTicks,
                new DateTime(item.IngressTicks).ToLongDateString(), new DateTime(item.IngressTicks).ToShortTimeString(), item.EgressTicks,
                    new DateTime(item.EgressTicks).ToLongDateString(), new DateTime(item.EgressTicks).ToShortTimeString(), $"{diferenceHours}:{diferenceMinutes}"});
            }

            return matrix;
        }
    }
}