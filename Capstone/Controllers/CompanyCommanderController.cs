using Capstone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Controllers
{
    public class CompanyCommanderController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: CompanyCommander
        public ActionResult Roster()
        {
            return View(db.Soldiers.ToList());
        }

        public ActionResult CommandOverride(int? id)
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
        public ActionResult CommandOverride(Soldier soldier, Email email)
        {
            var status = (from s in db.Soldiers where s.SoldierId == soldier.SoldierId select s).FirstOrDefault();
            status.PacketStatus = soldier.PacketStatus;
            db.Entry(status).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Contact", "Home");
        }

        public ActionResult CreateLeave()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLeave(CompanyCommander commander)
        {

            return RedirectToAction("roster");
        }
    }
}