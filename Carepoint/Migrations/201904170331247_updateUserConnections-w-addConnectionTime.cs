namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUserConnectionswaddConnectionTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MessegeConnections", "ConnectionTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MessegeConnections", "ConnectionTime");
        }
    }
}
