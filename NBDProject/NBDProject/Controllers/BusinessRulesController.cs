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
    public class BusinessRulesController : Controller
    {
        private NBDCFEntities db = new NBDCFEntities();

        // GET: BusinessRules
        public ActionResult Index()
        {
            var businessRules = db.BusinessRules.Include(b => b.Project);
            return View(businessRules.ToList());
        }

        // GET: BusinessRules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessRule businessRule = db.BusinessRules.Find(id);
            if (businessRule == null)
            {
                return HttpNotFound();
            }
            return View(businessRule);
        }

        // GET: BusinessRules/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "projectName");
            return View();
        }

        // POST: BusinessRules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,designBid,productionPlanTotalCost,designPercent,ProjectID")] BusinessRule businessRule)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.BusinessRules.Add(businessRule);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to save changes after multiple attempts. Try again, and if the problem persists, see your system administrator.");
            }


            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "projectName", businessRule.ProjectID);
            return View(businessRule);
        }

        // GET: BusinessRules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessRule businessRule = db.BusinessRules.Find(id);
            if (businessRule == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "projectName", businessRule.ProjectID);
            return View(businessRule);
        }

        // POST: BusinessRules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,designBid,productionPlanTotalCost,designPercent,ProjectID")] BusinessRule businessRule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessRule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "projectName", businessRule.ProjectID);
            return View(businessRule);
        }

        // GET: BusinessRules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessRule businessRule = db.BusinessRules.Find(id);
            if (businessRule == null)
            {
                return HttpNotFound();
            }
            return View(businessRule);
        }

        // POST: BusinessRules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusinessRule businessRule = db.BusinessRules.Find(id);
            db.BusinessRules.Remove(businessRule);
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
