namespace GamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SomeModels", newName: "OperatingSystems");
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentText = c.String(),
                        Product_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Description = c.String(),
                        Rating = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        Developer_Id = c.Int(),
                        Publisher_Id = c.Int(),
                        SystemRequirements_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Developers", t => t.Developer_Id)
                .ForeignKey("dbo.Publishers", t => t.Publisher_Id)
                .ForeignKey("dbo.SystemRequirements", t => t.SystemRequirements_Id)
                .Index(t => t.Developer_Id)
                .Index(t => t.Publisher_Id)
                .Index(t => t.SystemRequirements_Id);
            
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeveloperName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublisherName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SystemRequirements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Processor = c.String(),
                        RAM = c.String(),
                        VideoCard = c.String(),
                        DriveSpace = c.String(),
                        Other = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            AlterColumn("dbo.OperatingSystems", "Name", c => c.String(nullable: false));
            DropColumn("dbo.OperatingSystems", "Desc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OperatingSystems", "Desc", c => c.String());
            DropForeignKey("dbo.Files", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "SystemRequirements_Id", "dbo.SystemRequirements");
            DropForeignKey("dbo.Products", "Publisher_Id", "dbo.Publishers");
            DropForeignKey("dbo.Products", "Developer_Id", "dbo.Developers");
            DropIndex("dbo.Files", new[] { "Product_Id" });
            DropIndex("dbo.Products", new[] { "SystemRequirements_Id" });
            DropIndex("dbo.Products", new[] { "Publisher_Id" });
            DropIndex("dbo.Products", new[] { "Developer_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "Product_Id" });
            AlterColumn("dbo.OperatingSystems", "Name", c => c.String());
            DropTable("dbo.Files");
            DropTable("dbo.SystemRequirements");
            DropTable("dbo.Publishers");
            DropTable("dbo.Developers");
            DropTable("dbo.Products");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            RenameTable(name: "dbo.OperatingSystems", newName: "SomeModels");
        }
    }
}
