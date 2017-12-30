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
    public class LabourRequirementsController : Controller
    {
        private NBDCFEntities db = new NBDCFEntities();

        // GET: LabourRequirements
        public ActionResult Index()
        {

            return View(db.LabourRequirements.ToList());
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

            return View();
        }

        // POST: LabourRequirements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,desc,lregEstHour,lregCost,lregTime")] LabourRequirement labourRequirement)
        {


            if (ModelState.IsValid)
            {
                db.LabourRequirements.Add(labourRequirement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }



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
            var LabourRequirementsToUpdate = db.LabourRequirements.Find(id);
            if (TryUpdateModel(LabourRequirementsToUpdate, "",
                new string [] { "desc", "lregEstHour", "lregCost", "lregTime" }))
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
            return View(LabourRequirementsToUpdate);
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

        //private void PopulateDropDownLists(LabourRequirement labour = null)
        //{
        //    var dQuery = from l in db.TaskTests
        //                 orderby l.taskDesc
        //                 select l;
        //    ViewBag.TaskID = new SelectList(dQuery, "ID", "taskDesc", labour?.ID);
        //}



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
