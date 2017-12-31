namespace NBDProject.DAL.NDBMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        city = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        cliName = c.String(nullable: false, maxLength: 255),
                        cliAddress = c.String(nullable: false),
                        cliProvince = c.String(nullable: false, maxLength: 50),
                        cliCode = c.String(nullable: false),
                        cliPhone = c.Long(nullable: false),
                        cliConFname = c.String(nullable: false, maxLength: 50),
                        cliConLName = c.String(nullable: false, maxLength: 50),
                        cliConPostion = c.String(nullable: false, maxLength: 255),
                        cityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.City", t => t.cityID, cascadeDelete: true)
                .Index(t => t.cityID);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        projectName = c.String(nullable: false, maxLength: 100),
                        projectSite = c.String(nullable: false, maxLength: 100),
                        projectBidDate = c.DateTime(nullable: false),
                        projectEstStart = c.DateTime(nullable: false),
                        projectEstEnd = c.DateTime(nullable: false),
                        projectActStart = c.DateTime(),
                        projectActEnd = c.DateTime(),
                        projectEstCost = c.Decimal(precision: 18, scale: 2),
                        projectActCost = c.Decimal(precision: 18, scale: 2),
                        projectBidCustAccept = c.Boolean(nullable: false),
                        projectBidMgmtAccept = c.Boolean(nullable: false),
                        projectCurrentPhase = c.String(),
                        clientID = c.Int(nullable: false),
                        ProjectTeam_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Client", t => t.clientID, cascadeDelete: true)
                .ForeignKey("dbo.ProjectTeam", t => t.ProjectTeam_ID, cascadeDelete: true)
                .Index(t => t.clientID)
                .Index(t => t.ProjectTeam_ID);
            
            CreateTable(
                "dbo.LabourRequirementDesign",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        lregDHour = c.Int(nullable: false),
                        lregDDesc = c.String(nullable: false),
                        lregDUnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        projectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Project", t => t.projectID, cascadeDelete: true)
                .Index(t => t.projectID);
            
            CreateTable(
                "dbo.LabourRequirement",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        lregProdHour = c.Int(nullable: false),
                        lregCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        lregTime = c.DateTime(nullable: false),
                        TaskID = c.Int(nullable: false),
                        WorkerID = c.Int(nullable: false),
                        LabourRequirementDesignID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LabourRequirementDesign", t => t.LabourRequirementDesignID, cascadeDelete: true)
                .ForeignKey("dbo.TaskTest", t => t.TaskID, cascadeDelete: true)
                .ForeignKey("dbo.Worker", t => t.WorkerID, cascadeDelete: true)
                .Index(t => t.TaskID)
                .Index(t => t.WorkerID)
                .Index(t => t.LabourRequirementDesignID);
            
            CreateTable(
                "dbo.TaskTest",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        taskDesc = c.String(nullable: false, maxLength: 50),
                        taskStdTImeAmnt = c.Int(),
                        taskStdTimeUnit = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Worker",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false, maxLength: 30),
                        LName = c.String(nullable: false, maxLength: 30),
                        worktypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.WorkType", t => t.worktypeID, cascadeDelete: true)
                .Index(t => t.worktypeID);
            
            CreateTable(
                "dbo.ProjectTeam",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        teamPhaseIn = c.String(nullable: false, maxLength: 255),
                        projectID = c.Int(nullable: false),
                        Project_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Project", t => t.projectID)
                .ForeignKey("dbo.Project", t => t.Project_ID)
                .Index(t => t.projectID)
                .Index(t => t.Project_ID);
            
            CreateTable(
                "dbo.WorkType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        workTypeDesc = c.String(nullable: false, maxLength: 50),
                        workTypePrice = c.Decimal(precision: 18, scale: 2),
                        workTypeCost = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LabourSummary",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        lsHours = c.Int(nullable: false),
                        projectID = c.Int(nullable: false),
                        workerTypeID = c.Int(nullable: false),
                        WorkType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Project", t => t.projectID, cascadeDelete: true)
                .ForeignKey("dbo.WorkType", t => t.WorkType_ID, cascadeDelete: true)
                .Index(t => t.projectID)
                .Index(t => t.WorkType_ID);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        invCode = c.String(nullable: false),
                        invDesc = c.String(nullable: false),
                        AvgNet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        List = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SizeAmnt = c.Int(nullable: false),
                        SizeUnit = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MaterialRequirement",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        mreqQty = c.Int(nullable: false),
                        mreqDeliver = c.DateTime(nullable: false),
                        mreqInstall = c.DateTime(nullable: false),
                        projectID = c.Int(nullable: false),
                        inventoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Inventory", t => t.inventoryID, cascadeDelete: true)
                .ForeignKey("dbo.Project", t => t.projectID, cascadeDelete: true)
                .Index(t => t.projectID)
                .Index(t => t.inventoryID);
            
            CreateTable(
                "dbo.ProjectTool",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ptQty = c.Int(nullable: false),
                        ptDeliverFrom = c.DateTime(),
                        ptDeliveryTo = c.DateTime(),
                        projectID = c.Int(nullable: false),
                        toolID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Project", t => t.projectID, cascadeDelete: true)
                .ForeignKey("dbo.Tool", t => t.toolID, cascadeDelete: true)
                .Index(t => t.projectID)
                .Index(t => t.toolID);
            
            CreateTable(
                "dbo.Tool",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        toolDesc = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProjectTeamWorker",
                c => new
                    {
                        ProjectTeam_ID = c.Int(nullable: false),
                        Worker_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectTeam_ID, t.Worker_ID })
                .ForeignKey("dbo.ProjectTeam", t => t.ProjectTeam_ID, cascadeDelete: true)
                .ForeignKey("dbo.Worker", t => t.Worker_ID, cascadeDelete: true)
                .Index(t => t.ProjectTeam_ID)
                .Index(t => t.Worker_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectTool", "toolID", "dbo.Tool");
            DropForeignKey("dbo.ProjectTool", "projectID", "dbo.Project");
            DropForeignKey("dbo.MaterialRequirement", "projectID", "dbo.Project");
            DropForeignKey("dbo.MaterialRequirement", "inventoryID", "dbo.Inventory");
            DropForeignKey("dbo.ProjectTeam", "Project_ID", "dbo.Project");
            DropForeignKey("dbo.LabourSummary", "WorkType_ID", "dbo.WorkType");
            DropForeignKey("dbo.LabourSummary", "projectID", "dbo.Project");
            DropForeignKey("dbo.LabourRequirementDesign", "projectID", "dbo.Project");
            DropForeignKey("dbo.LabourRequirement", "WorkerID", "dbo.Worker");
            DropForeignKey("dbo.Worker", "worktypeID", "dbo.WorkType");
            DropForeignKey("dbo.ProjectTeamWorker", "Worker_ID", "dbo.Worker");
            DropForeignKey("dbo.ProjectTeamWorker", "ProjectTeam_ID", "dbo.ProjectTeam");
            DropForeignKey("dbo.Project", "ProjectTeam_ID", "dbo.ProjectTeam");
            DropForeignKey("dbo.ProjectTeam", "projectID", "dbo.Project");
            DropForeignKey("dbo.LabourRequirement", "TaskID", "dbo.TaskTest");
            DropForeignKey("dbo.LabourRequirement", "LabourRequirementDesignID", "dbo.LabourRequirementDesign");
            DropForeignKey("dbo.Project", "clientID", "dbo.Client");
            DropForeignKey("dbo.Client", "cityID", "dbo.City");
            DropIndex("dbo.ProjectTeamWorker", new[] { "Worker_ID" });
            DropIndex("dbo.ProjectTeamWorker", new[] { "ProjectTeam_ID" });
            DropIndex("dbo.ProjectTool", new[] { "toolID" });
            DropIndex("dbo.ProjectTool", new[] { "projectID" });
            DropIndex("dbo.MaterialRequirement", new[] { "inventoryID" });
            DropIndex("dbo.MaterialRequirement", new[] { "projectID" });
            DropIndex("dbo.LabourSummary", new[] { "WorkType_ID" });
            DropIndex("dbo.LabourSummary", new[] { "projectID" });
            DropIndex("dbo.ProjectTeam", new[] { "Project_ID" });
            DropIndex("dbo.ProjectTeam", new[] { "projectID" });
            DropIndex("dbo.Worker", new[] { "worktypeID" });
            DropIndex("dbo.LabourRequirement", new[] { "LabourRequirementDesignID" });
            DropIndex("dbo.LabourRequirement", new[] { "WorkerID" });
            DropIndex("dbo.LabourRequirement", new[] { "TaskID" });
            DropIndex("dbo.LabourRequirementDesign", new[] { "projectID" });
            DropIndex("dbo.Project", new[] { "ProjectTeam_ID" });
            DropIndex("dbo.Project", new[] { "clientID" });
            DropIndex("dbo.Client", new[] { "cityID" });
            DropTable("dbo.ProjectTeamWorker");
            DropTable("dbo.Tool");
            DropTable("dbo.ProjectTool");
            DropTable("dbo.MaterialRequirement");
            DropTable("dbo.Inventory");
            DropTable("dbo.LabourSummary");
            DropTable("dbo.WorkType");
            DropTable("dbo.ProjectTeam");
            DropTable("dbo.Worker");
            DropTable("dbo.TaskTest");
            DropTable("dbo.LabourRequirement");
            DropTable("dbo.LabourRequirementDesign");
            DropTable("dbo.Project");
            DropTable("dbo.Client");
            DropTable("dbo.City");
        }
    }
}
