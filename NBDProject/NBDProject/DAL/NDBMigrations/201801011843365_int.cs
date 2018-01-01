namespace NBDProject.DAL.NDBMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _int : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TaskTest", "taskStdTImeAmnt");
            DropColumn("dbo.TaskTest", "taskStdTimeUnit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaskTest", "taskStdTimeUnit", c => c.String(maxLength: 20));
            AddColumn("dbo.TaskTest", "taskStdTImeAmnt", c => c.Int());
        }
    }
}
