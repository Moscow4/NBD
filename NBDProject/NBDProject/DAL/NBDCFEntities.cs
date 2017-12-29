using NBDProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace NBDProject.DAL
{
    public class NBDCFEntities : DbContext
    {
        public DbSet<City>                  Cities { get; set; }
        public DbSet<Client>                Clients { get; set; }
        public DbSet<Inventory>             Inventory { get; set; }
        public DbSet<LabourRequirement>     LabourRequirements { get; set; }
        public DbSet<LabourSummary>         LabourSummaries { get; set; }
        public DbSet<Material>              Materials { get; set; }
        public DbSet<MaterialRequirement>   MaterialRequirements { get; set; }
        public DbSet<Worker>                Workers { get; set; }
        public DbSet<Project>               Projects { get; set; }
        public DbSet<ProjectTeam>           ProjectTeams { get; set; }
        public DbSet<ProjectTool>           ProjectTools { get; set; }
        public DbSet<Tool>                  Tools { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public override int SaveChanges()
        {
            // Not sure if we are doing user audits
            return base.SaveChanges();
        }

        public System.Data.Entity.DbSet<NBDProject.Models.TaskTest> TaskTests { get; set; }

        public System.Data.Entity.DbSet<NBDProject.Models.WorkType> WorkTypes { get; set; }
    }
}