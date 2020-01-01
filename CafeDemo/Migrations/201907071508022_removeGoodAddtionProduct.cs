namespace CafeDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeGoodAddtionProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GoodsAddtionProducts", "GoodsAddtionId", "dbo.GoodsAddtions");
            DropForeignKey("dbo.GoodsAddtionProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.GoodsAddtionProducts", new[] { "GoodsAddtionId" });
            DropIndex("dbo.GoodsAddtionProducts", new[] { "ProductId" });
            AddColumn("dbo.GoodsAddtions", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.GoodsAddtions", "Count", c => c.Int(nullable: false));
            CreateIndex("dbo.GoodsAddtions", "ProductId");
            AddForeignKey("dbo.GoodsAddtions", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            DropTable("dbo.GoodsAddtionProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GoodsAddtionProducts",
                c => new
                    {
                        GoodsAddtionId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GoodsAddtionId, t.ProductId });
            
            DropForeignKey("dbo.GoodsAddtions", "ProductId", "dbo.Products");
            DropIndex("dbo.GoodsAddtions", new[] { "ProductId" });
            DropColumn("dbo.GoodsAddtions", "Count");
            DropColumn("dbo.GoodsAddtions", "ProductId");
            CreateIndex("dbo.GoodsAddtionProducts", "ProductId");
            CreateIndex("dbo.GoodsAddtionProducts", "GoodsAddtionId");
            AddForeignKey("dbo.GoodsAddtionProducts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GoodsAddtionProducts", "GoodsAddtionId", "dbo.GoodsAddtions", "Id", cascadeDelete: true);
        }
    }
}
