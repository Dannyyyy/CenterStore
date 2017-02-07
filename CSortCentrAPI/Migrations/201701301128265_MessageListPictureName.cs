namespace CSortCentrAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageListPictureName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ListOfPicturesNames", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "ListOfPicturesNames");
        }
    }
}
