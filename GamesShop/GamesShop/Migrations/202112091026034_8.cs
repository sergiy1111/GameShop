namespace GamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Key_Id", "dbo.Keys");
            DropIndex("dbo.Orders", new[] { "Key_Id" });
            AddColumn("dbo.Orders", "Summary", c => c.Double(nullable: false));
            AddColumn("dbo.Keys", "Order_Id", c => c.Int());
            CreateIndex("dbo.Keys", "Order_Id");
            AddForeignKey("dbo.Keys", "Order_Id", "dbo.Orders", "Id");
            DropColumn("dbo.Orders", "Key_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Key_Id", c => c.Int());
            DropForeignKey("dbo.Keys", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Keys", new[] { "Order_Id" });
            DropColumn("dbo.Keys", "Order_Id");
            DropColumn("dbo.Orders", "Summary");
            CreateIndex("dbo.Orders", "Key_Id");
            AddForeignKey("dbo.Orders", "Key_Id", "dbo.Keys", "Id");
        }
    }
}
