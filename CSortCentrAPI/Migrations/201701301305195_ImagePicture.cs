namespace CSortCentrAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagePicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Picture", c => c.Binary());
            DropColumn("dbo.Images", "Pictute");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "Pictute", c => c.Binary());
            DropColumn("dbo.Images", "Picture");
        }
    }
}
