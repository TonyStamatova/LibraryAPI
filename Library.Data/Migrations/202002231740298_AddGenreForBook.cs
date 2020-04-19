namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreForBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Genre", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Genre");
        }
    }
}
