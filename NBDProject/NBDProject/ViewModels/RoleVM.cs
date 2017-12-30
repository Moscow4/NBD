using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBDProject.ViewModels
{
    public class RoleVM
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public bool Assigned { get; set; }
    }
}