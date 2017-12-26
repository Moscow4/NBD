// Made By: Chris Haggerty
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
        public Inventory()
        {
            this.PlantInventories = new HashSet<PlantInventory>();
            this.PotteryInventories = new HashSet<PotteryInventory>();
            this.MaterialsInventories = new HashSet<MaterialsInventory>();

        }
        public int ID { get; set; }

        public string InvDescription { get; set; }

        
        //one to many
        public virtual ICollection<PlantInventory> PlantInventories { get; set; }
        public virtual ICollection<PotteryInventory> PotteryInventories { get; set; }
        public virtual ICollection<MaterialsInventory> MaterialsInventories { get; set; }
    }
}