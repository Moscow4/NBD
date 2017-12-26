using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class PotteryInventory
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Pottery Code is required.")]
        [StringLength(25, ErrorMessage = "Pottery Code cannot be more than 25 characters.")]
        [Display(Name = "Pottery Code")]
        public string PotteryCode { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        [StringLength(50, ErrorMessage = "Description cannot be more than 50 characters.")]
        public string Desc { get; set; }

        [Required(ErrorMessage = "Size is required.")]
        public int Size { get; set; }

        [Required(ErrorMessage = "Feature is required.")]
        [StringLength(50, ErrorMessage = "Feature cannot be more than 50 characters.")]
        public string Feature { get; set; }

        [Display(Name = "AveNet$")]
        [Required(ErrorMessage = "AveNet is required.")]
        public decimal AveNet { get; set; }

        [Display(Name = "List$")]
        [Required(ErrorMessage = "List is required.")]
        public decimal List { get; set; }

        [Required(ErrorMessage = "QIS is required.")]
        public int QIS { get; set; }

        [Display(Name = "IS/OB")]
        [Required(ErrorMessage = "IS/OB is required.")]
        public int IS { get; set; }

        [Required(ErrorMessage = "You must specify the Inventory applying to the Pottery Inventory.")]
        public int InventoryID { get; set; }

        //one to many
        public virtual Inventory Inventory { get; set; }
    }
}