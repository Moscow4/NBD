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

        public string projectName;

        public string projectSite;

        public DateTime projectBidDate;

        public string projectEstStart;

        public string projectEstEmd;

        public string projectActStart;

        public string projectActEnd;

        public int projectEstCost;

        public int projectActCost;

        public byte projectBidCustAccept;

        public byte projectBidMgmtAccept;

        public string projectCurrentPhase;

        public byte projectFlagged;

        public int clientID { get; set; }

        public int designerID { get; set; }





    }
}