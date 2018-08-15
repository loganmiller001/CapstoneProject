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
            return View(db.Soldiers.ToList);
        }
    }
}