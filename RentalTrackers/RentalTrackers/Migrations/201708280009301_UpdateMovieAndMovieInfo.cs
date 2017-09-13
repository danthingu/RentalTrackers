namespace RentalTrackers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieAndMovieInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MovieInfoId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovieInfoes", t => t.MovieInfoId, cascadeDelete: true)
                .Index(t => t.MovieInfoId);
            
            CreateTable(
                "dbo.MovieInfoes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Genre = c.String(nullable: false, maxLength: 255),
                        ReleaseDate = c.DateTime(),
                        DateAdded = c.DateTime(),
                        NumberInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieInfoId", "dbo.MovieInfoes");
            DropIndex("dbo.Movies", new[] { "MovieInfoId" });
            DropTable("dbo.MovieInfoes");
            DropTable("dbo.Movies");
        }
    }
}
