﻿// Made By: Chris Haggerty
// Date: 26/12/2017
// Work: Setting up Get and Set

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class Inventory
    {
        public int ID { get; set; }

        public decimal invAvgNet { get; set; }

        public int invList { get; set; }

        public int invSizeAmnt { get; set; }

        public string invSizeUnit { get; set; }

        public string invQOH { get; set; }

        public int materialID { get; set; }
    }
}