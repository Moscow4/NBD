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
    [Authorize(Roles = "Production Manager")]
    public class ProductionDailyLaborsController : Controller
    {
        private NBDCFEntities db = new NBDCFEntities();

        // GET: ProductionDailyLabors
        public ActionResult Index()
        {
            var productionDailyLabours = db.ProductionDailyLabours.Include(p => p.Project).Include(p => p.Task).Include(p=>p.LabourRequirement);
            return View(productionDailyLabours.ToList());
        }

        // GET: ProductionDailyLabors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionDailyLabor productionDailyLabor = db.ProductionDailyLabours.Find(id);
            if (productionDailyLabor == null)
            {
                return HttpNotFound();
            }
            return View(productionDailyLabor);
        }

        // GET: ProductionDailyLabors/Create
        public ActionResult Create()
        {
            PopulateDropdownList();
            return View();
        }

        // POST: ProductionDailyLabors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SubmitDate,Hours,HourCost,taskID,labourID,projectID")] ProductionDailyLabor productionDailyLabor)
        {
            if (ModelState.IsValid)
            {
                db.ProductionDailyLabours.Add(productionDailyLabor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateDropdownList(productionDailyLabor);
            return View(productionDailyLabor);
        }

        // GET: ProductionDailyLabors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionDailyLabor productionDailyLabor = db.ProductionDailyLabours.Find(id);
            if (productionDailyLabor == null)
            {
                return HttpNotFound();
            }
            PopulateDropdownList(productionDailyLabor);
            return View(productionDailyLabor);
        }

        // POST: ProductionDailyLabors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SubmitDate,Hours,HourCost,taskID,labourID,projectID")] ProductionDailyLabor productionDailyLabor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productionDailyLabor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateDropdownList(productionDailyLabor);
            return View(productionDailyLabor);
        }

        // GET: ProductionDailyLabors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionDailyLabor productionDailyLabor = db.ProductionDailyLabours.Find(id);
            if (productionDailyLabor == null)
            {
                return HttpNotFound();
            }
            return View(productionDailyLabor);
        }

        // POST: ProductionDailyLabors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductionDailyLabor productionDailyLabor = db.ProductionDailyLabours.Find(id);
            db.ProductionDailyLabours.Remove(productionDailyLabor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateDropdownList(ProductionDailyLabor dailyLabour = null)
        {
            var pQuery = from p in db.Projects
                         orderby p.projectName
                         select p;
            ViewBag.projectID = new SelectList(pQuery, "ID", "projectName", dailyLabour?.projectID);

            var tQuery = from t in db.TaskTests
                         orderby t.taskDesc
                         select t;
            ViewBag.taskID = new SelectList(tQuery, "ID", "taskDesc", dailyLabour?.taskID);

            var lQuery = from l in db.LabourRequirements
                         orderby l.Worker.FullName
                         select l;
            ViewBag.labourID = new SelectList(lQuery, "ID", "worker", dailyLabour?.labourID);
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
