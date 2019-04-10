namespace Carepoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserIdentity_SetIserNameToEmail : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE AspNetUsers SET UserName= Email");
        }
        
        public override void Down()
        {
        }
    }
}
