namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsFavoriteToPasbaApp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PasbaApps", "IsFavorite", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PasbaApps", "IsFavorite");
        }
    }
}
