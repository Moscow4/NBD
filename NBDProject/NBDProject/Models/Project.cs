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
        [DataType(DataType.Date)]
        public DateTime projectEstStart { get; set; }

        [Display(Name = "Project Estimated End")]
        [DataType(DataType.Date)]
        public DateTime projectEstEnd { get; set; }

        [Display(Name = "Project Actual Start")]
        [DataType(DataType.Date)]
        public DateTime projectActStart { get; set; }

        [Display(Name = "Project Actual End")]
        [DataType(DataType.Date)]
        public DateTime projectActEnd { get; set; }

        [Display(Name = "Project Estimated Cost")]
        public decimal? projectEstCost { get; set; }

        [Display(Name = "Project Actual Cost")]
        public decimal? projectActCost { get; set; }

        [Display(Name = "Project Bid Customer Accept")]
        public bool? projectBidCustAccept { get; set; }

        [Display(Name = "Project Bid Managment Accept")]
        public bool? projectBidMgmtAccept { get; set; }

        [Display(Name = "Project Current Phase")]
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