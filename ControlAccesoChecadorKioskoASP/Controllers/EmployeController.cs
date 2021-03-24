using ControlAccesoChecadorKioskoASP.Models;
using ControlAccesoChecadorKioskoASP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlAccesoChecadorKioskoASP.Controllers
{
    public class EmployeController : Controller
    {
        // GET: Employe
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employe employe)
        {
            if (true)
            {
                new EmployeRepsitory().Add(employe);

                return Redirect(Url.Action());
            }
            return Redirect(Url.Action());
        }

        [HttpPost]
        public ActionResult Update(Employe employe)
        {
            if (true)
            {
                new EmployeRepsitory().Update(employe);

                return Redirect(Url.Action());
            }
            return Redirect(Url.Action());
        }

        [HttpPost]
        public ActionResult Delete()
        {
            return Redirect(Url.Action());
        }
    }
}
