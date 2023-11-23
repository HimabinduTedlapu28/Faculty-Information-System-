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
    public class PublicationController : Controller
    {
        private Faculty_InformationEntities db = new Faculty_InformationEntities();

        // GET: Publication
        public ActionResult Index()
        {
            var publications = db.Publications.Include(p => p.Faculty);
            return View(publications.ToList());
        }

        // GET: Publication/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publication publication = db.Publications.Find(id);
            if (publication == null)
            {
                return HttpNotFound();
            }
            return View(publication);
        }

        // GET: Publication/Create
        public ActionResult Create()
        {
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FirstName");
            return View();
        }

        // POST: Publication/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PublicationID,FacultyID,PublicationTitle,ArticleName,PublisherName,PublicationLocation,PublishedDate")] Publication publication)
        {
            if (ModelState.IsValid)
            {
                db.Publications.Add(publication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FirstName", publication.FacultyID);
            return View(publication);
        }

        // GET: Publication/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publication publication = db.Publications.Find(id);
            if (publication == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FirstName", publication.FacultyID);
            return View(publication);
        }

        // POST: Publication/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PublicationID,FacultyID,PublicationTitle,ArticleName,PublisherName,PublicationLocation,PublishedDate")] Publication publication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FirstName", publication.FacultyID);
            return View(publication);
        }

        // GET: Publication/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publication publication = db.Publications.Find(id);
            if (publication == null)
            {
                return HttpNotFound();
            }
            return View(publication);
        }

        // POST: Publication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publication publication = db.Publications.Find(id);
            db.Publications.Remove(publication);
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
