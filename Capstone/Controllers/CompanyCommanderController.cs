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

        public ActionResult CreateLeave(int? id, CompanyCommander commander)
        {
            var user = User.Identity.GetUserId();
            commander = db.CompanyCommander.Where(c => c.ApplicationUserId == user).First();
            return View(commander);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLeave(CompanyCommander commander)
        {
            var leave = (from l in db.CompanyCommander.Where(l => l.CommanderId == commander.CommanderId) select l).FirstOrDefault();
            leave.StartLeave = commander.StartLeave;
            leave.EndLeave = commander.EndLeave;
            db.Entry(leave).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Roster");
        }
    }
}