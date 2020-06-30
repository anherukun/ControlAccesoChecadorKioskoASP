using ControlAccesoChecadorKioskoASP.Application;
using ControlAccesoChecadorKioskoASP.Models;
using ControlAccesoChecadorKioskoASP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ControlAccesoChecadorKioskoASP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Department department = ClientSideManager.RetriveCookieFromCollection(Request.Cookies, "client-department-selected") != null ?
                new DepartmentRepository().GetDepartment(int.Parse(ClientSideManager.RetriveCookieFromCollection(Request.Cookies, "client-department-selected"))) :
                null;
            List<AccessRegistry> accessRegistries = ClientSideManager.RetriveCookieFromCollection(Request.Cookies, "client-department-selected") != null ? 
                new AccessRegistryRepository().RetriveByDepartment(int.Parse(ClientSideManager.RetriveCookieFromCollection(Request.Cookies, "client-department-selected"))) :
                null;
            List<Employe> employes = new EmployeRepsitory().RetriveAll();

            
            ViewData["Department"] = department;
            ViewData["Employes"] = employes;
            ViewData["AccessRegistries"] = accessRegistries;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}