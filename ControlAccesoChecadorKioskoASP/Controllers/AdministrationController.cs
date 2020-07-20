﻿using ControlAccesoChecadorKioskoASP.Models;
using ControlAccesoChecadorKioskoASP.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlAccesoChecadorKioskoASP.Controllers
{
    public class AdministrationController : Controller
    {
        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReportAccess()
        {
            List<Department> departments = new DepartmentRepository().RetriveAll();
            List<Employe> employes = new EmployeRepsitory().RetriveAll();

            ViewData["Departments"] = departments;
            ViewData["Employes"] = employes;

            return View();
        }

        [HttpPost]
        public ActionResult ReportAccess(string dateStart, string dateEnd, int department = 0, int employeId = 0)
        {
            List<Department> departments = new DepartmentRepository().RetriveAll();
            List<Employe> employes = new EmployeRepsitory().RetriveAll();
            List<AccessRegistry> accessRegistries;

            ViewData["Departments"] = departments;
            ViewData["Employes"] = employes;

            if (department != 0)
            {
                accessRegistries = new AccessRegistryRepository().RetriveByDepartment(department, DateTime.Parse(dateStart), DateTime.Parse(dateEnd));
                ViewData["AccessRegistries"] = accessRegistries;
            }
            else if (employeId != 0)
            {
                accessRegistries = new AccessRegistryRepository().RetriveByEmploye(employeId, DateTime.Parse(dateStart), DateTime.Parse(dateEnd));
                ViewData["AccessRegistries"] = accessRegistries;
            }
            else
            {
                accessRegistries = new AccessRegistryRepository().RetriveAll(DateTime.Parse(dateStart), DateTime.Parse(dateEnd));
                ViewData["AccessRegistries"] = accessRegistries;
            }

            return View();
        }
    }
}