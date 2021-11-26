namespace GamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Keys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KeyString = c.String(),
                        IsUsed = c.Boolean(nullable: false),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Category_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Category_Id);
            
            AddColumn("dbo.OperatingSystems", "Product_Id", c => c.Int());
            AlterColumn("dbo.Products", "Rating", c => c.Double(nullable: false));
            CreateIndex("dbo.OperatingSystems", "Product_Id");
            AddForeignKey("dbo.OperatingSystems", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OperatingSystems", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Keys", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.ProductCategories", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductCategories", new[] { "Category_Id" });
            DropIndex("dbo.ProductCategories", new[] { "Product_Id" });
            DropIndex("dbo.OperatingSystems", new[] { "Product_Id" });
            DropIndex("dbo.Keys", new[] { "Product_Id" });
            AlterColumn("dbo.Products", "Rating", c => c.Int(nullable: false));
            DropColumn("dbo.OperatingSystems", "Product_Id");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Keys");
        }
    }
}
