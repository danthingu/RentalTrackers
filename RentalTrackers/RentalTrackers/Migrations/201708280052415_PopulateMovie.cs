namespace RentalTrackers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovie : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, MovieInfoId) VALUES ('Inception', '1')");
            Sql("INSERT INTO Movies (Name, MovieInfoId) VALUES ('The Notebook', '2')");
        }
        
        public override void Down()
        {
        }
    }
}
