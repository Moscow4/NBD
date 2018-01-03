using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NBDProject.Models;
using NBDProject.DAL;
using NBDProject.ViewModels;


namespace NBDProject.Controllers
{
    public class DesignBidController : Controller
    {

        private NBDCFEntities db = new NBDCFEntities();
        // GET: DesignBd


        public ActionResult Index(int? ClientID)
        {

            if (!ClientID.HasValue)
            {
                ClientID = 1;
            }

            var Clients = (from c in db.Clients
                           select c).ToList();

            var Projects = (from p in db.Projects
                            where p.clientID == ClientID
                            select p).ToList();
            var LabourRequirementDesign = (from l in db.LabourRequirementDesigns
                                           select l).ToList();
            var MaterialRequirement = (from m in db.MaterialRequirements
                                       select m).ToList();

            var ViewModel = new DesignBidVM {
                Client = Clients,
                Project = Projects,
                LabourRequirementDesign = LabourRequirementDesign,
                MaterialRequirement = MaterialRequirement
            };


            return View(ViewModel);
        }

        public ActionResult Inspect(int? ProjectID)
        {


            if (!ProjectID.HasValue)
            {
                ProjectID = -1;
            }

            var LabourRequirementDesign = (from l in db.LabourRequirementDesigns
                                           where l.projectID == ProjectID
                                           select l).ToList();
            var MaterialRequirement = (from m in db.MaterialRequirements
                                       where m.projectID == ProjectID
                                       select m).ToList();
            //var ProjectTool = (from pt in db.ProjectTools
            //                   select pt).ToList();

            var ViewModel = new DesignBidVM
            {
                LabourRequirementDesign = LabourRequirementDesign,
                MaterialRequirement = MaterialRequirement,
                //ProjectTool = ProjectTool,
            };

            return View(ViewModel);
        }
    }
}