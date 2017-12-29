namespace NBDProject.DAL.NDBMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondInitial : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProjectTeamWorker", newName: "WorkerProjectTeam");
            DropPrimaryKey("dbo.WorkerProjectTeam");
            AddColumn("dbo.Client", "cliFName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Client", "cliLName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.ProjectTeam", "Project_ID", c => c.Int());
            AddPrimaryKey("dbo.WorkerProjectTeam", new[] { "Worker_ID", "ProjectTeam_ID" });
            CreateIndex("dbo.ProjectTeam", "projectID");
            CreateIndex("dbo.ProjectTeam", "Project_ID");
            AddForeignKey("dbo.ProjectTeam", "projectID", "dbo.Project", "ID");
            AddForeignKey("dbo.ProjectTeam", "Project_ID", "dbo.Project", "ID");
            DropColumn("dbo.Client", "cliName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Client", "cliName", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.ProjectTeam", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.ProjectTeam", "projectID", "dbo.Project");
            DropIndex("dbo.ProjectTeam", new[] { "Project_ID" });
            DropIndex("dbo.ProjectTeam", new[] { "projectID" });
            DropPrimaryKey("dbo.WorkerProjectTeam");
            DropColumn("dbo.ProjectTeam", "Project_ID");
            DropColumn("dbo.Client", "cliLName");
            DropColumn("dbo.Client", "cliFName");
            AddPrimaryKey("dbo.WorkerProjectTeam", new[] { "ProjectTeam_ID", "Worker_ID" });
            RenameTable(name: "dbo.WorkerProjectTeam", newName: "ProjectTeamWorker");
        }
    }
}
