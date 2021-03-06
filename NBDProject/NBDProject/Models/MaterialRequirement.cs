﻿// Made By: Chris Haggerty
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
        public int ID { get; set; }


        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Quantity is required.")]
        public int mreqQty {get; set; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "Code is required.")]
        public string mregCode { get; set; }

        [Display(Name = "Size")]
        [Required(ErrorMessage = "Size is required.")]
        public string mregSize { get; set; }

        [Display(Name = "Net/Unit")]
        [Required(ErrorMessage = "Net/Unit is required.")]
        public decimal mregNet { get; set; }

        [Display(Name = "Ext. Cost")]
        [Required(ErrorMessage = "Ext. Cost is required.")]
        public decimal mregExtCost { get; set; }

        [Display(Name = "Deliver Day")]
        [Required(ErrorMessage = "Deliver Day is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd HH}", ApplyFormatInEditMode = false)]
        public DateTime mreqDeliver { get; set; }

        [Display(Name = "Install Day")]
        [Required(ErrorMessage = "Install Day is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd}", ApplyFormatInEditMode = false)]
        public DateTime mreqInstall { get; set; }

        [Required(ErrorMessage = "You must specify the Project.")]
        public int projectID { get; set; }

        public virtual Project Project { get; set; }



    }

  
}