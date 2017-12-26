// Made By: Chris Haggerty
// Date: 26/12/2017
// Work: Setting up Get and Set

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class MaterialRequirement
    {
        public int ID { get; set; }

        public DateTime mreqDeliver { get; set; }

        public DateTime mreqInstall { get; set; }

        public int mreqEstQty {get; set; }

        public int meqActQty { get; set; }

        public int inventoryID { get; set; }

        public int projectID { get; set; }



    }
}