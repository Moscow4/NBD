﻿// Made By: Chris Haggerty
// Date: 26/12/2017
// Work: Setting up Get and Set

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class Worker
    {
        public Worker() {
            this.ProjectTeams = new HashSet<ProjectTeam>();
        }
        public int ID { get; set; }

        [Display(Name = "Worker First Name")]
        [Required(ErrorMessage = "Enter Worker First Name")]
        [StringLength(30, ErrorMessage = "Worker Last Name cannot be more than 30 characters.")]
        public string FName { get; set; }

        [Display(Name = "Worker First Name")]
        [Required(ErrorMessage = "Enter Worker Last Name")]
        [StringLength(30, ErrorMessage = "Worker Last Name cannot be more than 30 characters.")]
        public string LName { get; set; }

        [Required(ErrorMessage = "You must specify the Worker Type for the Worker.")]
        public int worktypeID { get; set; }

        public virtual WorkType WorkType { get; set; }
        public virtual ICollection<ProjectTeam> ProjectTeams { get; set; }
    }
}