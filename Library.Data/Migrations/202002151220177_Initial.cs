namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Pseudonym = c.String(),
                        About = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        GenreType = c.Int(),
                        Language = c.Int(),
                        Description = c.String(),
                        ContentPath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: false)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.BookKeyWords",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        KeyWordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.KeyWordId })
                .ForeignKey("dbo.KeyWords", t => t.KeyWordId, cascadeDelete: false)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: false)
                .Index(t => t.BookId)
                .Index(t => t.KeyWordId);
            
            CreateTable(
                "dbo.KeyWords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookKeyWords", "BookId", "dbo.Books");
            DropForeignKey("dbo.BookKeyWords", "KeyWordId", "dbo.KeyWords");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.BookKeyWords", new[] { "KeyWordId" });
            DropIndex("dbo.BookKeyWords", new[] { "BookId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.KeyWords");
            DropTable("dbo.BookKeyWords");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
