namespace NBDProject.DAL.NDBMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdInitial : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.WorkerProjectTeam", newName: "ProjectTeamWorker");
            DropPrimaryKey("dbo.ProjectTeamWorker");
            AddPrimaryKey("dbo.ProjectTeamWorker", new[] { "ProjectTeam_ID", "Worker_ID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProjectTeamWorker");
            AddPrimaryKey("dbo.ProjectTeamWorker", new[] { "Worker_ID", "ProjectTeam_ID" });
            RenameTable(name: "dbo.ProjectTeamWorker", newName: "WorkerProjectTeam");
        }
    }
}
