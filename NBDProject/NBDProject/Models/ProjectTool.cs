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
    public class ProjectTool
    {
        public int ID { get; set; }


        [Display(Name = "Project Tool Quantity")]
        [Required(ErrorMessage = "Proeject Tool Quantity cannot be left blank, is required.")]
        [Range(0, 255, ErrorMessage = "Error inputing Project Tool Quantity")]
        public int ptQty { get; set; }

        [Display(Name = "Delivery From Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ptDeliverFrom { get; set; }

        [Display(Name = "Delivery to Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ptDeliveryTo { get; set; }

        [Required(ErrorMessage = "You must specify the Project for the Project Tool.")]
        public int projectID { get; set; }


        public virtual Project Project { get; set; }



    }
}