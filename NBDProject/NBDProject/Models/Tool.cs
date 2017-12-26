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
    public class Tool
    {

        public int ID { get; set; }

        [Display(Name = "Tool Description")]
        [Required(ErrorMessage = "Enter Tool Description")]
        [StringLength(50, ErrorMessage = "Tool Description cannot be more than 50 characters.")]
        public string toolDesc { get; set; }
        
    }
}