using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Angular_Project.Models;

namespace Angular_Project.Controllers
{
    public class emailsController : ApiController
    {
        EmployeeEntities1 db = new EmployeeEntities1();
        public List<email> get()
        {
            return db.emails.ToList();
            db.SaveChanges();
        }
        public string post(email email)
        {
            db.emails.Add(email);
            db.SaveChanges();
            return "Record Saved Successfully";
        }

        public string put(email email)
        {
            db.Entry(email).State = System.Data.EntityState.Modified;
            db.SaveChanges();
            return "Record Updated Successfully";
        }
        public string delete(int id)
        {
            db.emails.Remove(db.emails.Find(id));
            db.SaveChanges();
            return "Record Deleted Successfully";
        }

    }
}
