namespace NBDProject.DAL.NDBMigrations
{
    using NBDProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<NBDProject.DAL.NBDCFEntities>
    {
        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
            catch (Exception e)
            {
                throw new Exception(
                     "Seed Failed - errors follow:\n" +
                     e.InnerException.InnerException.Message.ToString(), e
                 ); // Add the original exception as the innerException
            }
        }

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
                new City { cityName = "Scotts Valley" }
            };
            cities.ForEach(d => context.Cities.AddOrUpdate(n => n.ID, d));
            SaveChanges(context);

            //Material Seed
            //new Material { matDesc = "", matType = "" }
            //var materials = new List<Material>
            //{
            //    new Material { matDesc = "Laccospadix Australasica Palm",   matType = "Plant" },
            //    new Material { matDesc = "Caryota Mitis",                   matType = "Plant" },
            //    new Material { matDesc = "Marginata",                       matType = "Plant" },
            //    new Material { matDesc = "Granite Fountain",                matType = "Pottery" },
            //    new Material { matDesc = "Granite Pots",                    matType = "Pottery" },
            //    new Material { matDesc = "Decorative Cedar Bark",           matType = "Materials" },
            //    new Material { matDesc = "Top Soil",                        matType = "Materials" }
            //};
            //materials.ForEach(d => context.Materials.AddOrUpdate(n => n.matDesc, d));
            //SaveChanges(context);

            //seed data tool
            //new Tool { toolDesc = "" }
            var tools = new List<Tool>
            {
                new Tool { toolDesc = "Contouring Rake(s)" },
                new Tool { toolDesc = "Spade(s)" },
                new Tool { toolDesc = "Landscaping Rake(s)" }
            };
            tools.ForEach(d => context.Tools.AddOrUpdate(n => n.toolDesc, d));
            SaveChanges(context);

            //Client seed
            //new Client { cliFName = "", cliLName = "", cliAddress = "", cliProvince = "", cliCode = "Z9Z9Z9", cliPhone = 9999999999, cliConFname = "", cliConLName = "", cliConPostion = "", cityID = 1 },
            var clients = new List<Client>
            {
                new Client { cliName= "London Square Mall", cliAddress = "12638 Mall Drive", cliProvince = "Califoronia",cliCode = "Z9Z9Z9", cliPhone = 4088345603, cliConFname = "Amy", cliConLName = "Besnon", cliConPostion = "Manager", cityID = 1 },
            };
            clients.ForEach(d => context.Clients.AddOrUpdate(n => n.cliPhone, d));
            SaveChanges(context);


            //WorkType Seed
            //new WorkType { workTypeDesc = "", workTypePrice = 0.00m, workTypeCost = 0.00m}
            var workTypes = new List<WorkType>
            {
               new WorkType { workTypeDesc = "Designer", workTypePrice = 1m, workTypeCost = 1m},
               new WorkType { workTypeDesc = "Sales Assoc", workTypePrice = 1m, workTypeCost = 1m},
               new WorkType { workTypeDesc = "Production", workTypePrice = 1m, workTypeCost = 1m}
            };
            workTypes.ForEach(w => context.WorkTypes.AddOrUpdate(n => n.workTypeDesc, w));
            SaveChanges(context);

            //Project seed
            //new Project { projectName = "", projectSite = "", projectBidDate = DateTime.Parse(""), projectEstStart = DateTime.Parse(""), projectEstEnd = DateTime.Parse(""), projectActStart = DateTime.Parse(""), projectActEnd = DateTime.Parse(""), projectEstCost = 0.00m, projectActCost = 0.00m, projectBidCustAccept = true, projectBidMgmtAccept = true, projectFlagged = false, clientID = 1 }
            var projects = new List<Project>
            {
                new Project { projectName = "London Square Mall", projectSite = "Main Entrance", projectBidDate = DateTime.Parse("2018-05-16"), projectEstStart = DateTime.Parse("2018-06-15"),
                projectEstEnd = DateTime.Parse("2018-06-30"), projectActStart = DateTime.Parse("2018-07-01"), projectActEnd = DateTime.Parse("2018-07-20"),
                projectEstCost = 7651.50m, projectActCost = 0.00m, projectBidCustAccept = true, projectBidMgmtAccept = true
                , clientID = 1}
            };
            projects.ForEach(d => context.Projects.AddOrUpdate(n => n.projectName, d));
            SaveChanges(context);

            //project team seed
            //new ProjectTeam { teamPhaseIn = "", projectID = 1
            var projectteams = new List<ProjectTeam>
            {
                new ProjectTeam { teamPhaseIn = "I dont know", projectID = 1,
                                    Workers = new List<Worker>
                                    {
                                        new Worker { FName = "Bod", LName = "Reinhardt", worktypeID = 2},
                                        new Worker { FName = "Tamara", LName = "Tamara Bakken", worktypeID = 1},
                                        new Worker { FName = "Sue", LName = "Kaufman", worktypeID = 3},
                                        new Worker { FName = "Monica", LName = "Goce", worktypeID = 3},
                                        new Worker { FName = "Bert", LName = "Swenson", worktypeID = 3}


                                    } }
            };
            projectteams.ForEach(t => context.ProjectTeams.AddOrUpdate(n => n.teamPhaseIn, t));
            SaveChanges(context);

            //projecttool Seed
            ///new ProjectTool { ptQty = 0, ptDeliverFrom = DateTime.Parse(""), ptDeliveryTo = DateTime.Parse(""), projectID = 1, toolID = 0 }
            var projectTools = new List<ProjectTool>
            {
                new ProjectTool { ptQty = 2, ptDeliverFrom = DateTime.Parse("2018-06-15"), ptDeliveryTo = DateTime.Parse("2018-06-15"), projectID = 1, toolID =1 },
                new ProjectTool { ptQty = 2, ptDeliverFrom = DateTime.Parse("2018-06-16"), ptDeliveryTo = DateTime.Parse("2018-06-17"), projectID = 1, toolID =2 },
                new ProjectTool { ptQty = 2, ptDeliverFrom = DateTime.Parse("2018-06-16"), ptDeliveryTo = DateTime.Parse("2018-06-17"), projectID = 1, toolID =3 }
            };
            projectTools.ForEach(p => context.ProjectTools.AddOrUpdate(n => n.toolID, p));
            SaveChanges(context);


            //Inventory seed
            //new Inventory { AvgNet = 0.00m, List = 0, SizeAmnt = 0, SizeUnit = "", materialID = 1 }
            var inventories = new List<Inventory>
            {
                new Inventory { invCode = "lacco", invDesc = "lacco australasica" , AvgNet = 450.00m    , List = 749.00m, SizeAmnt = 15   , SizeUnit = "Gal" },
                new Inventory { invCode = "cary", invDesc = "caryota" , AvgNet = 140.00m    , List = 233.00m, SizeAmnt = 7    , SizeUnit = "Gal" },
                new Inventory { invCode = "margi", invDesc = "marginata" , AvgNet = 45.00m     , List = 75.00m, SizeAmnt = 2    , SizeUnit = "Gal"},
                new Inventory { invCode = "GFN48", invDesc = "granite foundtain" ,AvgNet = 457.00m    , List = 750.00m, SizeAmnt = 48   , SizeUnit = "in"},
                new Inventory { invCode = "GP50", invDesc = "granite pot", AvgNet = 110.00m    , List = 195.00m, SizeAmnt = 50   , SizeUnit = "gal"},
                new Inventory { invCode = "CBRK5", invDesc = "decorative cedar bark", AvgNet = 7.50m      , List = 15.95m, SizeAmnt = 5    , SizeUnit = "cu ft bag" },
                new Inventory { invCode = "TSOIL", invDesc = "top soil" ,AvgNet = 12.50m     , List = 20.00m, SizeAmnt = 1    , SizeUnit = "yard"}
            };
            inventories.ForEach(i => context.Inventory.AddOrUpdate(n => n.ID, i));
            SaveChanges(context);

            //MaterialRequiremnt seeds
            //new MaterialRequirement { mreqQty = 0, mregCode = "", mregSize = "", mregNet = 0.00m, mregExtCost = 0.00m, mreqDeliver = DateTime.Parse(""), mreqInstall = DateTime.Parse(""), projectID = 0, }
            var materialRequirements = new List<MaterialRequirement>
            {
                new MaterialRequirement { mreqQty = 3 , /*mregCode= "lacco australasica", mregSize = "15 Gal"     , mregNetDesign = 749.00m, mregNetProPlan = 450.00m,*/ mreqDeliver = DateTime.Parse("2018-06-16"), mreqInstall = DateTime.Parse("2018-06-16"), projectID =1, inventoryID = 1},
                new MaterialRequirement { mreqQty = 5, /*mregCode= "caryota", mregSize = "7 Gal"     , mregNetDesign = 233.00m, mregNetProPlan = 140.00m,*/ mreqDeliver = DateTime.Parse("2018-06-17"), mreqInstall = DateTime.Parse("2018-06-17"), projectID =1, inventoryID = 2},
                new MaterialRequirement { mreqQty = 7 ,/* mregCode= "marginata", mregSize = "2 Gal"     , mregNetDesign = 75.00m, mregNetProPlan = 45.00m,*/ mreqDeliver = DateTime.Parse("2018-06-17"), mreqInstall = DateTime.Parse("2018-06-17"), projectID =1, inventoryID = 3},
                new MaterialRequirement { mreqQty = 1, /*mregCode= "granite foundtain", mregSize = "48 in"     , mregNetDesign = 750.00m, mregNetProPlan = 457.00m,*/ mreqDeliver = DateTime.Parse("2018-06-15"), mreqInstall = DateTime.Parse("2018-06-15"), projectID =1, inventoryID = 4},
                new MaterialRequirement { mreqQty = 3, /*mregCode= "granite pot", mregSize = "50 gal"     , mregNetDesign = 195.00m, mregNetProPlan = 110.00m,*/ mreqDeliver = DateTime.Parse("2018-06-15"), mreqInstall = DateTime.Parse("2018-06-15"), projectID =1, inventoryID = 5},
                new MaterialRequirement { mreqQty = 10, /*mregCode= "decorative cedar bark", mregSize = "5 cu ft bag"     , mregNetDesign = 15.95m, mregNetProPlan = 7.50m,*/ mreqDeliver = DateTime.Parse("2018-06-17"), mreqInstall = DateTime.Parse("2018-06-17"), projectID =1, inventoryID = 6},
                new MaterialRequirement { mreqQty = 1 , /*mregCode= "top soil", mregSize = "yard"     , mregNetDesign = 20.00m, mregNetProPlan = 12.50m,*/ mreqDeliver = DateTime.Parse("2018-06-15"), mreqInstall = DateTime.Parse("2018-06-15"), projectID =1, inventoryID = 7}
            };
            materialRequirements.ForEach(m => context.MaterialRequirements.AddOrUpdate(n => n.ID, m));
            SaveChanges(context);




            //Material Inventory seed 
            //new MaterialsInventory { MaterialCode = "", Desc = "", Unit = "", AveNet = 0.00m, List = 0, QIS = 0, InventoryID = 1 }
            //var materialInventories = new List<MaterialsInventory>
            //{
            //    new MaterialsInventory { MaterialCode = "", Desc = "", Unit = "", AveNet = 0.00m, List = 0, QIS = 0, InventoryID = 1}
            //};

            //seed data for labour Requiremnts
            //new LabourRequirement { desc = "", lregEstHour = 0, lregCost = 0, lregTime = DateTime.Parse("")}

            var Tasks = new List<TaskTest>
            {
                new TaskTest { taskDesc = "Bid Process"/*, taskStdTImeAmnt = 0, taskStdTimeUnit = ""*/}
            };
            Tasks.ForEach(t => context.TaskTests.AddOrUpdate(n => n.taskDesc, t));
            SaveChanges(context);

            var labourRequirementDesigns = new List<LabourRequirementDesign>
            {
                new LabourRequirementDesign { lregDHour = 10, lregDDesc = "Design Consultant", lregDUnitPrice = 65.00m, projectID = 1 }
            };
            labourRequirementDesigns.ForEach(l => context.LabourRequirementDesigns.AddOrUpdate(n => n.ID, l));
            SaveChanges(context);

            var labourRequiremnts = new List<LabourRequirement>
            {
                new LabourRequirement { lregProdHour = 12 , lregCost = 40.00m, lregTime = DateTime.Parse("2018-06-11"), TaskID = 1, WorkerID = 2, LabourRequirementDesignID = 1 }
            };
            labourRequiremnts.ForEach(l => context.LabourRequirements.AddOrUpdate(n => n.lregProdHour, l));
            SaveChanges(context);

           

            // seed data for TaskTest
            //new TaskTest { taskDesc = "", taskStdTImeAmnt = 0, taskStdTimeUnit = "", labourRequirementID = 1 }
            


            //Many to Many with ProjectTeam
            //worker seed
            //new Worker { FName = "", LName = "", worktypeID = 1 }
            //var workers = new List<Worker>
            //{
            //    new Worker { FName = "", LName = "", worktypeID = 1}
            //};

            //seed data for laboursummaries 
            //new LabourSummary { lsHours = 0, projectID = 1, workerTypeID = 1 }
            //var labourSummaries = new List<LabourSummary>
            //{
            //    new LabourSummary { lsHours = 0, projectID = 1, workerTypeID = 1 }
            //};
            //labourSummaries.ForEach(l => context.LabourSummaries.AddOrUpdate(n => n.ID, l));
            //SaveChanges(context);

        }
    }
}
