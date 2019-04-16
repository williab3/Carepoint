namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateInstantMessgewConnectionId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InstantMessages", "ConnectionId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InstantMessages", "ConnectionId");
        }
    }
}
