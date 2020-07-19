using ControlAccesoChecadorKioskoASP.Models;
using ControlAccesoChecadorKioskoASP.Services;
using System;
using System.Collections.Generic;
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

            return View();
        }

        [HttpPost]
        public ActionResult SubmitReportAccess(string dateStart, string dateEnd, int department = 0, int employeId = 0)
        {
            return View();
        }
    }
}