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
    public class FacultiesController : Controller
    {
        private Faculty_InformationEntities db = new Faculty_InformationEntities();

        // GET: Faculties
        public ActionResult Index()
        {
            var faculties = db.Faculties.Include(f => f.Department).Include(f => f.Designation).Include(f => f.User);
            return View(faculties.ToList());
        }
        public ActionResult FcView()
        {
            return View();
        }



        // GET: Faculties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.Faculties.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // GET: Faculties/Create
        public ActionResult Create()
        {
            ViewBag.DeptID = new SelectList(db.Departments, "DeptID", "DeptName");
            ViewBag.DesignationID = new SelectList(db.Designations, "DesignationID", "DesignationName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Password");
            return View();
        }

        // POST: Faculties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacultyID,FirstName,LastName,Address,City,State,Pincode,MobileNo,HireDate,EmailAddress,DateofBirth,DeptID,DesignationID,UserID")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                db.Faculties.Add(faculty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptID = new SelectList(db.Departments, "DeptID", "DeptName", faculty.DeptID);
            ViewBag.DesignationID = new SelectList(db.Designations, "DesignationID", "DesignationName", faculty.DesignationID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Password", faculty.UserID);
            return View(faculty);
        }

        // GET: Faculties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.Faculties.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptID = new SelectList(db.Departments, "DeptID", "DeptName", faculty.DeptID);
            ViewBag.DesignationID = new SelectList(db.Designations, "DesignationID", "DesignationName", faculty.DesignationID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Password", faculty.UserID);
            return View(faculty);
        }

        // POST: Faculties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacultyID,FirstName,LastName,Address,City,State,Pincode,MobileNo,HireDate,EmailAddress,DateofBirth,DeptID,DesignationID,UserID")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faculty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptID = new SelectList(db.Departments, "DeptID", "DeptName", faculty.DeptID);
            ViewBag.DesignationID = new SelectList(db.Designations, "DesignationID", "DesignationName", faculty.DesignationID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Password", faculty.UserID);
            return View(faculty);
        }

        // GET: Faculties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.Faculties.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // POST: Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faculty faculty = db.Faculties.Find(id);
            db.Faculties.Remove(faculty);
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
