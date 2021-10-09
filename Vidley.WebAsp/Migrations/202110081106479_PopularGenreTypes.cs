namespace Vidley.WebAsp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopularGenreTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Action')");

        }

        public override void Down()
        {
        }
    }
}
