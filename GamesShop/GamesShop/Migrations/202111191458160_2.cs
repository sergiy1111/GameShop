namespace GamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "SystemRequirements_Id", "dbo.SystemRequirements");
            DropIndex("dbo.Products", new[] { "SystemRequirements_Id" });
            AddColumn("dbo.Products", "Processor", c => c.String());
            AddColumn("dbo.Products", "RAM", c => c.String());
            AddColumn("dbo.Products", "VideoCard", c => c.String());
            AddColumn("dbo.Products", "DriveSpace", c => c.String());
            AddColumn("dbo.Products", "Other", c => c.String());
            DropColumn("dbo.Products", "SystemRequirements_Id");
            DropTable("dbo.SystemRequirements");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Products", "SystemRequirements_Id", c => c.Int());
            DropColumn("dbo.Products", "Other");
            DropColumn("dbo.Products", "DriveSpace");
            DropColumn("dbo.Products", "VideoCard");
            DropColumn("dbo.Products", "RAM");
            DropColumn("dbo.Products", "Processor");
            CreateIndex("dbo.Products", "SystemRequirements_Id");
            AddForeignKey("dbo.Products", "SystemRequirements_Id", "dbo.SystemRequirements", "Id");
        }
    }
}
