namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movedInstantMessagesfromapplicationUserToFriend : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InstantMessages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.InstantMessages", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.InstantMessages", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InstantMessages", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.InstantMessages", "ApplicationUser_Id");
            AddForeignKey("dbo.InstantMessages", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
