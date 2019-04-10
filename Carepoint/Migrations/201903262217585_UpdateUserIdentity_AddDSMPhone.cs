namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserIdentity_AddDSMPhone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DSNPhone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DSNPhone");
        }
    }
}
