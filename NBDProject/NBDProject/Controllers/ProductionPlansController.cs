using NBDProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NBDProject.Models;
using NBDProject.ViewModels;
using System.Net;

namespace NBDProject.Controllers
{
    [Authorize(Roles = "Admin, Admin Assistant, Production Manager, Chief Designer, Group Manager")]
    public class ProductionPlansController : Controller
    {
        private NBDCFEntities db = new NBDCFEntities();
        // GET: ProductionPlans
        public ActionResult Index(int? ClientID)
        {
            if (!ClientID.HasValue)
            {
                ClientID = -1;
            }
            var client = (from c in db.Clients
                          select c).ToList();
            var labourRequirement = (from l in db.LabourRequirements
                                     select l).ToList();
            var labourRequirementDesign = (from ld in db.LabourRequirementDesigns
                                           select ld).ToList();
            var materialRequirement = (from m in db.MaterialRequirements
                                       select m).ToList();
            var projectTeam = (from pt in db.ProjectTeams
                               select pt).ToList();
            var project = (from p in db.Projects
                           select p).ToList();
            var projectTool = (from po in db.ProjectTools
                               select po).ToList();
            var ViewModel = new ProductionPlanVM
            {
                Project = project,
                MaterialRequirement = materialRequirement,
                Client = client,
                LabourRequirement = labourRequirement,
                LabourRequirementDesign = labourRequirementDesign,
                ProjectTeam = projectTeam,
                ProjectTool = projectTool,
            };
            return View(ViewModel);
        }

        public ActionResult Inspect(int? ProjectID)
        {
            if (ProjectID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var labourRequirement = (from l in db.LabourRequirements
                                      where l.LabourRequirementDesign.projectID == ProjectID
                                      select l).ToList();
            var labourRequirementDesign = (from ld in db.LabourRequirementDesigns
                                            where ld.projectID == ProjectID
                                            select ld).ToList();
            var materialRequirement = (from m in db.MaterialRequirements
                                       where m.projectID == ProjectID
                                       select m).ToList();
            var projectTeam = (from pt in db.ProjectTeams
                               where pt.projectID == ProjectID
                               select pt).ToList();
            var projectTool = (from po in db.ProjectTools
                               where po.projectID == ProjectID
                               select po).ToList();
            var ViewModel = new ProductionPlanVM
            {
                LabourRequirement = labourRequirement,
                LabourRequirementDesign = labourRequirementDesign,
                ProjectTeam = projectTeam,
                MaterialRequirement = materialRequirement,
                ProjectTool = projectTool
            };
            if (ViewModel == null)
            {
                return HttpNotFound();
            }


            return View(ViewModel);
        }


    }
}