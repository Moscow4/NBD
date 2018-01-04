using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NBDProject.Models;

namespace NBDProject.ViewModels
{
    public class ProductionPlanVM
    {
        public IList<Project> Project { get; set; }
        public IList<MaterialRequirement> MaterialRequirement { get; set; }
        public IList<ProjectTool> ProjectTool { get; set; }
        public IList<LabourRequirement> LabourRequirement { get; set; }
        public IList<LabourRequirementDesign> LabourRequirementDesign { get; set; }
        public IList<Client> Client { get; set; }
        public IList<ProjectTeam> ProjectTeam { get; set; }




    }
}