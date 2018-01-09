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
    [Authorize(Roles = "Designer")]
    public class DesignerDailiesController : Controller
    {
        private NBDCFEntities db = new NBDCFEntities();

        // GET: DesignerDailies
        public ActionResult Index(string searchDate, int? projectID)
        {
            PopulateDropDownList();
            IQueryable<DesignerDaily> designerDailies = db.DesignerDailies;

            if (!projectID.HasValue)
            {
                projectID = 1;
            }

            if (!String.IsNullOrEmpty(searchDate))
            {
                var Date = Convert.ToDateTime(searchDate);
                designerDailies = designerDailies.Where(p => p.SubmitDate == Date && p.projectID == projectID);
                ViewBag.searchDate = searchDate;
            }
            else {
                designerDailies = designerDailies.Where(p => p.projectID == projectID);
            }
            return View(designerDailies.ToList());
        }

        // GET: DesignerDailies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignerDaily designerDaily = db.DesignerDailies.Find(id);
            if (designerDaily == null)
            {
                return HttpNotFound();
            }
            return View(designerDaily);
        }

        // GET: DesignerDailies/Create
        public ActionResult Create()
        {
            PopulateDropDownList();
            return View();
        }

        // POST: DesignerDailies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,hour,stage,taskID,projectID")] DesignerDaily designerDaily)
        {
            if (ModelState.IsValid)
            {
                db.DesignerDailies.Add(designerDaily);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateDropDownList(designerDaily);
            return View(designerDaily);
        }

        // GET: DesignerDailies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignerDaily designerDaily = db.DesignerDailies.Find(id);
            if (designerDaily == null)
            {
                return HttpNotFound();
            }
            PopulateDropDownList(designerDaily);
            return View(designerDaily);
        }

        // POST: DesignerDailies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,hour,stage,taskID,projectID")] DesignerDaily designerDaily)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designerDaily).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateDropDownList(designerDaily);
            return View(designerDaily);
        }

        // GET: DesignerDailies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignerDaily designerDaily = db.DesignerDailies.Find(id);
            if (designerDaily == null)
            {
                return HttpNotFound();
            }
            return View(designerDaily);
        }

        // POST: DesignerDailies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DesignerDaily designerDaily = db.DesignerDailies.Find(id);
            db.DesignerDailies.Remove(designerDaily);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateDropDownList(DesignerDaily daily = null)
        {
            var pQuery = from p in db.Projects
                         orderby p.projectName
                         select p;
            ViewBag.projectID = new SelectList(pQuery, "ID", "projectName", daily?.projectID);

            var tQuery = from t in db.TaskTests
                         orderby t.taskDesc
                         select t;
            ViewBag.taskID = new SelectList(tQuery, "ID", "taskDesc", daily?.taskID);
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
