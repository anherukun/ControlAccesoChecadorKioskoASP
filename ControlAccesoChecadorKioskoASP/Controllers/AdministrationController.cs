using ControlAccesoChecadorKioskoASP.Application;
using ControlAccesoChecadorKioskoASP.Models;
using ControlAccesoChecadorKioskoASP.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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
        public ActionResult ReportAccess(string dateStart, string dateEnd, int departmentId = 0, int employeId = 0)
        {
            List<Department> departments = new DepartmentRepository().RetriveAll();
            List<Employe> employes = new EmployeRepsitory().RetriveAll();
            List<AccessRegistry> accessRegistries;

            ViewData["Departments"] = departments;
            ViewData["Employes"] = employes;

            if (departmentId != 0)
            {
                accessRegistries = new AccessRegistryRepository().RetriveByDepartment(departmentId, DateTime.Parse(dateStart), DateTime.Parse(dateEnd));
                ViewData["AccessRegistriesJSON"] = ApplicationManager.Base64Encode(JsonConvert.SerializeObject(accessRegistries));
                ViewData["AccessRegistries"] = accessRegistries;
            }
            else if (employeId != 0)
            {
                accessRegistries = new AccessRegistryRepository().RetriveByEmploye(employeId, DateTime.Parse(dateStart), DateTime.Parse(dateEnd));
                ViewData["AccessRegistriesJSON"] = ApplicationManager.Base64Encode(JsonConvert.SerializeObject(accessRegistries));
                ViewData["AccessRegistries"] = accessRegistries;
            }
            else
            {
                accessRegistries = new AccessRegistryRepository().RetriveAll(DateTime.Parse(dateStart), DateTime.Parse(dateEnd));
                ViewData["AccessRegistriesJSON"] = ApplicationManager.Base64Encode(JsonConvert.SerializeObject(accessRegistries));
                ViewData["AccessRegistries"] = accessRegistries;
            }

            return View();
        }

        [HttpPost]
        public FileResult ExportCompleteMatrixToCSV(string data)
        {
            string json = ApplicationManager.Base64Decode(data);
            List<AccessRegistry> accessRegistries = JsonConvert.DeserializeObject<List<AccessRegistry>>(json);

            return File(CSVManager.FromMatrixToCSVBytes(AccessRegistryRepository.GetCompleteMatrix(accessRegistries)), "application/x-msexcel", "export.csv");
            //return File("", "document/csv");
        }
        [HttpPost]
        public FileResult ExportFinalMatrixToCSV(string data)
        {
            string json = ApplicationManager.Base64Decode(data);
            List<AccessRegistry> accessRegistries = JsonConvert.DeserializeObject<List<AccessRegistry>>(json);

            return File(CSVManager.FromMatrixToCSVBytes(AccessRegistryRepository.GetFinalMatrix(accessRegistries)), "application/x-msexcel", "export.csv");
            //return File("", "document/csv");
        }
    }
}