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
    public class TaskTestsController : Controller
    {
        private NBDCFEntities db = new NBDCFEntities();

        // GET: TaskTests
        public ActionResult Index()
        {
            var taskTests = db.TaskTests.Include(t => t.LabourRequirement);
            return View(taskTests.ToList());
        }

        // GET: TaskTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskTest taskTest = db.TaskTests.Find(id);
            if (taskTest == null)
            {
                return HttpNotFound();
            }
            return View(taskTest);
        }

        // GET: TaskTests/Create
        public ActionResult Create()
        {
            ViewBag.labourRequirementID = new SelectList(db.LabourRequirements, "ID", "desc");
            return View();
        }

        // POST: TaskTests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,taskDesc,taskStdTImeAmnt,taskStdTimeUnit,labourRequirementID")] TaskTest taskTest)
        {
            if (ModelState.IsValid)
            {
                db.TaskTests.Add(taskTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.labourRequirementID = new SelectList(db.LabourRequirements, "ID", "desc", taskTest.labourRequirementID);
            return View(taskTest);
        }

        // GET: TaskTests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskTest taskTest = db.TaskTests.Find(id);
            if (taskTest == null)
            {
                return HttpNotFound();
            }
            ViewBag.labourRequirementID = new SelectList(db.LabourRequirements, "ID", "desc", taskTest.labourRequirementID);
            return View(taskTest);
        }

        // POST: TaskTests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,taskDesc,taskStdTImeAmnt,taskStdTimeUnit,labourRequirementID")] TaskTest taskTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.labourRequirementID = new SelectList(db.LabourRequirements, "ID", "desc", taskTest.labourRequirementID);
            return View(taskTest);
        }

        // GET: TaskTests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskTest taskTest = db.TaskTests.Find(id);
            if (taskTest == null)
            {
                return HttpNotFound();
            }
            return View(taskTest);
        }

        // POST: TaskTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskTest taskTest = db.TaskTests.Find(id);
            db.TaskTests.Remove(taskTest);
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
