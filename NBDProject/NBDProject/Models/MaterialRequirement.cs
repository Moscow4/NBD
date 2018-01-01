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
        public MaterialRequirement() {
            this.mreqDeliver = null;
            this.mreqInstall = null;
        }
        public int ID { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Quantity is required.")]
        public int mreqQty {get; set; }

        //[Display(Name = "Code")]
        //[Required(ErrorMessage = "Code is required.")]
        //public string mregCode { get; set; }


        [Display(Name = "Size")]
        public string mregSize {
            get {
                return Inventory.SizeAmnt.ToString() + " " + Inventory.SizeUnit.ToString();
            }
        }

        [Display(Name = "Net/Unit")]
        public decimal? mregNetProPlan {
            get {
                return Inventory.AvgNet;
            }
        }
         

        [Display(Name = "Net/Unit")]
        public decimal? mregNetDesign {
            get {
                return Inventory.List;
            }
        }

        [Display(Name = "Ext. Cost(Design)")]
        public decimal? mregExtCostDesign
        {
            get
            {
                return mreqQty * mregNetDesign;
            }

        }

        [Display(Name = "Ext. Cost(Production Plan)")]
        public decimal? mregExtCostProPlan
        {
            get
            {
                return mreqQty * mregNetProPlan;
            }

        }



        [Display(Name = "Deliver Day")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd HH}", ApplyFormatInEditMode = false)]
        public DateTime? mreqDeliver { get; set; }

        [Display(Name = "Install Day")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd}", ApplyFormatInEditMode = false)]
        public DateTime? mreqInstall { get; set; }

        [Required(ErrorMessage = "You must specify the Project.")]
        public int projectID { get; set; }

        [Required(ErrorMessage = "You must specify the Inventory.")]
        public int inventoryID { get; set; }


        public virtual Inventory Inventory { get; set; }

        public virtual Project Project { get; set; }





    }

  
}