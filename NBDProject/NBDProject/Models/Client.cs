// Made By: Chris Haggerty
// Date: 26/12/2017
// Work: Setting up Get and Set

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBDProject.Models
{
    public class Client
    {
        public int ID { get; set; }

        public string cliName { get; set; }

        public string cliAddress { get; set; }

        public string cliProvince { get; set; }

        public string cliCode { get; set; }

        public Int64 cliPhone { get; set; }

        public string cliConFname { get; set; }

        public string cliConLName { get; set; }

        public string cliConPostion { get; set;}

        public string cityID { get; set; }
    }
}

