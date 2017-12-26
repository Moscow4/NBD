// Made By: Chris Haggerty
// Date: 26/12/2017
// Work: Setting up Get and Set

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class WorkType
    {
        public int ID { get; set; }

        [Display(Name = "Worker Type Description")]
        [Required(ErrorMessage = "Enter Worker Type Description")]
        [StringLength(50, ErrorMessage = "Worker Type Description cannot be more than 50 characters.")]
        public string workTypeDesc { get; set; }

        [Display(Name = "Worker Type Price")]
        [Required(ErrorMessage = "Enter Worker Type Price")]
        [Range(0.01, 9999.99, ErrorMessage = "Invalid Price.")]
        [DataType(DataType.Currency)]
        public decimal workTypePrice { get; set; }


        [Display(Name = "Worker Type Cost")]
        [Required(ErrorMessage = "Enter Worker Type Cost")]
        [Range(0.01, 9999.99, ErrorMessage = "Invalid Cost.")]
        [DataType(DataType.Currency)]
        public decimal workTypeCost { get; set; }
    }
}