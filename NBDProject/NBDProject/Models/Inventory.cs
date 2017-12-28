using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class Inventory
    {
        [Required(ErrorMessage = "How do you not have an ID for this?")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Unsure about this value, but it is needed!")]
        public decimal AvgNet { get; set; }

        [Required(ErrorMessage = "Inventory list cannot be left blank.")]
        public int List { get; set; }

        [Required(ErrorMessage = "Size amount cannot be left blank.")]
        public int SizeAmnt { get; set; }

        [Required(ErrorMessage = "Size of unit cannot be left blank.")]
        public string SizeUnit { get; set; }

        // Potentially unnecessary
        //[Required(ErrorMessage = "Quantity on hand cannot be left blank.")]
        //public string QuantityOnHand { get; set; }

        [Required(ErrorMessage = "Material ID is needed.")]
        public int materialID { get; set; }


        //one to many
        public virtual Material Material { get; set; }
    }
}