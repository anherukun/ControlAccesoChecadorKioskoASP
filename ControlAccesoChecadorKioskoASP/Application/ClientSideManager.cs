using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlAccesoChecadorKioskoASP.Application
{
    public class ClientSideManager
    {
        public static string RetriveCookieFromCollection(HttpCookieCollection collection, string cookieName)
        {
            string result = null;

            if (collection.Count != 0)
            {
                for (int i = 0; i < collection.Count; i++)
                    if (collection[i].Name == cookieName)
                        return collection[i].Value;
            }

            return result;
        }
    }
}