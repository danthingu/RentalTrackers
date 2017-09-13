namespace RentalTrackers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieInfo : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieInfoes (Id, Genre, ReleaseDate, DateAdded,NumberInStock) VALUES (1, 'Scifi', '7/7/2010', '8/7/2010', 7)");
            Sql("INSERT INTO MovieInfoes (Id, Genre, ReleaseDate, DateAdded,NumberInStock) VALUES (2, 'Drama', '5/7/2010', '6/7/2010', 5)");
        }

        public override void Down()
        {
        }
    }
}
