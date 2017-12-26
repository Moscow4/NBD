using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class PlantInventory
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Plant Code is required.")]
        [StringLength(25, ErrorMessage = "Plant Code cannot be more than 25 characters.")]
        [Display(Name = "Plant Code")]
        public string PlantCode { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        [StringLength(50, ErrorMessage = "Description cannot be more than 50 characters.")]
        public string Desc { get; set; }

        [Required(ErrorMessage = "Size is required.")]
        public int Size { get; set; }

        [Display(Name = "Last Ordered")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        public DateTime? LastOrdered { get; set; }

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

        [Required(ErrorMessage = "QOQ is required.")]
        public int QOQ { get; set; }

        [Display(Name = "QO/OB")]
        [Required(ErrorMessage = "QO/OB is required.")]
        public int QO { get; set; }

        [Required(ErrorMessage = "You must specify the Inventory applying to the Plant Inventory.")]
        public int InventoryID { get; set; }

        //one to many
        public virtual Inventory Inventory { get; set; }
    }
}