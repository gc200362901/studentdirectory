﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentDirectory.Models;

namespace StudentDirectory.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        //private StudentDirectoryModel db = new StudentDirectoryModel();
        private IMockStudentsRepository db;

        public StudentsController()
        {
            this.db = new EnityFrameworkStudentRepository();
        }

        public StudentsController(IMockStudentsRepository mockStudentsRepo)
        {
            this.db = mockStudentsRepo;
        }

        // GET: Students
        [OverrideAuthorization]
        public ActionResult Index()
        {
            return View(db.Students.OrderBy(s => s.LastName).ThenBy(s => s.FirstName).ToList());
        }

        // GET: Students/Details/5
        [OverrideAuthorization]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Student student = db.Students.SingleOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return View("Error");
            }
            return View(student);
        }

       // GET: Students/Courses
       //[OverrideAuthorization]
       // public ActionResult Courses(int? id)
       // {
       //     if (id == null)
       //     {
       //         return View("Error");
       //     }
       //     IEnumerable<Enrollment> courseEnrollment = db.Enrollments.Where(e => e.StudentId == id);
       //     if (courseEnrollment == null)
       //     {
       //         return View("Error");
       //     }
       //     return View(courseEnrollment);
       // }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,LastName,FirstName,Address,City,Province,Postal,Phone")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Save(student);
                return RedirectToAction("Index");
            }

            return View("Create", student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Student student = db.Students.SingleOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return View("Error");
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,LastName,FirstName,Address,City,Province,Postal,Phone")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Save(student);
                return RedirectToAction("Index");
            }
            return View("Edit", student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Student student = db.Students.SingleOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return View("Error");
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.SingleOrDefault(s => s.StudentId == id);
            db.Delete(student);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
