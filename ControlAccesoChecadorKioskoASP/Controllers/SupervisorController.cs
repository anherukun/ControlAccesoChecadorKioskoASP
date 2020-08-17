using ControlAccesoChecadorKioskoASP.Application;
using ControlAccesoChecadorKioskoASP.Models;
using ControlAccesoChecadorKioskoASP.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlAccesoChecadorKioskoASP.Controllers
{
    public class SupervisorController : Controller
    {
        //https://medium.com/@minhazav/qr-code-scanner-using-html-and-javascript-3895a0c110cd
        // GET: Supervisor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AccessTokens()
        {
            List<AccessToken> accessTokens = new AccessTokenRepository().RetriveAll();
            ViewData["accessTokens"] = accessTokens;

            return View();
        }

        [HttpGet]
        public ActionResult AccessToken(string tkn)
        {
            if (tkn != null)
            {
                AccessToken token = new AccessTokenRepository().Get(ApplicationManager.Base64Decode(tkn));
                string json = "";
                if (token != null)
                {
                    json = JsonConvert.SerializeObject(token.AccessTokenId);
                    ViewData["AccessToken"] = token;
                    ViewData["accessTokenBytes"] = QRCodeManager.ToBytes(ApplicationManager.Base64Encode(json));
                }
                else
                    return Redirect(Url.Action("AccessTokens", "Supervisor"));
            }
            else
                return Redirect(Url.Action("AccessTokens", "Supervisor"));


            return View();
        }

        public ActionResult NewAccessToken()
        {
            ViewData["Employes"] = new EmployeRepsitory().RetriveAll();

            return View();
        }

        [HttpPost]
        public ActionResult SubmitAccessToken(int employeid = 0)
        {
            if (employeid != 0)
            {
                AccessToken token = new AccessTokenRepository().Get(employeid);
                string json = "";

                if (token == null)
                {
                    token = new AccessToken()
                    {
                        AccessTokenId = ApplicationManager.GenerateGUID,
                        EmployeId = employeid,
                        CreationDate = DateTime.Now.Ticks
                    };
                    new AccessTokenRepository().Add(token);
                    // json = JsonConvert.SerializeObject(token.AccessTokenId);

                    return Redirect(Url.Action("AccessTokens", "Supervisor"));
                }
                else
                    return Redirect(Url.Action("AccessTokens", "Supervisor"));                
            }
            else
                return Redirect(Url.Action("NewAccessToken", "Supervisor"));
        }

        public ActionResult RenewAccessToken(string tkn)
        {
            AccessToken accessToken = new AccessTokenRepository().Get(ApplicationManager.Base64Decode(tkn));
            Employe employe = accessToken.Employe;

            new AccessTokenRepository().Delete(ApplicationManager.Base64Decode(tkn));
            accessToken = new AccessToken()
            {
                AccessTokenId = ApplicationManager.GenerateGUID,
                EmployeId = employe.EmployeId,
                CreationDate = DateTime.Now.Ticks
            };
            new AccessTokenRepository().Add(accessToken);

            return Redirect(Url.Action("AccessTokens", "Supervisor"));
        }

        [HttpGet]
        public ActionResult DeleteAccessToken(string tkn)
        {
            new AccessTokenRepository().Delete(ApplicationManager.Base64Decode(tkn));
            return Redirect(Url.Action("AccessTokens", "Supervisor"));
        }
    }
}