using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectInfo.Context;
using ProjectInfo.Models;

namespace ProjectInfo.Controllers
{
    public class ProjectManagersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: ProjectManagers
        public ActionResult Index()
        {
            return View(db.ProjectManagers.ToList());
        }

        public ActionResult _Contact()
        {
            return PartialView(db.ProjectManagers.ToList());
        }

        public ActionResult _AdminIndex()
        {
            return PartialView(db.ProjectManagers.ToList());
        }

        // GET: ProjectManagers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectManager projectManager = db.ProjectManagers.Find(id);
            if (projectManager == null)
            {
                return HttpNotFound();
            }
            return View(projectManager);
        }

        // GET: ProjectManagers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectManagers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email")] ProjectManager projectManager)
        {
            if (ModelState.IsValid)
            {
                db.ProjectManagers.Add(projectManager);
                db.SaveChanges();
                return RedirectToAction("Administration", "Home");
            }

            return View(projectManager);
        }

        // GET: ProjectManagers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectManager projectManager = db.ProjectManagers.Find(id);
            if (projectManager == null)
            {
                return HttpNotFound();
            }
            return View(projectManager);
        }

        // POST: ProjectManagers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email")] ProjectManager projectManager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectManager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Administration", "Home");
            }
            return View(projectManager);
        }

        // GET: ProjectManagers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectManager projectManager = db.ProjectManagers.Find(id);
            if (projectManager == null)
            {
                return HttpNotFound();
            }
            return View(projectManager);
        }

        // POST: ProjectManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectManager projectManager = db.ProjectManagers.Find(id);
            db.ProjectManagers.Remove(projectManager);
            db.SaveChanges();
            return RedirectToAction("Administration", "Home");
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
