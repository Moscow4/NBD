namespace NBDProject.DAL.NDBMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDBsetMaterial : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Material");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Material",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        matDesc = c.String(nullable: false),
                        matType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
