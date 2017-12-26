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
        [Display(Name = "Est. Cost")]
        public decimal lregEstCost {
            get { return lregEstHour * lregEstCost; }
        }

        public int ID { get; set; }

        [Display(Name = "Desc")]
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(50, ErrorMessage = "Description cannot be more than 50 characters.")]
        public string desc { get; set; }

        [Display(Name = "Estimate Hour")]
        [Required(ErrorMessage = "Estimate Hour is required.")]
        public int lregEstHour { get; set; }

        [Display(Name = "Cost/Hr")]
        [Required(ErrorMessage = "Cost each Hour is required.")]
        public decimal lregCost { get; set; }

        [Display(Name = "Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH}", ApplyFormatInEditMode = false)]
        public DateTime lregTime { get; set; }

        [Required(ErrorMessage = "You must specify the Project Team.")]
        public int prodTeamID { get; set; }

        [Required(ErrorMessage = "You must specify the Task.")]
        public int taskID { get; set; }


        // setup one to many
        public virtual ProjectTeam ProjectTeam { get; set; }

        public virtual TaskTest TaskTest { get; set; }
    }
}