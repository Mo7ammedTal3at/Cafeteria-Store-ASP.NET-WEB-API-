namespace CafeDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationForGoodsSells : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GoodsSellProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.GoodsSellProducts", new[] { "ProductId" });
            AddColumn("dbo.GoodsSells", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.GoodsSells", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.GoodsSells", "PreviousProductsCount", c => c.Int(nullable: false));
            AddColumn("dbo.GoodsSells", "UpdatedProductsCount", c => c.Int(nullable: false));
            CreateIndex("dbo.GoodsSells", "ProductId");
            AddForeignKey("dbo.GoodsSells", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GoodsSells", "ProductId", "dbo.Products");
            DropIndex("dbo.GoodsSells", new[] { "ProductId" });
            DropColumn("dbo.GoodsSells", "UpdatedProductsCount");
            DropColumn("dbo.GoodsSells", "PreviousProductsCount");
            DropColumn("dbo.GoodsSells", "Count");
            DropColumn("dbo.GoodsSells", "ProductId");
            CreateIndex("dbo.GoodsSellProducts", "ProductId");
            AddForeignKey("dbo.GoodsSellProducts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
