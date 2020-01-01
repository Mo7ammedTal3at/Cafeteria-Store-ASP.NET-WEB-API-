namespace CafeDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class replaceProductByGoods : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GoodsAddtions", "ProductId", "dbo.Products");
            DropForeignKey("dbo.GoodsSells", "ProductId", "dbo.Products");
            DropIndex("dbo.GoodsAddtions", new[] { "ProductId" });
            DropIndex("dbo.GoodsSells", new[] { "ProductId" });
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        SellPrice = c.Single(nullable: false),
                        BuyPrice = c.Single(nullable: false),
                        Count = c.Int(nullable: false),
                        AlertLimit = c.Int(nullable: false),
                        AddtionTime = c.DateTime(nullable: false),
                        IsLimited = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.CategoryId);
            
            AddColumn("dbo.GoodsAddtions", "GoodsId", c => c.Int(nullable: false));
            AddColumn("dbo.GoodsSells", "GoodsId", c => c.Int(nullable: false));
            CreateIndex("dbo.GoodsAddtions", "GoodsId");
            CreateIndex("dbo.GoodsSells", "GoodsId");
            AddForeignKey("dbo.GoodsAddtions", "GoodsId", "dbo.Goods", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GoodsSells", "GoodsId", "dbo.Goods", "Id", cascadeDelete: true);
            DropColumn("dbo.GoodsAddtions", "ProductId");
            DropColumn("dbo.GoodsSells", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GoodsSells", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.GoodsAddtions", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.GoodsSells", "GoodsId", "dbo.Goods");
            DropForeignKey("dbo.GoodsAddtions", "GoodsId", "dbo.Goods");
            DropForeignKey("dbo.Goods", "CategoryId", "dbo.Categories");
            DropIndex("dbo.GoodsSells", new[] { "GoodsId" });
            DropIndex("dbo.Goods", new[] { "CategoryId" });
            DropIndex("dbo.Goods", new[] { "Name" });
            DropIndex("dbo.GoodsAddtions", new[] { "GoodsId" });
            DropColumn("dbo.GoodsSells", "GoodsId");
            DropColumn("dbo.GoodsAddtions", "GoodsId");
            DropTable("dbo.Goods");
            CreateIndex("dbo.GoodsSells", "ProductId");
            CreateIndex("dbo.GoodsAddtions", "ProductId");
            AddForeignKey("dbo.GoodsSells", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GoodsAddtions", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
