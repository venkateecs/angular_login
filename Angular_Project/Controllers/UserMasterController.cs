using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Angular_Project.Models;

namespace Angular_Project.Controllers
{
    public class UserMasterController : ApiController
    {
        EmployeeEntities db = new EmployeeEntities();
        public List<user_master> get()
        {
            return db.user_master.ToList();
            db.SaveChanges();
        }
        public string post(user_master user)
        {
            db.user_master.Add(user);
            db.SaveChanges();
            return "Record Saved Successfully";
        }

        public string put(user_master user)
        {
            db.Entry(user).State = System.Data.EntityState.Modified;
            db.SaveChanges();
            return "Record Updated Successfully";
        }
        public string delete(int id)
        {
            db.user_master.Remove(db.user_master.Find(id));
            db.SaveChanges();
            return "Record Deleted Successfully";
        }

    }
}
