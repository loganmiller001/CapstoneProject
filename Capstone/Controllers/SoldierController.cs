﻿using Capstone.Models;
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
    public class SoldierController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Soldier
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var soldierInfo = (from c in db.Soldiers where c.SoldierId.Equals(userId) select c);
            soldierInfo.ToList();
            return View(soldierInfo);
        }

        // GET: Customers/Create
        public ActionResult CreateProfile()
        {
            return View();
        }

        // POST: Soldiers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProfile([Bind(Include = "SoldierId,FirstName,LastName,Rank,SocialSecurityNumber,UnitNumber,Division,Leadership")] Soldier soldier)
        {
            if (ModelState.IsValid)
            {
                soldier.ApplicationUserId = User.Identity.GetUserId();
                db.Soldiers.Add(soldier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(soldier);
        }


        // GET: Customers/Edit/5
        public ActionResult EditPersonalInformation(int? id)
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

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPersonalInformation([Bind(Include = "SoldierId,FirstName,LastName,Rank,SocialSecurityNumber,UnitNumber,Division,Leadership")] Soldier soldier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soldier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(soldier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult AddDA31(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDA31(Soldier soldier)
        {
            Soldier filePath = (from f in db.Soldiers where f.SoldierId == soldier.SoldierId select f).FirstOrDefault();
            if (ModelState.IsValid)
            {
                filePath.LeaveForm = soldier.LeaveForm;
                db.Entry(filePath).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult AddLES(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLES(Soldier soldier)
        {
            Soldier filePath = (from f in db.Soldiers where f.SoldierId == soldier.SoldierId select f).FirstOrDefault();
            if (ModelState.IsValid)
            {
                filePath.LES = soldier.LES;
                db.Entry(filePath).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}