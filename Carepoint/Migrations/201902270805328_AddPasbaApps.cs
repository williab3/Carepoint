namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPasbaApps : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PasbaApps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PasbaAppName = c.String(),
                        Icon = c.String(),
                        AppPath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PasbaApps");
        }
    }
}
