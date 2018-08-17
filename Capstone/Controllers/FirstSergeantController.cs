using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Controllers
{
    public class FirstSergeantController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: FirstSergeant
        public ActionResult Roster()
        {
            return View(db.Soldiers.ToList());
        }

        public ActionResult ViewLES(int? id)
        {
            var select = db.Soldiers.Find(id);


            return File(select.LES, "application/pdf");
        }

        public ActionResult ViewDA31(int? id)
        {
            var select = db.Soldiers.Find(id);


            return File(select.LeaveForm, "application/pdf");
        }

        public ActionResult ViewTravelDocs(int? id)
        {
            var select = db.Soldiers.Find(id);


            return File(select.TravelFileName, "application/pdf");
        }
    }
}