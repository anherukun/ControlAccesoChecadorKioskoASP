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
            // List<Employe> Trabajadores = new List<Employe>();
            // Trabajadores.Add(new Employe(582509, "Angel Gerardo Jimenez Reyes"));
            // Trabajadores.Add(new Employe(229064, "Samuel Garcia Torres"));
            // Trabajadores.Add(new Employe(336035, "Erika Beatriz Cruz Silva"));
            // 
            ViewData["Employes"] = new EmployeRepsitory().RetriveAll();

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