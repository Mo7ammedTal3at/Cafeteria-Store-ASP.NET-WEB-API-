namespace CafeDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStoreModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GoodsAddtionProducts",
                c => new
                    {
                        GoodsAddtionId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GoodsAddtionId, t.ProductId })
                .ForeignKey("dbo.GoodsAddtions", t => t.GoodsAddtionId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.GoodsAddtionId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.GoodsAddtions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        SellerId = c.Int(nullable: false),
                        TagerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sellers", t => t.SellerId, cascadeDelete: true)
                .ForeignKey("dbo.Tagers", t => t.TagerId, cascadeDelete: true)
                .Index(t => t.SellerId)
                .Index(t => t.TagerId);
            
            CreateTable(
                "dbo.GoodsAddtionPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Double(nullable: false),
                        Time = c.DateTime(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                        GoodsAddtionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GoodsAddtions", t => t.GoodsAddtionId, cascadeDelete: true)
                .Index(t => t.GoodsAddtionId);
            
            CreateTable(
                "dbo.GoodsSells",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KafteriaId = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        SellerAdminId = c.Int(nullable: false),
                        SellerId = c.Int(nullable: false),
                        Seller_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kafterias", t => t.KafteriaId, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SellerId, cascadeDelete: false)
                .ForeignKey("dbo.Sellers", t => t.SellerAdminId, cascadeDelete: false)
                .ForeignKey("dbo.Sellers", t => t.Seller_Id)
                .Index(t => t.KafteriaId)
                .Index(t => t.SellerAdminId)
                .Index(t => t.SellerId)
                .Index(t => t.Seller_Id);
            
            CreateTable(
                "dbo.GoodsSellPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Double(nullable: false),
                        Time = c.DateTime(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                        GoodsSellId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GoodsSells", t => t.GoodsSellId, cascadeDelete: true)
                .Index(t => t.GoodsSellId);
            
            CreateTable(
                "dbo.GoodsSellProducts",
                c => new
                    {
                        GoodsSellId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GoodsSellId, t.ProductId })
                .ForeignKey("dbo.GoodsSells", t => t.GoodsSellId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.GoodsSellId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Kafterias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tagers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GoodsAddtionProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.GoodsAddtions", "TagerId", "dbo.Tagers");
            DropForeignKey("dbo.GoodsSells", "Seller_Id", "dbo.Sellers");
            DropForeignKey("dbo.GoodsSells", "SellerAdminId", "dbo.Sellers");
            DropForeignKey("dbo.GoodsSells", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.GoodsSells", "KafteriaId", "dbo.Kafterias");
            DropForeignKey("dbo.GoodsSellProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.GoodsSellProducts", "GoodsSellId", "dbo.GoodsSells");
            DropForeignKey("dbo.GoodsSellPayments", "GoodsSellId", "dbo.GoodsSells");
            DropForeignKey("dbo.GoodsAddtions", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.GoodsAddtionProducts", "GoodsAddtionId", "dbo.GoodsAddtions");
            DropForeignKey("dbo.GoodsAddtionPayments", "GoodsAddtionId", "dbo.GoodsAddtions");
            DropIndex("dbo.GoodsSellProducts", new[] { "ProductId" });
            DropIndex("dbo.GoodsSellProducts", new[] { "GoodsSellId" });
            DropIndex("dbo.GoodsSellPayments", new[] { "GoodsSellId" });
            DropIndex("dbo.GoodsSells", new[] { "Seller_Id" });
            DropIndex("dbo.GoodsSells", new[] { "SellerId" });
            DropIndex("dbo.GoodsSells", new[] { "SellerAdminId" });
            DropIndex("dbo.GoodsSells", new[] { "KafteriaId" });
            DropIndex("dbo.GoodsAddtionPayments", new[] { "GoodsAddtionId" });
            DropIndex("dbo.GoodsAddtions", new[] { "TagerId" });
            DropIndex("dbo.GoodsAddtions", new[] { "SellerId" });
            DropIndex("dbo.GoodsAddtionProducts", new[] { "ProductId" });
            DropIndex("dbo.GoodsAddtionProducts", new[] { "GoodsAddtionId" });
            DropTable("dbo.Tagers");
            DropTable("dbo.Kafterias");
            DropTable("dbo.GoodsSellProducts");
            DropTable("dbo.GoodsSellPayments");
            DropTable("dbo.GoodsSells");
            DropTable("dbo.GoodsAddtionPayments");
            DropTable("dbo.GoodsAddtions");
            DropTable("dbo.GoodsAddtionProducts");
        }
    }
}
