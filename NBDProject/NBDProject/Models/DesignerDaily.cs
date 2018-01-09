using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class DesignerDaily
    {
        private DateTime submitDate = DateTime.Today;

        public int ID { get; set; }
        [Display(Name = "Project")]
        public string projectName {
            get {
                return project.projectName;
            }
        }

        [Display(Name = "Stage")]
        public string stage { get; set; }

        [Display(Name = "Hours")]
        public int hour { get; set; }

        public DateTime SubmitDate {
            get {
                return submitDate;
            }
            set {
                submitDate = DateTime.Today;
            }
        }

        public int taskID { get; set; }
        public int projectID { get; set; }

        public virtual TaskTest Task { get; set; }
        public virtual Project project { get; set; }
    }
}