namespace NBDProject.DAL.NDBMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Project", "projectActStart", c => c.DateTime());
            AlterColumn("dbo.Project", "projectActEnd", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Project", "projectActEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Project", "projectActStart", c => c.DateTime(nullable: false));
        }
    }
}
