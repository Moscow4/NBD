namespace NBDProject.DAL.NDBMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialCreate : DbMigration
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
                .ForeignKey("dbo.City", t => t.cityID)
                .Index(t => t.cityID);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AvgNet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        List = c.Int(nullable: false),
                        SizeAmnt = c.Int(nullable: false),
                        SizeUnit = c.String(nullable: false),
                        materialID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Material", t => t.materialID)
                .Index(t => t.materialID);
            
            CreateTable(
                "dbo.Material",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        matDesc = c.String(nullable: false),
                        matType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LabourRequirement",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        desc = c.String(nullable: false, maxLength: 50),
                        lregEstHour = c.Int(nullable: false),
                        lregCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        lregTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TaskTest",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        taskDesc = c.String(nullable: false, maxLength: 50),
                        taskStdTImeAmnt = c.Int(),
                        taskStdTimeUnit = c.String(maxLength: 20),
                        labourRequirementID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LabourRequirement", t => t.labourRequirementID)
                .Index(t => t.labourRequirementID);
            
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
                .ForeignKey("dbo.Project", t => t.projectID)
                .ForeignKey("dbo.WorkType", t => t.WorkType_ID)
                .Index(t => t.projectID)
                .Index(t => t.WorkType_ID);
            
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
                        projectActStart = c.DateTime(nullable: false),
                        projectActEnd = c.DateTime(nullable: false),
                        projectEstCost = c.Decimal(precision: 18, scale: 2),
                        projectActCost = c.Decimal(precision: 18, scale: 2),
                        projectBidCustAccept = c.Boolean(),
                        projectBidMgmtAccept = c.Boolean(),
                        projectCurrentPhase = c.String(),
                        projectFlagged = c.Boolean(),
                        clientID = c.Int(nullable: false),
                        ProjectTeam_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Client", t => t.clientID)
                .ForeignKey("dbo.ProjectTeam", t => t.ProjectTeam_ID)
                .Index(t => t.clientID)
                .Index(t => t.ProjectTeam_ID);
            
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
                "dbo.Worker",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false, maxLength: 30),
                        LName = c.String(nullable: false, maxLength: 30),
                        worktypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.WorkType", t => t.worktypeID)
                .Index(t => t.worktypeID);
            
            CreateTable(
                "dbo.ProjectTeam",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        teamPhaseIn = c.String(nullable: false, maxLength: 255),
                        projectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MaterialRequirement",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        mreqQty = c.Int(nullable: false),
                        mregCode = c.String(nullable: false),
                        mregSize = c.String(nullable: false),
                        mregNet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        mregExtCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        mreqDeliver = c.DateTime(nullable: false),
                        mreqInstall = c.DateTime(nullable: false),
                        projectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Project", t => t.projectID)
                .Index(t => t.projectID);
            
            CreateTable(
                "dbo.ProjectTool",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ptQty = c.Int(nullable: false),
                        ptDeliverFrom = c.DateTime(),
                        ptDeliveryTo = c.DateTime(),
                        projectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Project", t => t.projectID)
                .Index(t => t.projectID);
            
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
            DropForeignKey("dbo.ProjectTool", "projectID", "dbo.Project");
            DropForeignKey("dbo.MaterialRequirement", "projectID", "dbo.Project");
            DropForeignKey("dbo.LabourSummary", "WorkType_ID", "dbo.WorkType");
            DropForeignKey("dbo.Worker", "worktypeID", "dbo.WorkType");
            DropForeignKey("dbo.ProjectTeamWorker", "Worker_ID", "dbo.Worker");
            DropForeignKey("dbo.ProjectTeamWorker", "ProjectTeam_ID", "dbo.ProjectTeam");
            DropForeignKey("dbo.Project", "ProjectTeam_ID", "dbo.ProjectTeam");
            DropForeignKey("dbo.LabourSummary", "projectID", "dbo.Project");
            DropForeignKey("dbo.Project", "clientID", "dbo.Client");
            DropForeignKey("dbo.TaskTest", "labourRequirementID", "dbo.LabourRequirement");
            DropForeignKey("dbo.Inventory", "materialID", "dbo.Material");
            DropForeignKey("dbo.Client", "cityID", "dbo.City");
            DropIndex("dbo.ProjectTeamWorker", new[] { "Worker_ID" });
            DropIndex("dbo.ProjectTeamWorker", new[] { "ProjectTeam_ID" });
            DropIndex("dbo.ProjectTool", new[] { "projectID" });
            DropIndex("dbo.MaterialRequirement", new[] { "projectID" });
            DropIndex("dbo.Worker", new[] { "worktypeID" });
            DropIndex("dbo.Project", new[] { "ProjectTeam_ID" });
            DropIndex("dbo.Project", new[] { "clientID" });
            DropIndex("dbo.LabourSummary", new[] { "WorkType_ID" });
            DropIndex("dbo.LabourSummary", new[] { "projectID" });
            DropIndex("dbo.TaskTest", new[] { "labourRequirementID" });
            DropIndex("dbo.Inventory", new[] { "materialID" });
            DropIndex("dbo.Client", new[] { "cityID" });
            DropTable("dbo.ProjectTeamWorker");
            DropTable("dbo.Tool");
            DropTable("dbo.ProjectTool");
            DropTable("dbo.MaterialRequirement");
            DropTable("dbo.ProjectTeam");
            DropTable("dbo.Worker");
            DropTable("dbo.WorkType");
            DropTable("dbo.Project");
            DropTable("dbo.LabourSummary");
            DropTable("dbo.TaskTest");
            DropTable("dbo.LabourRequirement");
            DropTable("dbo.Material");
            DropTable("dbo.Inventory");
            DropTable("dbo.Client");
            DropTable("dbo.City");
        }
    }
}
