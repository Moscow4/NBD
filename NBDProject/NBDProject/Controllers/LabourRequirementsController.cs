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
    [Authorize(Roles = "Admin, Admin Assistant, Production Manager, Chief Designer")]
    public class LabourRequirementsController : Controller
    {
        private NBDCFEntities db = new NBDCFEntities();

        // GET: LabourRequirements
        public ActionResult Index(int? LabourRequirementDesignID)
        {
            PopulateDropDownList();
            var labourRequirements = db.LabourRequirements.Include(l => l.LabourRequirementDesign).Include(l => l.Task).Include(l => l.Worker);
            if (LabourRequirementDesignID.HasValue)
            {
                labourRequirements = labourRequirements.Where(l => l.LabourRequirementDesignID == LabourRequirementDesignID);
            }
            return View(labourRequirements.ToList());
        }

        // GET: LabourRequirements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabourRequirement labourRequirement = db.LabourRequirements.Find(id);
            if (labourRequirement == null)
            {
                return HttpNotFound();
            }

            return View(labourRequirement);
        }

        // GET: LabourRequirements/Create
        public ActionResult Create()
        {
            PopulateDropDownList();
            return View();
        }

        // POST: LabourRequirements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,lregProdHour,lregCost,lregEstCost, lregTime,TaskID,WorkerID,LabourRequirementDesignID")] LabourRequirement labourRequirement)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.LabourRequirements.Add(labourRequirement);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            PopulateDropDownList(labourRequirement);
            return View(labourRequirement);
        }

        // GET: LabourRequirements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabourRequirement labourRequirement = db.LabourRequirements.Find(id);
            if (labourRequirement == null)
            {
                return HttpNotFound();
            }
            PopulateDropDownList(labourRequirement);
            return View(labourRequirement);
        }

        // POST: LabourRequirements/Edit/5
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
            var labourRequirementToUpdate = db.LabourRequirements.Find(id);
            if (TryUpdateModel(labourRequirementToUpdate, "",
                new string[] { "lregProdHour", "lregCost", "lregEstCost", "lregTime", "TaskID", "WorkerID", "LabourRequirementDesignID" }))
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

            PopulateDropDownList(labourRequirementToUpdate);
            return View(labourRequirementToUpdate);
        }

        // GET: LabourRequirements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabourRequirement labourRequirement = db.LabourRequirements.Find(id);
            if (labourRequirement == null)
            {
                return HttpNotFound();
            }
            return View(labourRequirement);
        }

        // POST: LabourRequirements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LabourRequirement labourRequirement = db.LabourRequirements.Find(id);
            try
            {
                db.LabourRequirements.Remove(labourRequirement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(labourRequirement);
        }

        private void PopulateDropDownList(LabourRequirement labour = null)
        {
            var tQuery = from t in db.TaskTests
                         orderby t.taskDesc
                         select t;
            ViewBag.TaskID = new SelectList(tQuery, "ID", "taskDesc", labour?.TaskID);

            var wQuery = from w in db.Workers
                         orderby w.LName, w.FName
                         select w;
            ViewBag.WorkerID = new SelectList(wQuery, "ID", "FullName", labour?.WorkerID);

            var lQuery = from l in db.LabourRequirementDesigns
                         orderby l.lregDDesc
                         select l;
            ViewBag.LabourRequirementDesignID = new SelectList(lQuery, "ID", "LregDsummary", labour?.LabourRequirementDesignID);
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
