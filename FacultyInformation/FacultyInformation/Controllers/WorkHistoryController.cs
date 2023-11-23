using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FacultyInformation.Models;

namespace FacultyInformation.Controllers
{
    public class WorkHistoryController : Controller
    {
        private Faculty_InformationEntities db = new Faculty_InformationEntities();

        // GET: WorkHistory
        public ActionResult Index()
        {
            var workHistories = db.WorkHistories.Include(w => w.Faculty);
            return View(workHistories.ToList());
        }

        // GET: WorkHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkHistory workHistory = db.WorkHistories.Find(id);
            if (workHistory == null)
            {
                return HttpNotFound();
            }
            return View(workHistory);
        }

        // GET: WorkHistory/Create
        public ActionResult Create()
        {
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FirstName");
            return View();
        }

        // POST: WorkHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkHistoryID,FacultyID,Organization,JobTitle,JobBeginDate,JobEndDate,JobResponsibilities,JobType")] WorkHistory workHistory)
        {
            if (ModelState.IsValid)
            {
                db.WorkHistories.Add(workHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FirstName", workHistory.FacultyID);
            return View(workHistory);
        }

        // GET: WorkHistory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkHistory workHistory = db.WorkHistories.Find(id);
            if (workHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FirstName", workHistory.FacultyID);
            return View(workHistory);
        }

        // POST: WorkHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkHistoryID,FacultyID,Organization,JobTitle,JobBeginDate,JobEndDate,JobResponsibilities,JobType")] WorkHistory workHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FirstName", workHistory.FacultyID);
            return View(workHistory);
        }

        // GET: WorkHistory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkHistory workHistory = db.WorkHistories.Find(id);
            if (workHistory == null)
            {
                return HttpNotFound();
            }
            return View(workHistory);
        }

        // POST: WorkHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkHistory workHistory = db.WorkHistories.Find(id);
            db.WorkHistories.Remove(workHistory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}