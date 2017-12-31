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
    public class MaterialRequirement
    {
        public int ID { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Quantity is required.")]
        public int mreqQty {get; set; }

        //[Display(Name = "Code")]
        //[Required(ErrorMessage = "Code is required.")]
        //public string mregCode { get; set; }


        [Display(Name = "Size")]
        [Required(ErrorMessage = "Size is required.")]
        public string mregSize {
            get {
                return Inventory.SizeAmnt.ToString() + " " + Inventory.SizeUnit.ToString();
            }
        }

        [Display(Name = "Net/Unit")]
        [Required(ErrorMessage = "Net/Unit is required.")]
        public decimal mregNetProPlan {
            get {
                return Inventory.AvgNet;
            }
        }
         

        [Display(Name = "Net/Unit")]
        [Required(ErrorMessage = "Net/Unit is required.")]
        public decimal mregNetDesign {
            get {
                return Inventory.List;
            }
        }

        [Display(Name = "Ext. Cost(Design)")]
        [Required(ErrorMessage = "Ext. Cost is required.")]
        public decimal mregExtCostDesign
        {
            get
            {
                return mreqQty * mregNetDesign;
            }

        }

        [Display(Name = "Ext. Cost(Production Plan)")]
        [Required(ErrorMessage = "Ext. Cost is required.")]
        public decimal mregExtCostProPlan
        {
            get
            {
                return mreqQty * mregNetProPlan;
            }

        }

        [Display(Name = "Deliver Day")]
        [Required(ErrorMessage = "Deliver Day is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd HH}", ApplyFormatInEditMode = false)]
        public DateTime mreqDeliver { get; set; }

        [Display(Name = "Install Day")]
        [Required(ErrorMessage = "Install Day is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd}", ApplyFormatInEditMode = false)]
        public DateTime mreqInstall { get; set; }

        [Required(ErrorMessage = "You must specify the Project.")]
        public int projectID { get; set; }

        [Required(ErrorMessage = "You must specify the Inventory.")]
        public int inventoryID { get; set; }


        public virtual Inventory Inventory { get; set; }

        public virtual Project Project { get; set; }



    }

  
}