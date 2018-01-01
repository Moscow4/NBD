using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class BusinessRule
    {
        [Display(Name = "Design Bid")]
        public decimal designBid { get; set; }
        //public decimal labourCostDesginBid {
        //    get {
        //        return LabourRequirementDesign.lregDExtPrice;
        //    }
        //}
        //public decimal MaterialCostDesginBid {
        //    get {
        //        return MaterialRequirement.mregExtCostDesign;
        //    }
        //}

        //public decimal labourCost {
        //    get {
        //        return LabourRequirement.LregEstCost;
        //    }
        //}
        //public decimal MaterialCost {
        //    get {
        //        return MaterialRequirement.mregExtCostProPlan;
        //    }
        //}

        [Display(Name = "Production Plan Total Cost")]
        public decimal productionPlanTotalCost { get; set; }


        //[Display(Name = "Production Plan Total Percent")]
        //public decimal productionPlanTotalPercent {
        //    get {

        //    }
        //}

        //[Display(Name = "Desgin cost percent")]
        //public decimal designPercent { get; set; }

        public int ProjectID { get; set; }


        public LabourRequirement LabourRequirement { get; set; }
        public LabourRequirementDesign LabourRequirementDesign { get; set; }
        public MaterialRequirement MaterialRequirement { get; set; }
        public virtual Project Project { get; set; }
    }
}