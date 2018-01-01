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
using NBDProject.ViewModels;

namespace NBDProject.Controllers
{
    [Authorize(Roles = "Admin, Admin Assistant, Production Manager, Chief Designer")]
    public class ProjectTeamsController : Controller
    {
        private NBDCFEntities db = new NBDCFEntities();

        // GET: ProjectTeams
        public ActionResult Index(int? ProjectID)
        {
            PopulateDropDownList();
            var projectTeam = db.ProjectTeams.Include(p => p.project);
            if (!ProjectID.HasValue)
            {
                ProjectID = 1;
            }
            if (ProjectID.HasValue)
            {
                projectTeam = projectTeam.Where(p => p.projectID == ProjectID);
            }
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
            var projectTeam = new ProjectTeam();
            projectTeam.Workers = new List<Worker>();

            PopulateAssignedSkillData(projectTeam);
            PopulateDropDownList();
            
            return View();
        }

        private void PopulateAssignedSkillData(ProjectTeam projectTeam)
        {
            var allWorkers = db.Workers;
            var pWorkers = new HashSet<int>(projectTeam.Workers.Select(s => s.ID));
            var viewModel = new List<WorkerVM>();
            foreach (var con in allWorkers)
            {
                viewModel.Add(new WorkerVM
                {
                    WorkerID = con.ID,
                    WorkerFullName = con.FullName,
                    Assigned = pWorkers.Contains(con.ID)
                });
            }
            ViewBag.Workers = viewModel;
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
            PopulateAssignedSkillData(projectTeam);
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

            PopulateAssignedSkillData(projectTeamToUpdate);
            PopulateDropDownList(projectTeamToUpdate);
            return View(projectTeamToUpdate);
        }

        private void UpdateProjectTeamWorkers(string[] selectedWokers, ProjectTeam projectTeamToUpdate)
        {
            if (selectedWokers == null)
            {
                projectTeamToUpdate.Workers = new List<Worker>();
                return;
            }

            var selectedWorkerHS = new HashSet<string>(selectedWokers);
            var ProjectTeamWorkers = new HashSet<int>
                (projectTeamToUpdate.Workers.Select(s => s.ID));
            foreach (var worker in db.Workers)
            {
                if (selectedWorkerHS.Contains(worker.ID.ToString()))
                {
                    if (!ProjectTeamWorkers.Contains(worker.ID))
                    {
                        projectTeamToUpdate.Workers.Add(worker);
                    }
                }
                else
                {
                    if (ProjectTeamWorkers.Contains(worker.ID))
                    {
                        projectTeamToUpdate.Workers.Remove(worker);
                    }
                }
            }
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
            ViewBag.projectID = new SelectList(tQuery, "ID", "projectName", team?.projectID);
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
