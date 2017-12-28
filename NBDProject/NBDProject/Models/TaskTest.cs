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
    public class TaskTest
    {
        public int ID { get; set; }

        [Display(Name = "Task Description")]
        [Required(ErrorMessage = "Enter Task Description")]
        [StringLength(50, ErrorMessage = "Task Description cannot be more than 50 characters.")]
        public string taskDesc { get; set; }

        [Display(Name = "Task Description")]
        public int? taskStdTImeAmnt { get; set; }

        [Display(Name = "Task Standard Time Unit")]
        [StringLength(20, ErrorMessage = "Task Standard Time Unit  cannot be more than 20 characters.")]
        public string taskStdTimeUnit { get; set; }

        [Required(ErrorMessage = "You must specify the Labor Requirements.")]
        public int labourRequirementID { get; set; }

        public virtual LabourRequirement LabourRequirement { get; set; }

    }
}