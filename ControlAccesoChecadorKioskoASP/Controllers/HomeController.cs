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
        [HttpPost]
        public ActionResult Index(string idEmploye)
        {
            Department department = ClientSideManager.RetriveCookieFromCollection(Request.Cookies, "client-department-selected") != null ? 
                new DepartmentRepository().GetDepartment(int.Parse(ClientSideManager.RetriveCookieFromCollection(Request.Cookies, "client-department-selected"))) :
                null;
            
            if (department != null)
            {
                Employe employe = new EmployeRepsitory().GetEmploye(int.Parse(idEmploye));

                AccessRegistry registry = new AccessRegistry();
                registry.Employe = employe;
                registry.Date = DateTime.Now;
                registry.Department = department;
                registry.IngressTicks = DateTime.Now.Ticks;
                registry.EgressTicks = 0;

                new AccessRegistryRepository().Add(registry);
            }

            return Redirect("/");
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