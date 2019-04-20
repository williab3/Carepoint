namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateApplicationUserwchangedFriendTypeFromApplicationUserToFriend : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AspNetUsers", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.Friends", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Friends", "ApplicationUser_Id");
            DropColumn("dbo.AspNetUsers", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropIndex("dbo.Friends", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Friends", "ApplicationUser_Id");
            CreateIndex("dbo.AspNetUsers", "ApplicationUser_Id");
        }
    }
}
