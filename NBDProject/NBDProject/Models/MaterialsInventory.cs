using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class MaterialsInventory
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Material Code is required.")]
        [StringLength(25, ErrorMessage = "Material Code cannot be more than 25 characters.")]
        [Display(Name = "Material Code")]
        public string MaterialCode { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        [StringLength(50, ErrorMessage = "Description cannot be more than 50 characters.")]
        public string Desc { get; set; }

        [Required(ErrorMessage = "Unit is required.")]
        [StringLength(25, ErrorMessage = "Unit cannot be more than 50 characters.")]
        public string Unit { get; set; }

        [Display(Name = "AveNet$")]
        [Required(ErrorMessage = "AveNet is required.")]
        public decimal AveNet { get; set; }

        [Display(Name = "List$")]
        [Required(ErrorMessage = "List is required.")]
        public decimal List { get; set; }

        [Required(ErrorMessage = "QIS is required.")]
        public int QIS { get; set; }

        [Required(ErrorMessage = "You must specify the Inventory applying to the Plant Inventory.")]
        public int InventoryID { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}