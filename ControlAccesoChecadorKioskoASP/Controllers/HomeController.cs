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
        [HttpGet]
        public ActionResult Index(string msgType, string msgString)
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

            if (msgType != null && msgString != null)
            {
                msgString = ApplicationManager.Base64Decode(msgString);
                ViewData["message"] = new { msgType, msgString };
            }


            return View();
        }
        [HttpPost]
        public ActionResult SubmitIngress(int idEmploye)
        {
            Department department = ClientSideManager.RetriveCookieFromCollection(Request.Cookies, "client-department-selected") != null ? 
                new DepartmentRepository().GetDepartment(int.Parse(ClientSideManager.RetriveCookieFromCollection(Request.Cookies, "client-department-selected"))) :
                null;
            
            if (department != null)
            {
                AccessRegistry registry = new AccessRegistry();
                registry.EmployeId = idEmploye;
                registry.Date = DateTime.Now;
                registry.DepartmentId = department.DepartmentId;
                registry.IngressTicks = DateTime.Now.Ticks;
                registry.EgressTicks = 0;
                
                new AccessRegistryRepository().Add(registry);
                
                return Redirect(Url.Action("Index", "Home", new { msgType = "success", msgString = ApplicationManager.Base64Encode("El acceso se registro correctamente") }));
            } else 
                return Redirect("/");
        }
        [HttpPost]
        public ActionResult SubmitEgress(int idAccessRegistry)
        {
            AccessRegistry registry = new AccessRegistryRepository().GetRegistry(idAccessRegistry);
            registry.EgressTicks = DateTime.Now.Ticks;

            new AccessRegistryRepository().Update(registry);

            return Redirect(Url.Action("Index", "Home", new { msgType = "success", msgString = ApplicationManager.Base64Encode("La salida se registro correctamente") }));
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