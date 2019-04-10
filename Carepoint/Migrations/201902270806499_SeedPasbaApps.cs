namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedPasbaApps : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT PasbaApps (PasbaAppName, Icon, AppPath) VALUES ('Coder Help Desk', '/Content/Images/CHDIcon.png', '');");
            Sql("INSERT PasbaApps (PasbaAppName, Icon, AppPath) VALUES ('Coder Manager', '/Content/Images/CoderMangerIcon.png', '');");
        }
        
        public override void Down()
        {
        }
    }
}
