namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInstantMessage_addHasBeenRead : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InstantMessages", "HasBeenRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InstantMessages", "HasBeenRead");
        }
    }
}
