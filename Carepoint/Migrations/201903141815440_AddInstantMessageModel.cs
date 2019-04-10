namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInstantMessageModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InstantMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                        Message = c.String(),
                        Recipient_Id = c.String(maxLength: 128),
                        Sender_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Recipient_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Sender_Id)
                .Index(t => t.Recipient_Id)
                .Index(t => t.Sender_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InstantMessages", "Sender_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.InstantMessages", "Recipient_Id", "dbo.AspNetUsers");
            DropIndex("dbo.InstantMessages", new[] { "Sender_Id" });
            DropIndex("dbo.InstantMessages", new[] { "Recipient_Id" });
            DropTable("dbo.InstantMessages");
        }
    }
}
