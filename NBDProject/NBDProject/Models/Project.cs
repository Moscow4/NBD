// Made By: Chris Haggerty
// Date: 26/12/2017
// Work: Setting up Get and Set

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class Project
    {

        public int ID { get; set; }

        public string projectName { get; set; }

        public string projectSite { get; set; }

        public DateTime projectBidDate { get; set; }

        public string projectEstStart { get; set; }

        public string projectEstEmd { get; set; }

        public string projectActStart { get; set; }

        public string projectActEnd { get; set; }

        public int projectEstCost { get; set; }

        public int projectActCost { get; set; }

        public byte projectBidCustAccept { get; set; }

        public byte projectBidMgmtAccept { get; set; }

        public string projectCurrentPhase { get; set; }

        public byte projectFlagged { get; set; }

        public int clientID { get; set; }

        // a disigner ID doesnt exist need to discuss with team 

        //public int designerID { get; set; }

        public virtual Client Client { get; set; }




    }
}