// Made By: Chris Haggerty
// Date: 26/12/2017
// Work: Setting up Get and Set


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class ProjectTeam
    {

        public int ID { get; set; }

        public string teamPhaseIn { get; set; }

        public int projectID { get; set; }

        public int workerID { get; set; }


    }
}