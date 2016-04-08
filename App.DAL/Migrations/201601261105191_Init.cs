namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Title = c.String(),
                        Text = c.String(),
                        Views = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reference", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Reference",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Key = c.String(),
                        Value = c.String(),
                        ValueInt = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nickname = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Text = c.String(),
                        Date = c.DateTime(nullable: false),
                        Views = c.Int(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blog", "UserId", "dbo.User");
            DropForeignKey("dbo.Blog", "StatusId", "dbo.Reference");
            DropForeignKey("dbo.Reference", "CategoryId", "dbo.Category");
            DropIndex("dbo.Reference", new[] { "CategoryId" });
            DropIndex("dbo.Blog", new[] { "StatusId" });
            DropIndex("dbo.Blog", new[] { "UserId" });
            DropTable("dbo.News");
            DropTable("dbo.User");
            DropTable("dbo.Category");
            DropTable("dbo.Reference");
            DropTable("dbo.Blog");
        }
    }
}
