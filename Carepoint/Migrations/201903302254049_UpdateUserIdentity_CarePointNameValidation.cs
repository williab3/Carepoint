namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserIdentity_CarePointNameValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "CarePointName", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "CarePointName", c => c.String(maxLength: 8));
        }
    }
}
