using ControlAccesoChecadorKioskoASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ControlAccesoChecadorKioskoASP.Services
{
    public class AccessTokenRepository
    {
        public void Add(AccessToken accessToken)
        {
            using (var db = new ControlAccessCheckerContext())
            {
                db.AccessTokens.Add(accessToken);
                db.SaveChanges();
            }
        }

        public void Delete(string accessTokenId)
        {
            using (var db = new ControlAccessCheckerContext())
            {
                //db.AccessTokens.Where(x => x.AccessTokenId == accessTokenId).;
                //db.AccessTokens.Remove(Get(accessTokenId));
                db.Entry(Get(accessTokenId)).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public AccessToken Get(string accessTokenId)
        {
            using (var db = new ControlAccessCheckerContext())
            {
                return db.AccessTokens.Where(x => x.AccessTokenId == accessTokenId).Include(x => x.Employe).FirstOrDefault();
            }
        }
        public AccessToken Get(int employeId)
        {
            using (var db = new ControlAccessCheckerContext())
            {
                return db.AccessTokens.Where(x => x.EmployeId == employeId).Include(x => x.Employe).FirstOrDefault();
            }
        }

        public List<AccessToken> RetriveAll()
        {
            using (var db = new ControlAccessCheckerContext())
            {
                return db.AccessTokens.Include(x => x.Employe).ToList();
            }
        }
    }
}