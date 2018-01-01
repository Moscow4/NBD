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

    public class LabourRequirementDesignsController : Controller
    {
        private NBDCFEntities db = new NBDCFEntities();

        // GET: LabourRequirementDesigns
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Group Manager, Chief Designer")]
        public ActionResult Index(int? ProjectID)
        {
            PopulateDropDownList();
            var labourRequirementDesigns = db.LabourRequirementDesigns.Include(l => l.Project);
            if (!ProjectID.HasValue)
            {
                ProjectID = 1;
            }
            if (ProjectID.HasValue)
            {
                labourRequirementDesigns = labourRequirementDesigns.Where(l => l.projectID == ProjectID);
            }
            return View(labourRequirementDesigns.ToList());
        }

        // GET: LabourRequirementDesigns/Details/5
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Group Manager, Chief Designer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabourRequirementDesign labourRequirementDesign = db.LabourRequirementDesigns.Find(id);
            if (labourRequirementDesign == null)
            {
                return HttpNotFound();
            }
            return View(labourRequirementDesign);
        }

        // GET: LabourRequirementDesigns/Create
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Group Manager")]
        public ActionResult Create()
        {
            PopulateDropDownList();
            return View();
        }

        // POST: LabourRequirementDesigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Group Manager")]
        public ActionResult Create([Bind(Include = "ID,lregDHour,lregDDesc,lregDUnitPrice, lregDExtPrice,projectID")] LabourRequirementDesign labourRequirementDesign)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.LabourRequirementDesigns.Add(labourRequirementDesign);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            PopulateDropDownList(labourRequirementDesign);
            return View(labourRequirementDesign);
        }

        // GET: LabourRequirementDesigns/Edit/5
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Group Manager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabourRequirementDesign labourRequirementDesign = db.LabourRequirementDesigns.Find(id);
            if (labourRequirementDesign == null)
            {
                return HttpNotFound();
            }
            PopulateDropDownList(labourRequirementDesign);
            return View(labourRequirementDesign);
        }

        // POST: LabourRequirementDesigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Group Manager")]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var labourRequirementDesignToUpdate = db.LabourRequirementDesigns.Find(id);

            if (TryUpdateModel(labourRequirementDesignToUpdate, "",
                new string[] { "lregDHour", "lregDDesc", "lregDUnitPrice", "lregDExtPrice", "projectID" }))
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
            PopulateDropDownList(labourRequirementDesignToUpdate);
            return View(labourRequirementDesignToUpdate);
        }

        // GET: LabourRequirementDesigns/Delete/5
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Group Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabourRequirementDesign labourRequirementDesign = db.LabourRequirementDesigns.Find(id);
            if (labourRequirementDesign == null)
            {
                return HttpNotFound();
            }
            return View(labourRequirementDesign);
        }

        // POST: LabourRequirementDesigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Group Manager")]
        public ActionResult DeleteConfirmed(int id)
        {
            LabourRequirementDesign labourRequirementDesign = db.LabourRequirementDesigns.Find(id);
            try
            {
                db.LabourRequirementDesigns.Remove(labourRequirementDesign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(labourRequirementDesign);
        }

        private void PopulateDropDownList(LabourRequirementDesign labour = null)
        {
            var pQuery = from p in db.Projects
                         orderby p.projectName
                         select p;
            ViewBag.projectID = new SelectList(pQuery, "ID", "projectName", labour?.projectID);
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
