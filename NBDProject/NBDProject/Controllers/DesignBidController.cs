using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NBDProject.Models;
using NBDProject.DAL;
using NBDProject.ViewModels;
using System.Net;

namespace NBDProject.Controllers
{
    [Authorize(Roles = "Admin, Admin Assistant, Designer, Chief Designer, Group Manager")]
    public class DesignBidController : Controller
    {

        private NBDCFEntities db = new NBDCFEntities();
        // GET: DesignBd

        //Creat action Index
        public ActionResult Index(int ClientID = 1)
        {

            //if (!ClientID.HasValue)
            //{
            //    ClientID = 1;
            //}

            var Clients = (from c in db.Clients
                           where c.ID == ClientID
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

        //Create action Inspect
        public ActionResult Inspect(int? ProjectID)
        {


            if (ProjectID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
            if (ViewModel == null)
            {
                return HttpNotFound();
            }

            return View(ViewModel);
        }
    }
}