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
    public class ProductionDailyMaterialsController : Controller
    {
        private NBDCFEntities db = new NBDCFEntities();

        // GET: ProductionDailyMaterials
        public ActionResult Index()
        {
            var productionDailyMaterials = db.ProductionDailyMaterials.Include(p => p.Project).Include(p => p.MaterialRequirement);
            return View(productionDailyMaterials.ToList());
        }

        // GET: ProductionDailyMaterials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionDailyMaterial productionDailyMaterial = db.ProductionDailyMaterials.Find(id);
            if (productionDailyMaterial == null)
            {
                return HttpNotFound();
            }
            return View(productionDailyMaterial);
        }

        // GET: ProductionDailyMaterials/Create
        public ActionResult Create()
        {
            PopulateDropdownList();
            return View();
        }

        // POST: ProductionDailyMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Qnty,UnitCost,SubmitDate,materialID,projectID")] ProductionDailyMaterial productionDailyMaterial)
        {
            if (ModelState.IsValid)
            {
                db.ProductionDailyMaterials.Add(productionDailyMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateDropdownList(productionDailyMaterial);
            return View(productionDailyMaterial);
        }

        // GET: ProductionDailyMaterials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionDailyMaterial productionDailyMaterial = db.ProductionDailyMaterials.Find(id);
            if (productionDailyMaterial == null)
            {
                return HttpNotFound();
            }
            PopulateDropdownList(productionDailyMaterial);
            return View(productionDailyMaterial);
        }

        // POST: ProductionDailyMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Qnty,UnitCost,SubmitDate,materialID,projectID")] ProductionDailyMaterial productionDailyMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productionDailyMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateDropdownList(productionDailyMaterial);
            return View(productionDailyMaterial);
        }

        // GET: ProductionDailyMaterials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionDailyMaterial productionDailyMaterial = db.ProductionDailyMaterials.Find(id);
            if (productionDailyMaterial == null)
            {
                return HttpNotFound();
            }
            return View(productionDailyMaterial);
        }

        // POST: ProductionDailyMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductionDailyMaterial productionDailyMaterial = db.ProductionDailyMaterials.Find(id);
            db.ProductionDailyMaterials.Remove(productionDailyMaterial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateDropdownList(ProductionDailyMaterial dailyMaterial = null)
        {
            var pQuery = from p in db.Projects
                         orderby p.projectName
                         select p;
            ViewBag.projectID = new SelectList(pQuery, "ID", "projectName", dailyMaterial?.projectID);

            var mQuery = from m in db.MaterialRequirements
                         orderby m.Inventory.invDesc
                         select m;
            ViewBag.materialID = new SelectList(mQuery, "ID", "desc", dailyMaterial?.materialID);

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
