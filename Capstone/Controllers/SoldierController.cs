﻿using Capstone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Capstone.ServiceReference1;


namespace Capstone.Controllers
{
    public class SoldierController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Soldier")]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var soldierInfo = (from c in db.Soldiers where c.ApplicationUserId.Equals(userId) select c);
            soldierInfo.ToList();
            return View(soldierInfo);
        }

        
        public ActionResult CreateProfile()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProfile([Bind(Include = "SoldierId,FirstName,LastName,Rank,SocialSecurityNumber,UnitNumber,Division,Leadership,StartDate,EndDate")] Soldier soldier)
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


        [Authorize(Roles = "Soldier")]
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
        public ActionResult EditPersonalInformation([Bind(Include = "SoldierId,FirstName,LastName,Rank,SocialSecurityNumber,UnitNumber,Division,Leadership,ApplicationUserId")] Soldier soldier)
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

        [Authorize(Roles = "Soldier")]
        public ActionResult SubmitPacket(int? id)
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
            ViewBag.Text = "Before you submit, ensure that all information and required forms are included in your packet.";
            return View(soldier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitPacket(Soldier soldier, Email email)
        {
            var sent = new HomeController().AutomatedMessageSoldier(email);
            var recieved = new HomeController().AutomatedMessageFirstSergeant(email);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Soldier")]
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
        public ActionResult AddDA31(Soldier soldier, HttpPostedFileBase upload)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var da31 = new Models.File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.DaForms,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            da31.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        soldier.Files = new List<Models.File> { da31};
                        soldier.LeaveForm = upload.FileName;
                        soldier.LeaveFormSubmission = true;
                        db.Entry(soldier).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }


                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = "Soldier")]
        public ActionResult SoldierInformation(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Soldier soldier = db.Soldiers.Include(f => f.Files).SingleOrDefault(s => s.SoldierId == id);
            if (soldier == null)
            {
                return HttpNotFound();
            }
            return View(soldier);
        }

        [Authorize(Roles = "Soldier")]
        public ActionResult DisplayDA31(int? id)
        {
            var select = db.Soldiers.Find(id);
            

            return File(select.LeaveForm, "application/pdf");
        }

        [Authorize(Roles = "Soldier")]
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
        public ActionResult AddLES(Soldier soldier, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var da31 = new Models.File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.DaForms,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            da31.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        soldier.Files = new List<Models.File> { da31 };
                        soldier.LES = upload.FileName;
                        soldier.LESSubmission = true;
                        db.Entry(soldier).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }


                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = "Soldier")]
        public ActionResult DisplayLES(int? id)
        {
            var select = db.Soldiers.Find(id);


            return File(select.LES, "application/pdf");
        }

        [Authorize(Roles = "Soldier")]
        public ActionResult AddTravelFile(int? id)
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
        public ActionResult AddTravelFile(Soldier soldier, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var da31 = new Models.File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.DaForms,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            da31.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        soldier.Files = new List<Models.File> { da31 };
                        soldier.TravelFileName = upload.FileName;
                        soldier.TravelInfo = true;
                        db.Entry(soldier).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }


                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = "Soldier")]
        public ActionResult DisplayTravelDocs(int? id)
        {
            var select = db.Soldiers.Find(id);


            return File(select.TravelFileName, "application/pdf");
        }

        [Authorize(Roles = "Soldier")]
        public ActionResult GoogleMap(int? id)
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
        public ActionResult AddGoogleMap(Soldier soldier)
        {
            return View();
        }

        [Authorize(Roles ="Soldier")]
        public ActionResult SetLeaveDays(int? id)
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
        public ActionResult SetLeaveDays(Soldier soldier)
        {
            var leave = (from l in db.Soldiers.Where(l => l.SoldierId == soldier.SoldierId) select l).FirstOrDefault();
            leave.StartDate = soldier.StartDate;
            leave.EndDate = soldier.EndDate;
            db.Entry(leave).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}