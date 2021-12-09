namespace GamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OperatingSystems", "Product_Id", "dbo.Products");
            DropIndex("dbo.OperatingSystems", new[] { "Product_Id" });
            CreateTable(
                "dbo.OperatingSystemProducts",
                c => new
                    {
                        OperatingSystem_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OperatingSystem_Id, t.Product_Id })
                .ForeignKey("dbo.OperatingSystems", t => t.OperatingSystem_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.OperatingSystem_Id)
                .Index(t => t.Product_Id);
            
            DropColumn("dbo.OperatingSystems", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OperatingSystems", "Product_Id", c => c.Int());
            DropForeignKey("dbo.OperatingSystemProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.OperatingSystemProducts", "OperatingSystem_Id", "dbo.OperatingSystems");
            DropIndex("dbo.OperatingSystemProducts", new[] { "Product_Id" });
            DropIndex("dbo.OperatingSystemProducts", new[] { "OperatingSystem_Id" });
            DropTable("dbo.OperatingSystemProducts");
            CreateIndex("dbo.OperatingSystems", "Product_Id");
            AddForeignKey("dbo.OperatingSystems", "Product_Id", "dbo.Products", "Id");
        }
    }
}
