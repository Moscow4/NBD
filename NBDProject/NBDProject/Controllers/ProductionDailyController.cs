using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NBDProject.DAL;
using NBDProject.Models;
using NBDProject.ViewModels;

namespace NBDProject.Controllers
{
    [Authorize(Roles = "Production Manager")]
    public class ProductionDailyController : Controller
    {
        private NBDCFEntities db = new NBDCFEntities();
        // GET: ProductionDaily
        public ActionResult Index(int? projectID, string searchDate)
        {
            DateTime Date = DateTime.Today;

            var pQuery = from p in db.Projects
                         orderby p.projectName
                         select p;
            ViewBag.projectID = new SelectList(pQuery, "ID", "projectName");

            if (!projectID.HasValue)
            {
                projectID = 1;
            }
            if (!String.IsNullOrEmpty(searchDate))
            {
                Date = Convert.ToDateTime(searchDate);
                
            }

            
            var productionDailyLabour = (from pl in db.ProductionDailyLabours
                                         where pl.projectID == projectID
                                         select pl).ToList();
            var productionDailyMaterial = (from pm in db.ProductionDailyMaterials
                                           where pm.projectID == projectID 
                                           select pm).ToList();

            var ViewModel = new ProductionDailyVM
            {
                ProductionDailyLabor = productionDailyLabour,
                ProductionDailyMaterial = productionDailyMaterial

            };

            return View(ViewModel);
        }
    }
}