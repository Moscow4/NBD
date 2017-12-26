// Made By: Chris Haggerty
// Date: 26/12/2017
// Work: Setting up Get and Set

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class ProjectTool
    {
        public int ID { get; set; }

        public int projectID { get; set; }

        public int toolID { get; set; }

        public int ptQty { get; set; }

        public DateTime ptDeliverFrom { get; set; }

        public DateTime ptDeliveryTo { get; set; }






    }
}