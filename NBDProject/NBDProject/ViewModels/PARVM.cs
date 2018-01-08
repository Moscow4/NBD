using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NBDProject.Models;
using NBDProject.ViewModels;

namespace NBDProject.ViewModels
{
    public class PARVM
    {
        public IList<Client> Client { get; set; }
        public IList<Worker> Worker { get; set; }
        public IList<Project> ProjectProductionStage { get; set; }
        public IList<LabourRequirementDesign> LabourRequirementDesign { get; set; }
        public IList<LabourRequirement> LabourRequirement { get; set; }
        public IList<MaterialRequirement> MaterialRequirement { get; set; }
        public IList<ProjectTool> ProjectTool { get; set; }
        public IList<ProjectTeam> ProjectTeam { get; set; }
        public IList<Project> ProjectDesignBidStage { get; set; }
    }
}