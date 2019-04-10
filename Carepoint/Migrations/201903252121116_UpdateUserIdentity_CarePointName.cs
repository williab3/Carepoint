namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserIdentity_CarePointName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CarePointName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CarePointName");
        }
    }
}
