namespace GamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
            AlterColumn("dbo.Developers", "DeveloperName", c => c.String(nullable: false));
            AlterColumn("dbo.Publishers", "PublisherName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Publishers", "PublisherName", c => c.String());
            AlterColumn("dbo.Developers", "DeveloperName", c => c.String());
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
        }
    }
}
