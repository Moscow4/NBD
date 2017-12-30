namespace NBDProject.DAL.NDBMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthInitial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Project", "projectBidCustAccept", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Project", "projectBidMgmtAccept", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Project", "projectBidMgmtAccept", c => c.Boolean());
            AlterColumn("dbo.Project", "projectBidCustAccept", c => c.Boolean());
        }
    }
}
