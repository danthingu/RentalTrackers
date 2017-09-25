namespace RentalTrackers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBirthdayToCustomerTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = '7/5/1993' WHERE Id = 3");
            Sql("UPDATE Customers SET Birthdate = '1/5/1993' WHERE Id = 4");
        }

        public override void Down()
        {
        }
    }
}
