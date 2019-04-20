namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedFriendsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        UserId = c.String(),
                        HasMesseges = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.InstantMessages", "Friend_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.InstantMessages", "Friend_Id");
            AddForeignKey("dbo.InstantMessages", "Friend_Id", "dbo.Friends", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InstantMessages", "Friend_Id", "dbo.Friends");
            DropIndex("dbo.InstantMessages", new[] { "Friend_Id" });
            DropColumn("dbo.InstantMessages", "Friend_Id");
            DropTable("dbo.Friends");
        }
    }
}
