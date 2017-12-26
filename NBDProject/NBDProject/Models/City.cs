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
    public class City
    {
        public City()
        {
            this.Clients = new HashSet<Client>();
        }
        public int ID { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "You cannot leave city blank.")]
        [StringLength(50, ErrorMessage = "City name can be no longer then 50 characters")]
        public string city { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

    }
}