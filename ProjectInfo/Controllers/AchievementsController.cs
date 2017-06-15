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
    public class AchievementsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult AchievementsOfProject(int? id)
        {
            var achievements = db.Achievements.Where(a => a.ProjectId == id);
            if (achievements == null) RedirectToAction("Index", "Home");
            achievements.ToList();
            var SortedAchievementsList = achievements.OrderByDescending(x => x.Update).ToList();
            return PartialView("_Achievements", SortedAchievementsList);
        }


        // GET: Achievements
        public ActionResult Index()
        {
            var achievements = db.Achievements.Include(a => a.SelectedProject);
            return View(achievements.ToList());
        }

        // GET: Achievements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achievement achievement = db.Achievements.Find(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            return View(achievement);
        }

        // GET: Achievements/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            return View();
        }

        // POST: Achievements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Update,ProjectId")] Achievement achievement)
        {
            if (ModelState.IsValid)
            {
                db.Achievements.Add(achievement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", achievement.ProjectId);
            return View(achievement);
        }
        //-------------------------------------------------------
        
        public ActionResult CreateForProject()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            return PartialView("_CreateForProject");
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateForProject([Bind(Include = "Id,Name,Update,ProjectId")] Achievement achievement)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Achievements.Add(achievement);
                    db.SaveChanges();
                    ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
                    return PartialView("_CreateForProject");
                }

                ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", achievement.ProjectId);
                return View(achievement);
            }
            catch (Exception)
            {
                return PartialView("_CreateForProject");
                //return RedirectToAction("CreateForProject");
            }

        }
        //------------------------------------------------
        // GET: Achievements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achievement achievement = db.Achievements.Find(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", achievement.ProjectId);
            return View(achievement);
        }

        // POST: Achievements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Update,ProjectId")] Achievement achievement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(achievement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", achievement.ProjectId);
            return View(achievement);
        }

        // GET: Achievements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achievement achievement = db.Achievements.Find(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            return View(achievement);
        }

        // POST: Achievements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Achievement achievement = db.Achievements.Find(id);
            db.Achievements.Remove(achievement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //------------------------------- Delete from Projects
        public ActionResult DeleteFromProjects(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achievement achievement = db.Achievements.Find(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            return View(achievement);
        }

        // POST: Achievements/DeleteFromProjects/5
        [HttpPost, ActionName("DeleteFromProjects")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFromProjects(int id)
        {
            Achievement achievement = db.Achievements.Find(id);
            db.Achievements.Remove(achievement);
            db.SaveChanges();
            return RedirectToAction("Details", "Projects", new { id = achievement.ProjectId });
        }
        //------------------------------------

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
