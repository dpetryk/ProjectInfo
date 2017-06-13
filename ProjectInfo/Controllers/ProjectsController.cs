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
using System.IO;

namespace ProjectInfo.Controllers
{
    public class ProjectsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Projects
        public ActionResult Index()
        {
            var projects = db.Projects.Include(p => p.SelectedPM).Include(p => p.SelectedTeam);
            return View(projects.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            ViewBag.ProjectManagerId = new SelectList(db.ProjectManagers, "Id", "Name");
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,TeamId,ProjectManagerId,StartDate,DeliveryDate,Status,Priority,Effort,DeliveryStatus,Overview,Risks")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectManagerId = new SelectList(db.ProjectManagers, "Id", "Name", project.ProjectManagerId);
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", project.TeamId);
            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectManagerId = new SelectList(db.ProjectManagers, "Id", "Name", project.ProjectManagerId);
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", project.TeamId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TeamId,ProjectManagerId,StartDate,DeliveryDate,Status,Priority,Effort,DeliveryStatus,Overview,Risks")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectManagerId = new SelectList(db.ProjectManagers, "Id", "Name", project.ProjectManagerId);
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", project.TeamId);
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();

            DirectoryInfo dir = new DirectoryInfo((Server.MapPath("~/Content/files/") + id));
            FileInfo[] files = dir.GetFiles("*.*");
            foreach (var item in files)
            {
                item.Delete();
            }
            dir.Delete();

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
