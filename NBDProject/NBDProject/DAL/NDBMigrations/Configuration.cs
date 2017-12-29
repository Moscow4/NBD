namespace NBDProject.DAL.NDBMigrations
{
    using NBDProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NBDProject.DAL.NBDCFEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DAL\NDBMigrations";
        }

        protected override void Seed(NBDProject.DAL.NBDCFEntities context)
        {
            //city seed
            //new City { city = "" }
            var cities = new List<City>
            {
                new City { city = "Scotts Valley" }
            };
            cities.ForEach(d => context.Cities.AddOrUpdate(n => n.city, d));
            context.SaveChanges();

            //Material Seed
            //new Material { matDesc = "", matType = "" }
            var materials = new List<Material>
            {
                new Material { matDesc = "Laccospadix Australasica Palm",   matType = "Plant" },
                new Material { matDesc = "Caryota Mitis",                   matType = "Plant" },
                new Material { matDesc = "Marginata",                       matType = "Plant" },
                new Material { matDesc = "Granite Fountain",                matType = "Pottery" },
                new Material { matDesc = "Granite Pots",                    matType = "Pottery" },
                new Material { matDesc = "Decorative Cedar Bark",           matType = "Materials" },
                new Material { matDesc = "Top Soil",                        matType = "Materials" }
            };
            materials.ForEach(d => context.Materials.AddOrUpdate(n => n.matDesc, d));
            context.SaveChanges();

            //seed data tool
            //new Tool { toolDesc = "" }
            var tools = new List<Tool>
            {
                new Tool { toolDesc = "Contouring Rake(s)" },
                new Tool { toolDesc = "Spade(s)" },
                new Tool { toolDesc = "Landscaping Rake(s)" }
            };
            tools.ForEach(d => context.Tools.AddOrUpdate(n => n.toolDesc, d));
            context.SaveChanges();

            //Client seed
            //new Client { cliFName = "", cliLName = "", cliAddress = "", cliProvince = "", cliCode = "Z9Z9Z9", cliPhone = 9999999999, cliConFname = "", cliConLName = "", cliConPostion = "", cityID = 1 },
            var clients = new List<Client>
            {
                new Client { cliFName= "London Square",cliLName = "Mall", cliAddress = "12638 Mall Drive", cliProvince = "Califoronia",cliCode = "Z9Z9Z9", cliPhone = 4088345603, cliConFname = "Amy", cliConLName = "Besnon", cliConPostion = "Manager", cityID = 1 },
            };
            clients.ForEach(d => context.Clients.AddOrUpdate(n => n.cliPhone, d));
            context.SaveChanges();


            //WorkType Seed
            //new WorkType { workTypeDesc = "", workTypePrice = 0.00m, workTypeCost = 0.00m}
            var workTypes = new List<WorkType>
            {
               new WorkType { workTypeDesc = "", workTypePrice = 0.00m, workTypeCost = 0.00m}
            };

            //Project seed
            //new Project { projectName = "", projectSite = "", projectBidDate = DateTime.Parse(""), projectEstStart = DateTime.Parse(""), projectEstEnd = DateTime.Parse(""), projectActStart = DateTime.Parse(""), projectActEnd = DateTime.Parse(""), projectEstCost = 0.00m, projectActCost = 0.00m, projectBidCustAccept = true, projectBidMgmtAccept = true, projectFlagged = false, clientID = 1 }
            var projects = new List<Project>
            {
                new Project { projectName = "London Square Mall", projectSite = "Main Entrance", projectBidDate = DateTime.Parse("05-16-2018"), projectEstStart = DateTime.Parse("06-15-2018"),
                projectEstEnd = DateTime.Parse("06-30-2018"), projectActStart = DateTime.Parse(""), projectActEnd = DateTime.Parse(""),
                projectEstCost = 7651.50m, projectActCost = 0.00m, projectBidCustAccept = true, projectBidMgmtAccept = true,
                projectFlagged = false, clientID = 1 }
            };
            projects.ForEach(d => context.Projects.AddOrUpdate(n => n.projectName, d));
            context.SaveChanges();

            //project team seed
            //new ProjectTeam { teamPhaseIn = "", projectID = 1
            var projectteams = new List<ProjectTeam>
            {
                new ProjectTeam { teamPhaseIn = "", projectID = 1}
            };


            //projecttool Seed
            ///new ProjectTool { ptQty = 0, ptDeliverFrom = DateTime.Parse(""), ptDeliveryTo = DateTime.Parse(""), projectID = 1, toolID = 0 }
            var projectTools = new List<ProjectTool>
            {
                new ProjectTool { ptQty = 2, ptDeliverFrom = DateTime.Parse("6-15-2018"), ptDeliveryTo = DateTime.Parse(""), projectID = 1, toolID =1 },
                new ProjectTool { ptQty = 2, ptDeliverFrom = DateTime.Parse("6-16-2018"), ptDeliveryTo = DateTime.Parse(""), projectID = 1, toolID =2 },
                new ProjectTool { ptQty = 2, ptDeliverFrom = DateTime.Parse("6-16-2018"), ptDeliveryTo = DateTime.Parse(""), projectID = 1, toolID =3 }
            };



            //Inventory seed
            //new Inventory { AvgNet = 0.00m, List = 0, SizeAmnt = 0, SizeUnit = "", materialID = 1 }
            var inventories = new List<Inventory>
            {
                new Inventory { AvgNet = 450.00m    , List = 0, SizeAmnt = 15   , SizeUnit = "Gal"          , materialID = 1 },
                new Inventory { AvgNet = 140.00m    , List = 0, SizeAmnt = 7    , SizeUnit = "Gal"          , materialID = 2 },
                new Inventory { AvgNet = 45.00m     , List = 0, SizeAmnt = 2    , SizeUnit = "Gal"          , materialID = 3 },
                new Inventory { AvgNet = 457.00m    , List = 0, SizeAmnt = 48   , SizeUnit = "in"           , materialID = 4 },
                new Inventory { AvgNet = 110.00m    , List = 0, SizeAmnt = 50   , SizeUnit = "gal"          , materialID = 5 },
                new Inventory { AvgNet = 7.50m      , List = 0, SizeAmnt = 5    , SizeUnit = "cu ft bag"    , materialID = 6 },
                new Inventory { AvgNet = 12.50m     , List = 0, SizeAmnt = 1    , SizeUnit = "yard"         , materialID = 7 }
            };

            //MaterialRequiremnt seeds
            //new MaterialRequirement { mreqQty = 0, mregCode = "", mregSize = "", mregNet = 0.00m, mregExtCost = 0.00m, mreqDeliver = DateTime.Parse(""), mreqInstall = DateTime.Parse(""), projectID = 0, }
            var materialRequirements = new List<MaterialRequirement>
            {
                new MaterialRequirement { mreqQty = 3  , mregCode= "Lacco", mregSize = "15 Gal"     , mregNet = 749.00m,    mregExtCost = 2247.00m, mreqDeliver = DateTime.Parse("2018-6-16"), mreqInstall = DateTime.Parse("2018-6-16"), projectID =1, inventoryID = 1},
                new MaterialRequirement { mreqQty = 5  , mregCode= "Cary" , mregSize = "7 Gal"      , mregNet = 233.00m,    mregExtCost = 1165.00m, mreqDeliver = DateTime.Parse("2018-6-17"), mreqInstall = DateTime.Parse("2018-6-17"), projectID =1, inventoryID = 2},
                new MaterialRequirement { mreqQty = 7  , mregCode= "Margi", mregSize = "2 Gal"      , mregNet = 75.00m ,    mregExtCost = 525.00m , mreqDeliver = DateTime.Parse("2018-6-17"), mreqInstall = DateTime.Parse("2018-6-17"), projectID =1, inventoryID = 3},
                new MaterialRequirement { mreqQty = 48 , mregCode= "GFN48", mregSize = "48 in"      , mregNet = 750.00m,    mregExtCost = 750.00m , mreqDeliver = DateTime.Parse("2018-6-15"), mreqInstall = DateTime.Parse("2018-6-15"), projectID =1, inventoryID = 4},
                new MaterialRequirement { mreqQty = 50 , mregCode= "GP50" , mregSize = "50 Gal"     , mregNet = 195.00m,    mregExtCost = 585.00m , mreqDeliver = DateTime.Parse("2018-6-15"), mreqInstall = DateTime.Parse("2018-6-15"), projectID =1, inventoryID = 5},
                new MaterialRequirement { mreqQty = 10 , mregCode= "CBRK5", mregSize = "5 cu ft bag", mregNet = 15.95m ,    mregExtCost = 159.50m , mreqDeliver = DateTime.Parse("2018-6-17"), mreqInstall = DateTime.Parse("2018-6-17"), projectID =1, inventoryID = 6},
                new MaterialRequirement { mreqQty = 1  , mregCode= "TSOIL", mregSize = "Yard"       , mregNet = 20.00m ,    mregExtCost = 20.00m  , mreqDeliver = DateTime.Parse("2018-6-15"), mreqInstall = DateTime.Parse("2018-6-15"), projectID =1, inventoryID = 7}
            };



            //Material Inventory seed 
            //new MaterialsInventory { MaterialCode = "", Desc = "", Unit = "", AveNet = 0.00m, List = 0, QIS = 0, InventoryID = 1 }
            var materialInventories = new List<MaterialsInventory>
            {
                new MaterialsInventory { MaterialCode = "", Desc = "", Unit = "", AveNet = 0.00m, List = 0, QIS = 0, InventoryID = 1}
            };

            //seed data for labour Requiremnts
            //new LabourRequirement { desc = "", lregEstHour = 0, lregCost = 0, lregTime = DateTime.Parse("")}
            var labourRequiremnts = new List<LabourRequirement>
            {
                new LabourRequirement { desc = "", lregEstHour =0 , lregCost = 0, lregTime = DateTime.Parse("")}
            };

            // seed data for TaskTest
            //new TaskTest { taskDesc = "", taskStdTImeAmnt = 0, taskStdTimeUnit = "", labourRequirementID = 1 }
            var Tasks = new List<TaskTest>
            {
                new TaskTest { taskDesc = "", taskStdTImeAmnt = 0, taskStdTimeUnit = ""}
            };



            //worker seed
            //new Worker { FName = "", LName = "", worktypeID = 1 }
            var workers = new List<Worker>
            {
                new Worker { FName = "", LName = "", worktypeID = 1}
            };

            //seed data for laboursummaries 
            //new LabourSummary { lsHours = 0, projectID = 1, workerTypeID = 1 }
            var labourSummaries = new List<LabourSummary>
            {
                new LabourSummary { lsHours = 0, projectID = 1, workerTypeID = 1 }
            };

        }
    }
}
