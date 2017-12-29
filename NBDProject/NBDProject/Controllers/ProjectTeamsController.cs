using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NBDProject.DAL;
using NBDProject.Models;

namespace NBDProject.Controllers
{
    public class ProjectTeamsController : Controller
    {
        private NBDCFEntities db = new NBDCFEntities();

        // GET: ProjectTeams
        public ActionResult Index()
        {
            return View(db.ProjectTeams.ToList());
        }

        // GET: ProjectTeams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTeam projectTeam = db.ProjectTeams.Find(id);
            if (projectTeam == null)
            {
                return HttpNotFound();
            }
            return View(projectTeam);
        }

        // GET: ProjectTeams/Create
        public ActionResult Create()
        {
            PopulateDropDownList();
            return View();
        }

        // POST: ProjectTeams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,teamPhaseIn,projectID")] ProjectTeam projectTeam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ProjectTeams.Add(projectTeam);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");

            }

            PopulateDropDownList(projectTeam);
            return View(projectTeam);
        }

        // GET: ProjectTeams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTeam projectTeam = db.ProjectTeams.Find(id);
            if (projectTeam == null)
            {
                return HttpNotFound();
            }

            PopulateDropDownList(projectTeam);
            return View(projectTeam);
        }

        // POST: ProjectTeams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var projectTeamToUpdate = db.ProjectTeams.Find(id);
            if (TryUpdateModel(projectTeamToUpdate, "",
                new string[] { "teamPhaseIn", "projectID" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException dex)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }

            PopulateDropDownList(projectTeamToUpdate);
            return View(projectTeamToUpdate);
        }

        // GET: ProjectTeams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTeam projectTeam = db.ProjectTeams.Find(id);
            if (projectTeam == null)
            {
                return HttpNotFound();
            }
            return View(projectTeam);
        }

        // POST: ProjectTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectTeam projectTeam = db.ProjectTeams.Find(id);
            try
            {
                db.ProjectTeams.Remove(projectTeam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(projectTeam);
        }

        private void PopulateDropDownList(ProjectTeam team = null)
        {
            var tQuery = from t in db.Projects
                         orderby t.projectName
                         select t;
            ViewBag.projectID = new SelectList(tQuery, "ID", "teamPhaseIn", team?.projectID);
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
