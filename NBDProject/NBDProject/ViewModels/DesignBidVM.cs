using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NBDProject.Models;

namespace NBDProject.ViewModels
{
    public class DesignBidVM
    {
        public IList<Client> Client { get; set; }
        public IList<Worker> Worker { get; set; }
        public IList<Project> Project { get; set; }
        public IList<LabourRequirementDesign> LabourRequirementDesign { get; set; }
        public IList<LabourRequirement> LabourRequirement { get; set; }
        public IList<MaterialRequirement> MaterialRequirement { get; set; }
        public IList<ProjectTool> ProjectTool { get; set; }


    }
}