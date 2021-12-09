namespace GamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductCategories", newName: "CategoryProducts");
            DropPrimaryKey("dbo.CategoryProducts");
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Keys", t => t.Key_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Key_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Products", "Cart_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Cart_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CategoryProducts", new[] { "Category_Id", "Product_Id" });
            CreateIndex("dbo.Products", "Cart_Id");
            CreateIndex("dbo.AspNetUsers", "Cart_Id");
            AddForeignKey("dbo.AspNetUsers", "Cart_Id", "dbo.Carts", "Id");
            AddForeignKey("dbo.Products", "Cart_Id", "dbo.Carts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "Key_Id", "dbo.Keys");
            DropForeignKey("dbo.AspNetUsers", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "Key_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Cart_Id" });
            DropIndex("dbo.Products", new[] { "Cart_Id" });
            DropPrimaryKey("dbo.CategoryProducts");
            DropColumn("dbo.AspNetUsers", "Cart_Id");
            DropColumn("dbo.Products", "Cart_Id");
            DropTable("dbo.Orders");
            DropTable("dbo.Carts");
            AddPrimaryKey("dbo.CategoryProducts", new[] { "Product_Id", "Category_Id" });
            RenameTable(name: "dbo.CategoryProducts", newName: "ProductCategories");
        }
    }
}
