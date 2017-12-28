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
    public class MaterialRequirementsController : Controller
    {
        private NBDCFEntities db = new NBDCFEntities();

        // GET: MaterialRequirements
        public ActionResult Index()
        {
            var materialRequirements = db.MaterialRequirements.Include(m => m.Project);
            return View(materialRequirements.ToList());
        }

        // GET: MaterialRequirements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialRequirement materialRequirement = db.MaterialRequirements.Find(id);
            if (materialRequirement == null)
            {
                return HttpNotFound();
            }
            return View(materialRequirement);
        }

        // GET: MaterialRequirements/Create
        public ActionResult Create()
        {
            ViewBag.projectID = new SelectList(db.Projects, "ID", "projectName");
            return View();
        }

        // POST: MaterialRequirements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,mreqQty,mregCode,mregSize,mregNet,mregExtCost,mreqDeliver,mreqInstall,projectID")] MaterialRequirement materialRequirement)
        {
            if (ModelState.IsValid)
            {
                db.MaterialRequirements.Add(materialRequirement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.projectID = new SelectList(db.Projects, "ID", "projectName", materialRequirement.projectID);
            return View(materialRequirement);
        }

        // GET: MaterialRequirements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialRequirement materialRequirement = db.MaterialRequirements.Find(id);
            if (materialRequirement == null)
            {
                return HttpNotFound();
            }
            ViewBag.projectID = new SelectList(db.Projects, "ID", "projectName", materialRequirement.projectID);
            return View(materialRequirement);
        }

        // POST: MaterialRequirements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,mreqQty,mregCode,mregSize,mregNet,mregExtCost,mreqDeliver,mreqInstall,projectID")] MaterialRequirement materialRequirement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materialRequirement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.projectID = new SelectList(db.Projects, "ID", "projectName", materialRequirement.projectID);
            return View(materialRequirement);
        }

        // GET: MaterialRequirements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialRequirement materialRequirement = db.MaterialRequirements.Find(id);
            if (materialRequirement == null)
            {
                return HttpNotFound();
            }
            return View(materialRequirement);
        }

        // POST: MaterialRequirements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaterialRequirement materialRequirement = db.MaterialRequirements.Find(id);
            db.MaterialRequirements.Remove(materialRequirement);
            db.SaveChanges();
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
