using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NBDProject.ViewModels;
using NBDProject.Models;
using NBDProject.DAL;

namespace NBDProject.Controllers
{
    public class PARController : Controller
    {
        private NBDCFEntities db = new NBDCFEntities();
        // GET: PAR
        public ActionResult Index()
        {
            var materialRequirement = (from m in db.MaterialRequirements
                                       select m).ToList();
            var labourRequirementDesign = (from ld in db.LabourRequirementDesigns
                                           select ld).ToList();
            var labourRequirement = (from l in db.LabourRequirements
                                     select l).ToList();
            var projectProductionStage = (from pp in db.Projects
                                          where pp.projectFlagged == true
                                          select pp).ToList();
            var projectDesignBidStage = (from pd in db.Projects
                                         where pd.projectFlagged == false
                                         select pd).ToList();
            var ViewModel = new PARVM
            {
                MaterialRequirement = materialRequirement,
                LabourRequirementDesign = labourRequirementDesign,
                LabourRequirement = labourRequirement,
                ProjectDesignBidStage = projectDesignBidStage,
                ProjectProductionStage = projectProductionStage

            };
            return View(ViewModel);
        }
    }
}