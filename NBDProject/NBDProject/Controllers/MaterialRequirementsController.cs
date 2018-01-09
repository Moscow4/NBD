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
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Chief Designer, Production Manager, Production Worker, Group Manager")]
        public ActionResult Index(int? ProjectID)
        {
            PopulateDropDownList();
            var materialRequirements = db.MaterialRequirements.Include(m => m.Inventory).Include(m => m.Project);
            if (!ProjectID.HasValue)
            {
                ProjectID = 1;
            }
            if (ProjectID.HasValue)
            {
                materialRequirements = materialRequirements.Where(m => m.projectID == ProjectID);
            }
            return View(materialRequirements.ToList());
        }

        // GET: MaterialRequirements/Details/5
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Chief Designer, Production Manager, Group Manager")]
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
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Chief Designer, Group Manager")]
        public ActionResult Create()
        {
            PopulateDropDownList();
            return View();
        }

        // POST: MaterialRequirements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Chief Designer, Group Manager")]
        public ActionResult Create([Bind(Include = "ID,mreqQty, mreqDeliver,mreqInstall,projectID,inventoryID")] MaterialRequirement materialRequirement)
        {
            if (ModelState.IsValid)
            {
                db.MaterialRequirements.Add(materialRequirement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateDropDownList();
            return View(materialRequirement);
        }

        // GET: MaterialRequirements/Edit/5
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Chief Designer, Production Manager, Group Manager")]
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
            PopulateDropDownList(materialRequirement);
            return View(materialRequirement);
        }

        // POST: MaterialRequirements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Chief Designer, Production Manager, Group Manager")]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var materialRequirementToUpdate = db.MaterialRequirements.Find(id);
            if (TryUpdateModel(materialRequirementToUpdate, "",
                new string[] { "mreqQty", "mreqDeliver", "mreqInstall", "projectID", "inventoryID" }))
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

            PopulateDropDownList(materialRequirementToUpdate);
            return View(materialRequirementToUpdate);
        }

        // GET: MaterialRequirements/Delete/5
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Chief Designer, Production Manager, Group Manager")]
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
        [Authorize(Roles = "Admin, Admin Assistant, Designer, Chief Designer, Production Manager, Group Manager")]
        public ActionResult DeleteConfirmed(int id)
        {
            MaterialRequirement materialRequirement = db.MaterialRequirements.Find(id);
            try
            {
                db.MaterialRequirements.Remove(materialRequirement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(materialRequirement);
        }

        private void PopulateDropDownList(MaterialRequirement material = null)
        {
            var pQuery = from p in db.Projects
                         orderby p.projectName
                         select p;
            ViewBag.projectID = new SelectList(pQuery, "ID", "projectName", material?.projectID);

            var iQuery = from i in db.Inventory
                         orderby i.invCode, i.invDesc
                         select i;
            ViewBag.inventoryID = new SelectList(iQuery, "ID", "invDesc", material?.inventoryID);
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
