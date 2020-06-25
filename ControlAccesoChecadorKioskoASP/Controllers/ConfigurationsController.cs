using ControlAccesoChecadorKioskoASP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlAccesoChecadorKioskoASP.Controllers
{
    public class ConfigurationsController : Controller
    {
        // GET: Configurations
        public ActionResult Index()
        {
            ViewData["Departments"] = new DepartmentRepository().RetriveAll();
            return View();
        }
    }
}