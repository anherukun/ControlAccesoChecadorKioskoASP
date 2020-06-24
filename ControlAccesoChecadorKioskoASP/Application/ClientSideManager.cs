using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlAccesoChecadorKioskoASP.Application
{
    public class ClientSideManager
    {
        public static object RetriveCookieFromCollection(HttpCookieCollection collection, string cookieContainter, string cookie)
        {
            object result = new object();

            if (collection.Count != 0)
            {
                for (int i = 0; i < collection.Get(cookieContainter).Values.Count; i++)
                    if (collection.Get(cookieContainter).Values.GetKey(i) == cookie)
                        result = collection.Get(cookieContainter).Values.Get(i);
            }

            return result;
        }
    }
}