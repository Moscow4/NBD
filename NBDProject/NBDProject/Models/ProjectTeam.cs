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
    public class ProjectTeam
    {
        public ProjectTeam()
        {
            this.Workers = new HashSet<Worker>();
            this.Projects = new HashSet<Project>();
        }

        public int ID { get; set; }

        [Display(Name = "Team Phase In")]
        [Required(ErrorMessage = "Team Phase In is required.")]
        [StringLength(255, ErrorMessage = "Team Phase is cannot be more than 255 characters.")]
        public string teamPhaseIn { get; set; }

        public int projectID { get; set; }



        public virtual ICollection<Worker> Workers { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}