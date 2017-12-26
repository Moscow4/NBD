// Made By: Chris Haggerty
// Date: 26/12/2017
// Work: Setting up Get and Set

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class Worker
    {
        public int ID { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public int worktypeID { get; set; }

        public virtual WorkType WorkType { get; set; }

    }
}