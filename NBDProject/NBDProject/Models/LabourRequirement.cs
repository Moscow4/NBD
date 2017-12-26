// Made By: Chris Haggerty
// Date: 26/12/2017
// Work: Setting up Get and Set

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class LabourRequirement
    {
        public int ID { get; set; }

        public DateTime lreqEstDate { get; set; }

        public int lreqEstHours { get; set; }

        public DateTime lreqActtDate { get; set; }

        public int lreqActHours { get; set; }

        public string lreqComments { get; set; }

        public int prodTeamID { get; set; }

        public int taskID { get; set; }


        // setup one to many
        public virtual ProjectTeam ProjectTeam { get; set; }

        public virtual TaskTest TaskTest { get; set; }
    }
}