// Made By: Chris Haggerty
// Date: 26/12/2017
// Work: Setting up Get and Set

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class WorkType
    {
        public int ID { get; set; }
        public string workTypeDesc { get; set; }
        public int workTypePrice { get; set; }
        public int workTypeCost { get; set; }
    }
}