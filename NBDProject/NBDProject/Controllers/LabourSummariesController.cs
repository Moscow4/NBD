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
using System.Data.Entity.Infrastructure;

namespace NBDProject.Controllers
{
    public class LabourSummariesController : Controller
    {
        private NBDCFEntities db = new NBDCFEntities();

        // GET: LabourSummaries
        public ActionResult Index(int? ProjectID)
        {
            PopulateDropDownLists();
            ViewBag.Filtering = "";
            var labourSummaries = db.LabourSummaries.Include(l => l.Project).Include(n => n.WorkType);
            if (ProjectID.HasValue)
            {
                labourSummaries = labourSummaries.Where(p => p.projectID == ProjectID);
                ViewBag.Filteing = " in";
                ViewBag.LastProjectID = ProjectID;
            }
            return View(labourSummaries.ToList());
        }

        // GET: LabourSummaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabourSummary labourSummary = db.LabourSummaries.Find(id);
            if (labourSummary == null)
            {
                return HttpNotFound();
            }
            return View(labourSummary);
        }

        // GET: LabourSummaries/Create
        public ActionResult Create()
        {
            PopulateDropDownLists();
            return View();
        }

        // POST: LabourSummaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,lsHours,projectID,workerTypeID")] LabourSummary labourSummary)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.LabourSummaries.Add(labourSummary);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            PopulateDropDownLists(labourSummary);
            return View(labourSummary);
        }

        // GET: LabourSummaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabourSummary labourSummary = db.LabourSummaries.Find(id);
            if (labourSummary == null)
            {
                return HttpNotFound();
            }
            PopulateDropDownLists(labourSummary);
            return View(labourSummary);
        }

        // POST: LabourSummaries/Edit/5
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
            var labourSummaryToUpdate = db.LabourSummaries.Find(id);
            if (TryUpdateModel(labourSummaryToUpdate, "",
                new string[] { "lsHOurs", "projectID", "workerTypeID" }))
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

            PopulateDropDownLists(labourSummaryToUpdate);
            return View(labourSummaryToUpdate);
        }

        // GET: LabourSummaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabourSummary labourSummary = db.LabourSummaries.Find(id);
            if (labourSummary == null)
            {
                return HttpNotFound();
            }
            return View(labourSummary);
        }

        // POST: LabourSummaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LabourSummary labour = db.LabourSummaries.Find(id);
            try
            {
                db.LabourSummaries.Remove(labour);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (DataException dex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(labour);
        }

        private void PopulateDropDownLists(LabourSummary labour = null)
        {
            
            ViewBag.projectID = new SelectList(db.Projects.OrderBy(p => p.projectName), "ID", "projectName", labour?.projectID);
            ViewBag.workerTypeID = new SelectList(db.WorkTypes.OrderBy(w => w.workTypeDesc), "ID", "workTypeDesc", labour?.workerTypeID);
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
