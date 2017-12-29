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
            PopulateDropDownLists();
            return View();
        }

        // POST: MaterialRequirements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,mreqQty,mregCode,mregSize,mregNet,mregExtCost,mreqDeliver,mreqInstall,projectID")] MaterialRequirement materialRequirement)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.MaterialRequirements.Add(materialRequirement);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            PopulateDropDownLists(materialRequirement);
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
            PopulateDropDownLists(materialRequirement);
            return View(materialRequirement);
        }

        // POST: MaterialRequirements/Edit/5
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
            var materialRequirementToUpdate = db.MaterialRequirements.Find(id);

            if (TryUpdateModel(materialRequirementToUpdate, "",
               new string[] { "mreqQty", "mregCode", "mregSize", "mregNet", "mregExtCost", "mreqDeliver", "mreqInstall", "projectID" }))
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

            PopulateDropDownLists(materialRequirementToUpdate);
            return View(materialRequirementToUpdate);
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
            try
            {
                db.MaterialRequirements.Remove(materialRequirement);
                db.SaveChanges();
            }
            catch (DataException dex)
            {
                if (dex.InnerException.InnerException.Message.Contains("FK_"))
                {
                    ModelState.AddModelError("", "You cannot delete a Material Requirement that has been posted.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            return View(materialRequirement);
        }

        private void PopulateDropDownLists(MaterialRequirement materialRequirement = null)
        {
            var pQuery = from l in db.Projects
                         orderby l.projectName, l.projectEstStart
                         select l;
            ViewBag.projectID = new SelectList(pQuery, "ID", "projectName", materialRequirement?.projectID);

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
