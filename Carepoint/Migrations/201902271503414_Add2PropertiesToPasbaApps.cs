namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add2PropertiesToPasbaApps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PasbaApps", "IsRestricted", c => c.Boolean(nullable: false));
            AddColumn("dbo.PasbaApps", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PasbaApps", "Description");
            DropColumn("dbo.PasbaApps", "IsRestricted");
        }
    }
}
