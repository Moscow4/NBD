using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class ProductionDailyLabor
    {
        private DateTime submitDate = DateTime.Today;
        
        public DateTime SubmitDate {
            get {
                return submitDate;
            }
            set {
                submitDate = DateTime.Today;
            }
        }

        

        public int ID { get; set; }
        [Required(ErrorMessage = "Hours is required.")]
        public int Hours { get; set; }

        [Display (Name = "Cost/Hr")]
        [Required(ErrorMessage = "Cost/Hr is required.")]
        public decimal HourCost { get; set; }

        [Display(Name = "Ext. Cost")]
        public decimal Cost {
            get {
                return HourCost * Hours;
            }
        }

        [Display(Name = "Task")]
        [Required(ErrorMessage ="You have to specify Task.")]
        public int taskID { get; set; }

        [Display(Name = "Worker")]
        [Required(ErrorMessage ="You have to specify worker.")]
        public int labourID { get; set; }

        [Display(Name = "Project")]
        [Required(ErrorMessage ="You have to specify Project.")]
        public int projectID { get; set; }

        public virtual Project Project { get; set; }
        public virtual LabourRequirement LabourRequirement { get; set; }
        public virtual TaskTest Task { get; set; }
    }
}