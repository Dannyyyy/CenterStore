namespace CSortCentrAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageUpdateMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "MessageId", c => c.Int(nullable: false));
            AddColumn("dbo.Images", "Name", c => c.String());
            AddColumn("dbo.Images", "IsIdentified", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "IsIdentified");
            DropColumn("dbo.Images", "Name");
            DropColumn("dbo.Images", "MessageId");
        }
    }
}
