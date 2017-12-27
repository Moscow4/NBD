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
    public class Project
    {

        public int ID { get; set; }

        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "Enter Project Name")]
        [StringLength(100, ErrorMessage = "Project Name cannot be more than 100 characters.")]
        public string projectName { get; set; }

        [Display(Name = "Project Site")]
        [Required(ErrorMessage = "Enter Project Site")]
        [StringLength(100, ErrorMessage = "Project Site cannot be more than 100 characters.")]
        public string projectSite { get; set; }

        [Display(Name = "Delivery From Date")]
        [Required(ErrorMessage = "You must specify the Project Bid Date for the Project.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime projectBidDate { get; set; }

        [Display(Name = "Project Estimated Start")]
        [StringLength(10, ErrorMessage = "Project Estimated Start cannot be more than 10 characters.")]
        public string projectEstStart { get; set; }

        [Display(Name = "Project Estimated End")]
        [StringLength(10, ErrorMessage = "Project Estimated End cannot be more than 10 characters.")]
        public string projectEstEnd { get; set; }

        [Display(Name = "Project Actual Start")]
        [StringLength(10, ErrorMessage = "Project Actual Start cannot be more than 10 characters.")]
        public string projectActStart { get; set; }

        [Display(Name = "Project Actual End")]
        [StringLength(10, ErrorMessage = "Project Actual End cannot be more than 10 characters.")]
        public string projectActEnd { get; set; }

        [Display(Name = "Project Estimated Cost")]
        [StringLength(10, ErrorMessage = "Project Actual End cannot be more than 10 characters.")]
        public int? projectEstCost { get; set; }


        [Display(Name = "Project Actual Cost")]
        [StringLength(10, ErrorMessage = "Project Actual End cannot be more than 10 characters.")]
        public int? projectActCost { get; set; }

        [Display(Name = "Project Bid Customer Accept")]
        [StringLength(1, ErrorMessage = "Project Current Phase cannot be more than 1 characters.")]
        public bool? projectBidCustAccept { get; set; }

        [Display(Name = "Project Bid Managment Accept")]
        [StringLength(1, ErrorMessage = "Project Current Phase cannot be more than 1 characters.")]
        public bool? projectBidMgmtAccept { get; set; }

        [Display(Name = "Project Current Phase")]
        [StringLength(1, ErrorMessage = "Project Current Phase cannot be more than 1 characters.")]
        public string projectCurrentPhase { get; set; }

        public bool? projectFlagged { get; set; }

        [Required(ErrorMessage = "Set A Client")]
        public int clientID { get; set; }

        // a disigner ID doesnt exist need to discuss with team 
        //[Required(ErrorMessage = "Set A Designer")]
        //public int designerID { get; set; }

        public virtual Client Client { get; set; }




    }
}