using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class BusinessRule
    {

        public int ID { get; set; }

        [Display(Name = "Design Bid")]
        public decimal designBid { get; set; }
        public decimal labourCostDesignBid {
            get {
                return LabourRequirementDesign.lregDExtPrice;
            }
        }
        public decimal MaterialCostDesignBid {
            get {
                return MaterialRequirement.mregExtCostDesign;
            }
        }

        public decimal LabourCost {
            get {
                return LabourRequirement.LregEstCost;
            }
        }
        public decimal MaterialCost {
            get {
                return MaterialRequirement.mregExtCostProPlan;
            }
        }

        [Display(Name = "Production Plan Total Cost")]
        public decimal productionPlanTotalCost { get; set; }


        [Display(Name = "Production Plan Total Percent")]
        public decimal productionPlanTotalPercent {
            get {
                return 0.0m;
            }
        }

        [Display(Name = "Design cost percent")]
        public decimal designPercent { get; set; }

        public int ProjectID { get; set; }


        public LabourRequirement LabourRequirement { get; set; }
        public LabourRequirementDesign LabourRequirementDesign { get; set; }
        public MaterialRequirement MaterialRequirement { get; set; }
        public virtual Project Project { get; set; }
    }
}