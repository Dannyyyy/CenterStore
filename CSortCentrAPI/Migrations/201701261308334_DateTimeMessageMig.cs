namespace CSortCentrAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeMessageMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "CreatedDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "CreatedDateTime");
        }
    }
}
