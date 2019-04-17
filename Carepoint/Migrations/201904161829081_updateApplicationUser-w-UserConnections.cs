namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateApplicationUserwUserConnections : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MessegeConnections", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.MessegeConnections", "ApplicationUser_Id");
            AddForeignKey("dbo.MessegeConnections", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MessegeConnections", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MessegeConnections", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.MessegeConnections", "ApplicationUser_Id");
        }
    }
}
