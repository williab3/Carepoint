namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateApplicationUserwaddInstantMesseges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InstantMessages", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.InstantMessages", "ApplicationUser_Id");
            AddForeignKey("dbo.InstantMessages", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InstantMessages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.InstantMessages", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.InstantMessages", "ApplicationUser_Id");
        }
    }
}
