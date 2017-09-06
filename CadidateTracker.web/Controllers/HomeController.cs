using CadidateTracker.web.Models;
using CandidateTracker.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadidateTracker.web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCandidate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCandidate(string firstName, string lastName, string phoneNumber, string email, string notes)
        {
            var db = new CandidateRepository(Properties.Settings.Default.ConStr);
            db.AddCandidate(new Candidate
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Email = email,
                Notes = notes,
                Status = Status.Pending
            });
            return Redirect("/Home/Pending");
        }

        public ActionResult Pending()
        {
            var db = new CandidateRepository(Properties.Settings.Default.ConStr);
            return View(new CandidateViewModel { Candidates = db.GetCandidates(Status.Pending) });
        }

        public ActionResult Confirmed()
        {
            var db = new CandidateRepository(Properties.Settings.Default.ConStr);
            return View(new CandidateViewModel { Candidates = db.GetCandidates(Status.Confirmed) });
        }
        public ActionResult Refused()
        {
            var db = new CandidateRepository(Properties.Settings.Default.ConStr);
            return View(new CandidateViewModel { Candidates = db.GetCandidates(Status.Refused) });
        }

        public ActionResult Details(int id)
        {
            var db = new CandidateRepository(Properties.Settings.Default.ConStr);
            return View(new DetailsViewModel { Candidate = db.GetCandidate(id)});
        }

        [HttpPost]
        public void UpdateStatus(int id, bool confirmed)
        {
            var db = new CandidateRepository(Properties.Settings.Default.ConStr);
            var status = Status.Confirmed;
            if (!confirmed)
            {
                status = Status.Refused;
            }
            db.UpdateStatus(id, status);

        }

        public ActionResult UpdateCount()
        {
            var db = new CandidateRepository(Properties.Settings.Default.ConStr);
            return Json(new
            {
                pending = db.GetCount(Status.Pending),
                confirmed = db.GetCount(Status.Confirmed),
                refused = db.GetCount(Status.Refused)
            }, 
            JsonRequestBehavior.AllowGet);
        }
    }
}