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
    public class ProjectToolsController : Controller
    {
        private NBDCFEntities db = new NBDCFEntities();

        // GET: ProjectTools
        public ActionResult Index(int? ProjectID)
        {
            PopulateDropDownList();
            var projectTools = db.ProjectTools.Include(p => p.Project).Include(p => p.Tool);
            if (ProjectID.HasValue)
            {
                projectTools = projectTools.Where(p => p.projectID == ProjectID);
            }
            return View(projectTools.ToList());
        }

        // GET: ProjectTools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTool projectTool = db.ProjectTools.Find(id);
            if (projectTool == null)
            {
                return HttpNotFound();
            }
            return View(projectTool);
        }

        // GET: ProjectTools/Create
        public ActionResult Create()
        {
            PopulateDropDownList();
            return View();
        }

        // POST: ProjectTools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ptQty,ptDeliverFrom,ptDeliveryTo,projectID,toolID")] ProjectTool projectTool)
        {
            if (ModelState.IsValid)
            {
                db.ProjectTools.Add(projectTool);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateDropDownList(projectTool);
            return View(projectTool);
        }

        // GET: ProjectTools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTool projectTool = db.ProjectTools.Find(id);
            if (projectTool == null)
            {
                return HttpNotFound();
            }
            PopulateDropDownList(projectTool);
            return View(projectTool);
        }

        // POST: ProjectTools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ptQty,ptDeliverFrom,ptDeliveryTo,projectID,toolID")] ProjectTool projectTool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectTool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateDropDownList(projectTool);
            return View(projectTool);
        }

        // GET: ProjectTools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTool projectTool = db.ProjectTools.Find(id);
            if (projectTool == null)
            {
                return HttpNotFound();
            }
            return View(projectTool);
        }

        // POST: ProjectTools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectTool projectTool = db.ProjectTools.Find(id);
            db.ProjectTools.Remove(projectTool);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        private void PopulateDropDownList(ProjectTool projectTool = null)
        {
            var pQuery = from p in db.Projects
                         orderby p.projectName
                         select p;
            ViewBag.projectID = new SelectList(pQuery, "ID", "projectName", projectTool?.projectID);

            var tQuery = from t in db.Tools
                         orderby t.toolDesc
                         select t;
            ViewBag.toolID = new SelectList(tQuery, "ID", "toolDesc", projectTool?.toolID);
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
