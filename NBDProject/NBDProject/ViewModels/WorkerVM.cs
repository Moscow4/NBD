using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBDProject.ViewModels
{
    public class WorkerVM
    {
        public int WorkerID { get; set; }
        public string WorkerFullName { get; set; }
        public bool Assigned { get; set; }
    }
}