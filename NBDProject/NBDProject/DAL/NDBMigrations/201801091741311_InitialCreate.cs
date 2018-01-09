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
                        cityName = c.String(nullable: false, maxLength: 50),
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
                        projectBidCustAccept = c.Boolean(nullable: false),
                        projectBidMgmtAccept = c.Boolean(nullable: false),
                        projectChiefDesignAccept = c.Boolean(nullable: false),
                        projectCurrentPhase = c.String(),
                        projectFlagged = c.Boolean(nullable: false),
                        clientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Client", t => t.clientID)
                .Index(t => t.clientID);
            
            CreateTable(
                "dbo.DesignerDaily",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        stage = c.String(),
                        hour = c.Int(nullable: false),
                        SubmitDate = c.DateTime(nullable: false),
                        taskID = c.Int(nullable: false),
                        projectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Project", t => t.projectID)
                .ForeignKey("dbo.TaskTest", t => t.taskID)
                .Index(t => t.taskID)
                .Index(t => t.projectID);
            
            CreateTable(
                "dbo.TaskTest",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        taskDesc = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
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
                .ForeignKey("dbo.LabourRequirementDesign", t => t.LabourRequirementDesignID)
                .ForeignKey("dbo.Worker", t => t.WorkerID)
                .ForeignKey("dbo.TaskTest", t => t.TaskID)
                .Index(t => t.TaskID)
                .Index(t => t.WorkerID)
                .Index(t => t.LabourRequirementDesignID);
            
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
                .ForeignKey("dbo.Project", t => t.projectID)
                .Index(t => t.projectID);
            
            CreateTable(
                "dbo.ProductionDailyLabor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubmitDate = c.DateTime(nullable: false),
                        Hours = c.Int(nullable: false),
                        HourCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        taskID = c.Int(nullable: false),
                        labourID = c.Int(nullable: false),
                        projectID = c.Int(nullable: false),
                        workerID = c.Int(nullable: false),
                        LabourRequirement_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LabourRequirement", t => t.LabourRequirement_ID)
                .ForeignKey("dbo.Project", t => t.projectID)
                .ForeignKey("dbo.TaskTest", t => t.taskID)
                .ForeignKey("dbo.Worker", t => t.workerID)
                .Index(t => t.taskID)
                .Index(t => t.projectID)
                .Index(t => t.workerID)
                .Index(t => t.LabourRequirement_ID);
            
            CreateTable(
                "dbo.Worker",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false, maxLength: 30),
                        LName = c.String(nullable: false, maxLength: 30),
                        Phone = c.Long(nullable: false),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Project", t => t.projectID)
                .Index(t => t.projectID);
            
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
                .ForeignKey("dbo.Project", t => t.projectID)
                .ForeignKey("dbo.WorkType", t => t.WorkType_ID)
                .Index(t => t.projectID)
                .Index(t => t.WorkType_ID);
            
            CreateTable(
                "dbo.MaterialRequirement",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        mreqQty = c.Int(nullable: false),
                        mreqDeliver = c.DateTime(),
                        mreqInstall = c.DateTime(),
                        projectID = c.Int(nullable: false),
                        inventoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Inventory", t => t.inventoryID)
                .ForeignKey("dbo.Project", t => t.projectID)
                .Index(t => t.projectID)
                .Index(t => t.inventoryID);
            
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
                "dbo.ProductionDailyMaterial",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Qnty = c.Int(nullable: false),
                        UnitCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubmitDate = c.DateTime(nullable: false),
                        materialID = c.Int(nullable: false),
                        projectID = c.Int(nullable: false),
                        MaterialRequirement_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MaterialRequirement", t => t.MaterialRequirement_ID)
                .ForeignKey("dbo.Project", t => t.projectID)
                .Index(t => t.projectID)
                .Index(t => t.MaterialRequirement_ID);
            
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
                .ForeignKey("dbo.Project", t => t.projectID)
                .ForeignKey("dbo.Tool", t => t.toolID)
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
            DropForeignKey("dbo.ProductionDailyMaterial", "projectID", "dbo.Project");
            DropForeignKey("dbo.ProductionDailyMaterial", "MaterialRequirement_ID", "dbo.MaterialRequirement");
            DropForeignKey("dbo.MaterialRequirement", "inventoryID", "dbo.Inventory");
            DropForeignKey("dbo.LabourSummary", "WorkType_ID", "dbo.WorkType");
            DropForeignKey("dbo.LabourSummary", "projectID", "dbo.Project");
            DropForeignKey("dbo.LabourRequirement", "TaskID", "dbo.TaskTest");
            DropForeignKey("dbo.Worker", "worktypeID", "dbo.WorkType");
            DropForeignKey("dbo.ProjectTeamWorker", "Worker_ID", "dbo.Worker");
            DropForeignKey("dbo.ProjectTeamWorker", "ProjectTeam_ID", "dbo.ProjectTeam");
            DropForeignKey("dbo.ProjectTeam", "projectID", "dbo.Project");
            DropForeignKey("dbo.ProductionDailyLabor", "workerID", "dbo.Worker");
            DropForeignKey("dbo.LabourRequirement", "WorkerID", "dbo.Worker");
            DropForeignKey("dbo.ProductionDailyLabor", "taskID", "dbo.TaskTest");
            DropForeignKey("dbo.ProductionDailyLabor", "projectID", "dbo.Project");
            DropForeignKey("dbo.ProductionDailyLabor", "LabourRequirement_ID", "dbo.LabourRequirement");
            DropForeignKey("dbo.LabourRequirementDesign", "projectID", "dbo.Project");
            DropForeignKey("dbo.LabourRequirement", "LabourRequirementDesignID", "dbo.LabourRequirementDesign");
            DropForeignKey("dbo.DesignerDaily", "taskID", "dbo.TaskTest");
            DropForeignKey("dbo.DesignerDaily", "projectID", "dbo.Project");
            DropForeignKey("dbo.Project", "clientID", "dbo.Client");
            DropForeignKey("dbo.Client", "cityID", "dbo.City");
            DropIndex("dbo.ProjectTeamWorker", new[] { "Worker_ID" });
            DropIndex("dbo.ProjectTeamWorker", new[] { "ProjectTeam_ID" });
            DropIndex("dbo.ProjectTool", new[] { "toolID" });
            DropIndex("dbo.ProjectTool", new[] { "projectID" });
            DropIndex("dbo.ProductionDailyMaterial", new[] { "MaterialRequirement_ID" });
            DropIndex("dbo.ProductionDailyMaterial", new[] { "projectID" });
            DropIndex("dbo.MaterialRequirement", new[] { "inventoryID" });
            DropIndex("dbo.MaterialRequirement", new[] { "projectID" });
            DropIndex("dbo.LabourSummary", new[] { "WorkType_ID" });
            DropIndex("dbo.LabourSummary", new[] { "projectID" });
            DropIndex("dbo.ProjectTeam", new[] { "projectID" });
            DropIndex("dbo.Worker", new[] { "worktypeID" });
            DropIndex("dbo.ProductionDailyLabor", new[] { "LabourRequirement_ID" });
            DropIndex("dbo.ProductionDailyLabor", new[] { "workerID" });
            DropIndex("dbo.ProductionDailyLabor", new[] { "projectID" });
            DropIndex("dbo.ProductionDailyLabor", new[] { "taskID" });
            DropIndex("dbo.LabourRequirementDesign", new[] { "projectID" });
            DropIndex("dbo.LabourRequirement", new[] { "LabourRequirementDesignID" });
            DropIndex("dbo.LabourRequirement", new[] { "WorkerID" });
            DropIndex("dbo.LabourRequirement", new[] { "TaskID" });
            DropIndex("dbo.DesignerDaily", new[] { "projectID" });
            DropIndex("dbo.DesignerDaily", new[] { "taskID" });
            DropIndex("dbo.Project", new[] { "clientID" });
            DropIndex("dbo.Client", new[] { "cityID" });
            DropTable("dbo.ProjectTeamWorker");
            DropTable("dbo.Tool");
            DropTable("dbo.ProjectTool");
            DropTable("dbo.ProductionDailyMaterial");
            DropTable("dbo.Inventory");
            DropTable("dbo.MaterialRequirement");
            DropTable("dbo.LabourSummary");
            DropTable("dbo.WorkType");
            DropTable("dbo.ProjectTeam");
            DropTable("dbo.Worker");
            DropTable("dbo.ProductionDailyLabor");
            DropTable("dbo.LabourRequirementDesign");
            DropTable("dbo.LabourRequirement");
            DropTable("dbo.TaskTest");
            DropTable("dbo.DesignerDaily");
            DropTable("dbo.Project");
            DropTable("dbo.Client");
            DropTable("dbo.City");
        }
    }
}
