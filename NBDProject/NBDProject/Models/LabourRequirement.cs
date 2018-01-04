// Made By: Chris Haggerty
// Date: 26/12/2017
// Work: Setting up Get and Set

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class LabourRequirement
    {


     
        public int ID { get; set; }

        //[Display(Name = "Desc")]
        //[Required(ErrorMessage = "Description is required.")]
        //[StringLength(50, ErrorMessage = "Description cannot be more than 50 characters.")]
        //public string desc { get; set; }

        //[Display(Name = "Estimate Hour")]
        //[Required(ErrorMessage = "Estimate Hour is required.")]
        //public int lregEstHour { get; set; }

        [Display(Name = "Hour")]
        [Required(ErrorMessage = "Hour is required.")]
        public int lregProdHour { get; set; }

        [Display(Name = "Cost/Hr")]
        [Required(ErrorMessage = "Cost each Hour is required.")]
        public decimal lregCost { get; set; }

        [Display(Name = "Ext. Cost")]
        [Required(ErrorMessage = "Ext. Cost is required.")]
        public decimal LregEstCost
        {
            get { return lregCost * lregProdHour; }
        }

        //[Display(Name = "Unit Price")]
        //[Required(ErrorMessage = "Unit Price is required.")]
        //public decimal lregUnitPrice { get; set; }

        //[Display(Name = "Extended Price")]
        //public decimal lregExtPrice {
        //    get {
        //        return lregEstHour * lregUnitPrice;
        //    }
        //}



        [Display(Name = "Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd HH}", ApplyFormatInEditMode = false)]
        public DateTime lregTime { get; set; }

        [Required(ErrorMessage = "You have to specify Task.")]
        public int TaskID { get; set; }

        [Required(ErrorMessage = "You have to specify Woker.")]
        public int WorkerID { get; set; }

        [Required(ErrorMessage = "Project Name is Required.")]
        [Display(Name = "Project Name")]
        public string projectName {
            get {
                return LabourRequirementDesign.Project.projectName.ToString();
            }
        }

        [Required(ErrorMessage = "Your have to specify Design Description.")]
        public int LabourRequirementDesignID { get; set; }
        


        // setup one to many
        public virtual TaskTest Task { get; set; }
        public virtual Worker Worker { get; set; }
        public virtual LabourRequirementDesign LabourRequirementDesign { get; set; }

    }
}