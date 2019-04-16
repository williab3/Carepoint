namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMessesConnectionwIsConnectionActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MessegeConnections", "IsConnectionActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MessegeConnections", "IsConnectionActive");
        }
    }
}
