namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUserConnectionswaddUserName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MessegeConnections", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MessegeConnections", "UserName");
        }
    }
}
