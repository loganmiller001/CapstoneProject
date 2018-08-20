using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        public ActionResult ApproveDenyLeave(int? id)
        {
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Soldier soldier = db.Soldiers.Find(id);
                if (soldier == null)
                {
                    return HttpNotFound();
                }
                return View(soldier);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApproveDenyLeave(Soldier soldier, Email email)
        {
            var status = (from s in db.Soldiers where s.SoldierId == soldier.SoldierId select s).FirstOrDefault();
            status.PacketStatus = soldier.PacketStatus;
            db.Entry(status).State = EntityState.Modified;
            db.SaveChanges();
            var notification = new HomeController().ApprovalNotification(email, status);
            return RedirectToAction("Roster");
        }
    }
}