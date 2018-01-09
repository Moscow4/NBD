using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NBDProject.Models;

namespace NBDProject.ViewModels
{
    public class ProductionDailyVM
    {
        public IList<ProductionDailyLabor> ProductionDailyLabor { get; set; }
        public IList<ProductionDailyMaterial> ProductionDailyMaterial { get; set; }
        public IList<Project> Project { get; set; }
    }
}