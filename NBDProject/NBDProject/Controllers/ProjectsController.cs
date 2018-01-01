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
    [Authorize]

    public class ProjectsController : Controller
    {
        private NBDCFEntities db = new NBDCFEntities();

        // GET: Projects
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Chief Designer, Production Manager, Group Manager")]
        public ActionResult Index()
        {
            var projects = db.Projects.Include(p => p.Client);


            return View(projects.ToList());
        }

        // GET: Projects/Details/5
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Chief Designer, Production Manager, Group Manager")]
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
        [Authorize(Roles = "Admin, Admin Assistant, Designer")]
        public ActionResult Create()
        {
            PopulateDropDownList();
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Admin Assistant, Designer")]
        public ActionResult Create([Bind(Include = "ID,projectName,projectSite,projectBidDate,projectEstStart,projectEstEnd,projectActStart,projectActEnd,projectEstCost,projectActCost,projectBidCustAccept,projectBidMgmtAccept, projectChiefDesignAccept ,projectCurrentPhase,projectFlagged,clientID")] Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Projects.Add(project);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            PopulateDropDownList(project);
            return View(project);
        }

        // GET: Projects/Edit/5
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Chief Designer, Group Manager")]
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
            PopulateDropDownList(project);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Chief Designer, Group Manager")]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var projectToUpdate = db.Projects.Find(id);
            if (TryUpdateModel(projectToUpdate, "",
                new string[] { "projectName", "projectSite", "projectBidDate", "projectEstStart", "projectEstEnd", "projectActStart", "projectActEnd", "projectEstCost", "projectActCost", "projectBidCustAccept", "projectBidMgmtAccept", "projectChiefDesignAccept","projectCureentPhase", "projectFlagged", "ClientID" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }

            PopulateDropDownList(projectToUpdate);
            return View(projectToUpdate);
        }

        // GET: Projects/Delete/5
        [Authorize(Roles = "Admin, Admin Assistant, Chief Designer, Group Manager")]
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
        [Authorize(Roles = "Admin, Admin Assistant, Chief Designer, Group Manager")]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            try
            {
                db.Projects.Remove(project);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(project);
        }

        private void PopulateDropDownList(Project project = null)
        {
            var cQuery = from c in db.Clients
                         orderby c.cliName , c.cliConLName, c.cliConLName
                         select c;
            ViewBag.clientID = new SelectList(cQuery, "ID", "cliName", project?.clientID);
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
