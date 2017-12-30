using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class Inventory
    {
        public Inventory() {
            this.MaterialRequirements = new HashSet<MaterialRequirement>();
        }


        [Required(ErrorMessage = "How do you not have an ID for this?")]
        public int ID { get; set; }

        [Display(Name = "Inventory Code")]
        [Required(ErrorMessage = "Inventory Code is required.")]
        public string invCode { get; set; }

        [Display(Name = "Inventory Description")]
        [Required(ErrorMessage = "Inventory Description is required.")]
        public string invDesc { get; set; }

        [Required(ErrorMessage = "Unsure about this value, but it is needed!")]
        public decimal AvgNet { get; set; }

        [Required(ErrorMessage = "Inventory list cannot be left blank.")]
        public decimal List { get; set; }

        [Required(ErrorMessage = "Size amount cannot be left blank.")]
        public int SizeAmnt { get; set; }

        [Required(ErrorMessage = "Size of unit cannot be left blank.")]
        public string SizeUnit { get; set; }

        public virtual ICollection<MaterialRequirement> MaterialRequirements { get; set; } 
       
    }
}