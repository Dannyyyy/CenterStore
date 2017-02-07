namespace CSortCentrAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessagesInitialMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        NumericFirstParam = c.Int(nullable: false),
                        NumericSecondParam = c.Int(nullable: false),
                        NumericThirdParam = c.Int(nullable: false),
                        StringFirstParam = c.String(),
                        StringSecondParam = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
