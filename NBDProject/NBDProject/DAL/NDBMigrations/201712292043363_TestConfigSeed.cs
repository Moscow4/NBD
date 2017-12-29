namespace NBDProject.DAL.NDBMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestConfigSeed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaterialRequirement", "inventoryID", c => c.Int(nullable: false));
            AddColumn("dbo.ProjectTool", "toolID", c => c.Int(nullable: false));
            CreateIndex("dbo.MaterialRequirement", "inventoryID");
            CreateIndex("dbo.ProjectTool", "toolID");
            AddForeignKey("dbo.MaterialRequirement", "inventoryID", "dbo.Inventory", "ID");
            AddForeignKey("dbo.ProjectTool", "toolID", "dbo.Tool", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectTool", "toolID", "dbo.Tool");
            DropForeignKey("dbo.MaterialRequirement", "inventoryID", "dbo.Inventory");
            DropIndex("dbo.ProjectTool", new[] { "toolID" });
            DropIndex("dbo.MaterialRequirement", new[] { "inventoryID" });
            DropColumn("dbo.ProjectTool", "toolID");
            DropColumn("dbo.MaterialRequirement", "inventoryID");
        }
    }
}
