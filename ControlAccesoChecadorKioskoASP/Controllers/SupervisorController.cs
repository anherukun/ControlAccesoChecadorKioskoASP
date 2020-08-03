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
        // GET: Supervisor
        //public ActionResult Index()
        //{
        //    return View();
        //}

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
            int employeid = 336035;
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
                json = JsonConvert.SerializeObject(token.AccessTokenId);
            } 
            else
            {
                token = new AccessTokenRepository().Get(employeid);
                json = JsonConvert.SerializeObject(token.AccessTokenId);
            }
            
            //byte[] qrcode = QRCodeManager.ToBytes(ApplicationManager.Base64Encode(json));
            //
            //
            //ViewData["imgbytes"] = qrcode;
            
            // return View();
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