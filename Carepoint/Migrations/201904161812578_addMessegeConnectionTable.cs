namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMessegeConnectionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessegeConnections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConnectionId = c.String(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MessegeConnections");
        }
    }
}
