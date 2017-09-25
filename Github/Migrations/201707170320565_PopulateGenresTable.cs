namespace Github.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) values (1,'Jazz')");
            Sql("INSERT INTO Genres (Id, Name) values (2,'Blue')");
            Sql("INSERT INTO Genres (Id, Name) values (3,'Rock')");
            Sql("INSERT INTO Genres (Id, Name) values (4,'Country')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id in (1,2,3,4)");
        }
    }
}
