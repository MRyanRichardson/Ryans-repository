namespace DVDLibraryWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        DirectorName = c.String(),
                    })
                .PrimaryKey(t => t.DirectorId);
            CreateTable(
                "dbo.DVDs",
                c => new
                    {
                        dvdId = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        realeaseYear = c.Int(nullable: false),
                        notes = c.String(),
                        RatingId = c.Int(nullable: false),
                        DirectorId = c.Int(nullable: false),
                        director = c.String(),
                        rating = c.String(),
                    })
                .PrimaryKey(t => t.dvdId)
                .ForeignKey("dbo.Directors", t => t.DirectorId, cascadeDelete: true)
                .ForeignKey("dbo.Ratings", t => t.RatingId, cascadeDelete: true)
                .Index(t => t.RatingId)
                .Index(t => t.DirectorId);
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        RatingName = c.String(),
                    })
                .PrimaryKey(t => t.RatingId);
        }
        public override void Down()
        {
            DropForeignKey("dbo.DVDs", "RatingId", "dbo.Ratings");
            DropForeignKey("dbo.DVDs", "DirectorId", "dbo.Directors");
            DropIndex("dbo.DVDs", new[] { "DirectorId" });
            DropIndex("dbo.DVDs", new[] { "RatingId" });
            DropTable("dbo.Ratings");
            DropTable("dbo.DVDs");
            DropTable("dbo.Directors");
        }
    }
}
