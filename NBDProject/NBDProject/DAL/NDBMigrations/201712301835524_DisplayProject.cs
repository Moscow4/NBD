namespace NBDProject.DAL.NDBMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisplayProject : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inventory", "List", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Project", "projectFlagged");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Project", "projectFlagged", c => c.Boolean());
            AlterColumn("dbo.Inventory", "List", c => c.Int(nullable: false));
        }
    }
}
