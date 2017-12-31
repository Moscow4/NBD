using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class LabourRequirementDesign
    {
        public LabourRequirementDesign() {
            this.LabourRequirements = new HashSet<LabourRequirement>();
        }


        public int ID { get; set; }

        [Required(ErrorMessage = "Hour is required.")]
        [Display(Name = "Hour")]
        public int lregDHour { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        public string lregDDesc { get; set; }

        [Required(ErrorMessage = "Unit Price is required.")]
        [Display(Name = "Unit Price")]
        public decimal lregDUnitPrice { get; set; }

        [Display(Name = "Extended Price")]
        [Required(ErrorMessage = "Extended Price is required.")]
        public decimal lregDExtPrice {
            get {
                return lregDHour * lregDUnitPrice;
            }
        }
        [Display(Name = "Summary")]
        public string LregDsummary {
            get {
                return lregDDesc + " - " + Project.projectName;
            }
        }

        [Required(ErrorMessage = "You need to specify project name.")]
        public int projectID { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<LabourRequirement> LabourRequirements { get; set; }

    }
}