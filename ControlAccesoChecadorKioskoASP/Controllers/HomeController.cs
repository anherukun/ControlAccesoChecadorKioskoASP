using Antlr.Runtime.Misc;
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
            int registryLimit = ClientSideManager.RetriveCookieFromCollection(Request.Cookies, "client-registry-count") != null ?
                int.Parse(ClientSideManager.RetriveCookieFromCollection(Request.Cookies, "client-registry-count")) : 0;
            Department department = ClientSideManager.RetriveCookieFromCollection(Request.Cookies, "client-department-selected") != null ?
                new DepartmentRepository().GetDepartment(int.Parse(ClientSideManager.RetriveCookieFromCollection(Request.Cookies, "client-department-selected"))) :
                null;
            List<AccessRegistry> accessRegistries = department != null ? new AccessRegistryRepository().RetriveByDepartment(department.DepartmentId, registryLimit) :
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
                registry.EmployeId = employe.EmployeId;
                registry.Date = DateTime.Now;
                registry.DepartmentId = department.DepartmentId;
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