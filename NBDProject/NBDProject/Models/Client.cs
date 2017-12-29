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
    public class Client
    {
        [Display(Name = "Client Full Name")]
        public string cliFullName
        {
            get {
                return cliFName + " " + cliLName;
            }
        }
      
        
        public int ID { get; set; }

        [Display(Name = "Client First Name")]
        [Required(ErrorMessage = "Enter Client First Name")]
        [StringLength(255, ErrorMessage = "Client First Name cannot be more than 255 characters.")]
        public string cliFName { get; set; }

        [Display(Name = "Client Last Name")]
        [Required(ErrorMessage = "Enter Client Last Name")]
        [StringLength(255, ErrorMessage = "Client Last Name cannot be more than 255 characters.")]
        public string cliLName { get; set; }

        [Display(Name = "Client Address")]
        [Required(ErrorMessage = "Client Address is required.")]
        public string cliAddress { get; set; }

        [Display(Name = "Client Province")]
        [Required(ErrorMessage = "Client Province is required.")]
        [StringLength(50, ErrorMessage = "Province cannot more than 50 Characters.")]
        public string cliProvince { get; set; }

        [Display(Name = "Client Postal Code")]
        [RegularExpression("^[A-Za-z]\\d[A-Za-z][ -]?\\d[A-Za-z]\\d$", ErrorMessage = "Postal code must be an valid Postal Code.")]
        [Required(ErrorMessage = "Client Postal Code is required.")]
        public string cliCode { get; set; }

        [Display(Name = "Client Phone Number")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number.")]
        [Required(ErrorMessage = "Clinet Phone Number is required.")]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = false)]
        public Int64 cliPhone { get; set; }

        [Display(Name = "Contact First Name")]
        [Required(ErrorMessage = "Contact First Name is required.")]
        [StringLength(50, ErrorMessage = "Contact First Name cannot be more than 50 characters.")]
        public string cliConFname { get; set; }

        [Display(Name = "Contact Last Name")]
        [Required(ErrorMessage = "Contact Last Name is required.")]
        [StringLength(50, ErrorMessage = "Contact Last Name cannot be more than 50 characters.")]
        public string cliConLName { get; set; }

        [Display(Name = "Contact Position")]
        [Required(ErrorMessage = "Contact Position is required.")]
        [StringLength(255, ErrorMessage = "Contact position cannot be more than 255 characters")]
        public string cliConPostion { get; set;}

        public int cityID { get; set; }


        //one to many 
        public virtual City City { get; set; }

    }
}

