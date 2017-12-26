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
    public class LabourSummary
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Labour Hour is required.")]
        [Display(Name = "Labour Hour")]
        public int lsHours { get; set; }

        [Required(ErrorMessage = "You must specify the project.")]
        public int projectID { get; set; }

        [Required(ErrorMessage = "You must specify the Worker Type.")]
        public int workerTypeID { get; set; }

        //set up one to manies 
        public virtual Project Project { get; set; }

        public virtual WorkType WorkType { get; set; }
    }
}