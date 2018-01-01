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
    public class ClientsController : Controller
    {
        private NBDCFEntities db = new NBDCFEntities();

        // GET: Clients
        public ActionResult Index()
        {
            var clients = db.Clients.Include(c => c.City);
            return View(clients.ToList());
        }

        // GET: Clients/Details/5
        [Authorize(Roles = "Admin, Admin Assistant, Sales")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        [Authorize(Roles = "Admin, Admin Assistant, Sales")]
        public ActionResult Create()
        {
            PopulateDropDownList();
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Admin Assistant, Sales")]
        public ActionResult Create([Bind(Include = "ID,cliName,cliAddress,cliProvince,cliCode,cliPhone,cliConFname,cliConLName,cliConPostion,cityID")] Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Clients.Add(client);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            } catch(DataException)
            {
                ModelState.AddModelError("", "Unable to save changes after multiple attempts. Try again, and if the problem persists, see your system administrator.");
            }

            PopulateDropDownList(client);
            return View(client);
        }

        // GET: Clients/Edit/5
        [Authorize(Roles = "Admin, Admin Assistant, Sales")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            PopulateDropDownList(client);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Admin Assistant, Sales")]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clientToUpdate = db.Clients.Find(id);
            if (TryUpdateModel(clientToUpdate, "",
                new string[] { "cliName", "cliAddress", "cliProvince", "cliCode", "cliPhone", "cliConFname", "cliConLname", "cliConPostion", "cityID" }))
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
            return View(clientToUpdate);
        }

        // GET: Clients/Delete/5
        [Authorize(Roles = "Admin, Admin Assistant, Sales")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Admin Assistant, Sales")]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            try
            {
                db.Clients.Remove(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(client);
        }

        private void PopulateDropDownList(Client client = null)
        {
            var cQuery = from c in db.Cities
                         orderby c.city
                         select c;
            ViewBag.cityID = new SelectList(cQuery, "ID", "city", client?.cityID);
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
