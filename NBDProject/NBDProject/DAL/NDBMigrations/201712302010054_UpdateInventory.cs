namespace NBDProject.DAL.NDBMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInventory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaterialRequirement", "mregCode", c => c.String(nullable: false));
            AddColumn("dbo.MaterialRequirement", "mregSize", c => c.String(nullable: false));
            AddColumn("dbo.MaterialRequirement", "mregNetProPlan", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.MaterialRequirement", "mregNetDesign", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.MaterialRequirement", "mregExtCostDesign", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.MaterialRequirement", "mregExtCostProPlan", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MaterialRequirement", "mregExtCostProPlan");
            DropColumn("dbo.MaterialRequirement", "mregExtCostDesign");
            DropColumn("dbo.MaterialRequirement", "mregNetDesign");
            DropColumn("dbo.MaterialRequirement", "mregNetProPlan");
            DropColumn("dbo.MaterialRequirement", "mregSize");
            DropColumn("dbo.MaterialRequirement", "mregCode");
        }
    }
}
