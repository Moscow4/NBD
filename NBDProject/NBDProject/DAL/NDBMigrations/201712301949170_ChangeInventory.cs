namespace NBDProject.DAL.NDBMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInventory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inventory", "materialID", "dbo.Material");
            DropIndex("dbo.Inventory", new[] { "materialID" });
            AddColumn("dbo.Inventory", "invCode", c => c.String(nullable: false));
            AddColumn("dbo.Inventory", "invDesc", c => c.String(nullable: false));
            DropColumn("dbo.Inventory", "materialID");
            DropColumn("dbo.MaterialRequirement", "mregCode");
            DropColumn("dbo.MaterialRequirement", "mregSize");
            DropColumn("dbo.MaterialRequirement", "mregNet");
            DropColumn("dbo.MaterialRequirement", "mregExtCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MaterialRequirement", "mregExtCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.MaterialRequirement", "mregNet", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.MaterialRequirement", "mregSize", c => c.String(nullable: false));
            AddColumn("dbo.MaterialRequirement", "mregCode", c => c.String(nullable: false));
            AddColumn("dbo.Inventory", "materialID", c => c.Int(nullable: false));
            DropColumn("dbo.Inventory", "invDesc");
            DropColumn("dbo.Inventory", "invCode");
            CreateIndex("dbo.Inventory", "materialID");
            AddForeignKey("dbo.Inventory", "materialID", "dbo.Material", "ID");
        }
    }
}
