namespace NBDProject.DAL.NDBMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixProblemWithMaterialRequirement : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MaterialRequirement", "mregExtCostDesign");
            DropColumn("dbo.MaterialRequirement", "mregExtCostProPlan");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MaterialRequirement", "mregExtCostProPlan", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.MaterialRequirement", "mregExtCostDesign", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
