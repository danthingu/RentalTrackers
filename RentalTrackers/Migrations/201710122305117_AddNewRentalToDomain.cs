namespace RentalTrackers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewRentalToDomain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewRentals",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewRentals");
        }
    }
}
