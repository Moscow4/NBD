using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class ProductionDailyMaterial
    {
        private DateTime submitDate = DateTime.Today;

        

        public int ID { get; set; }
        [Display(Name = "Quantity")]
        [Required (ErrorMessage = "Quantity is required.")]
        public int Qnty { get; set; }

        [Display(Name = "Unit Cost")]
        [Required(ErrorMessage = "Unit Cost is required.")]
        public decimal UnitCost { get; set; }

        public DateTime SubmitDate {
            get {
                return submitDate;
            }
            set {
                submitDate = DateTime.Today;
            }
        }

        [Display(Name = "Ext. Cost")]
        [Required(ErrorMessage ="Ext. Cost is requied.")]
        public decimal Cost {
            get {
                return UnitCost * Qnty;
            }
        }

        [Display(Name = "Material")]
        [Required(ErrorMessage = "You have to specify Material")]
        public int materialID { get; set; }

        [Display(Name = "Project")]
        [Required (ErrorMessage = "You have to specify Project")]
        public int projectID { get; set; }

        public virtual MaterialRequirement MaterialRequirement { get; set; }
        public virtual Project Project { get; set; }
        
    }
}