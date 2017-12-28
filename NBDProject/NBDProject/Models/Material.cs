using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class Material
    {
        [Required(ErrorMessage = "Material ID is needed!")]
        [Display(Name = "Material")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Material description cannot be left blank!")]
        [Display(Name = "Description")]
        public string matDesc { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "Material type cannot be empty.")]
        public string matType { get; set; }
    }
}