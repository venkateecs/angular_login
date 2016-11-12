using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Angular_Project.Models;

namespace Angular_Project.Controllers
{
    public class mail_boxController : ApiController
    {
        mail_box_entities db = new mail_box_entities();

        public List<mail_box> get()
        {
            return db.mail_box.ToList();
            db.SaveChanges();
        }
        public string post(mail_box mail_box)
        {
            db.mail_box.Add(mail_box);
            db.SaveChanges();
            return "Record Saved Successfully";
        }

        public string put(mail_box mail_box)
        {
            db.Entry(mail_box).State = System.Data.EntityState.Modified;
            db.SaveChanges();
            return "Record Updated Successfully";
        }
        public string delete(int id)
        {
            db.mail_box.Remove(db.mail_box.Find(id));
            db.SaveChanges();
            return "Record Deleted Successfully";
        }

    }
}
