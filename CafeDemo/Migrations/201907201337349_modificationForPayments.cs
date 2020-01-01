namespace CafeDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationForPayments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GoodsAddtionPayments", "GoodsAddtionId", "dbo.GoodsAddtions");
            DropForeignKey("dbo.GoodsSellPayments", "GoodsSellId", "dbo.GoodsSells");
            DropIndex("dbo.GoodsAddtionPayments", new[] { "GoodsAddtionId" });
            DropIndex("dbo.GoodsSellPayments", new[] { "GoodsSellId" });
            RenameColumn(table: "dbo.GoodsAddtionPayments", name: "GoodsAddtionId", newName: "GoodsAddtion_Id");
            RenameColumn(table: "dbo.GoodsSellPayments", name: "GoodsSellId", newName: "GoodsSell_Id");
            CreateTable(
                "dbo.StoreReportViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        SellPrice = c.Single(nullable: false),
                        BuyPrice = c.Single(nullable: false),
                        Count = c.Int(nullable: false),
                        AlertLimit = c.Int(nullable: false),
                        CategoryName = c.String(),
                        IsLimited = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            AddColumn("dbo.GoodsAddtionPayments", "TagerId", c => c.Int(nullable: false));
            AddColumn("dbo.GoodsAddtionPayments", "SellerId", c => c.Int(nullable: false));
            AddColumn("dbo.GoodsSellPayments", "SellerAdminId", c => c.Int(nullable: false));
            AddColumn("dbo.GoodsSellPayments", "SellerId", c => c.Int(nullable: false));
            AddColumn("dbo.GoodsSellPayments", "Seller_Id", c => c.Int());
            AlterColumn("dbo.GoodsAddtionPayments", "GoodsAddtion_Id", c => c.Int());
            AlterColumn("dbo.GoodsSellPayments", "GoodsSell_Id", c => c.Int());
            CreateIndex("dbo.GoodsAddtionPayments", "TagerId");
            CreateIndex("dbo.GoodsAddtionPayments", "SellerId");
            CreateIndex("dbo.GoodsAddtionPayments", "GoodsAddtion_Id");
            CreateIndex("dbo.GoodsSellPayments", "SellerAdminId");
            CreateIndex("dbo.GoodsSellPayments", "SellerId");
            CreateIndex("dbo.GoodsSellPayments", "Seller_Id");
            CreateIndex("dbo.GoodsSellPayments", "GoodsSell_Id");
            AddForeignKey("dbo.GoodsAddtionPayments", "SellerId", "dbo.Sellers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GoodsSellPayments", "SellerId", "dbo.Sellers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GoodsSellPayments", "SellerAdminId", "dbo.Sellers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.GoodsSellPayments", "Seller_Id", "dbo.Sellers", "Id");
            AddForeignKey("dbo.GoodsAddtionPayments", "TagerId", "dbo.Tagers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GoodsAddtionPayments", "GoodsAddtion_Id", "dbo.GoodsAddtions", "Id");
            AddForeignKey("dbo.GoodsSellPayments", "GoodsSell_Id", "dbo.GoodsSells", "Id");
            DropColumn("dbo.GoodsAddtionPayments", "IsPaid");
            DropColumn("dbo.GoodsSellPayments", "IsPaid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GoodsSellPayments", "IsPaid", c => c.Boolean(nullable: false));
            AddColumn("dbo.GoodsAddtionPayments", "IsPaid", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.GoodsSellPayments", "GoodsSell_Id", "dbo.GoodsSells");
            DropForeignKey("dbo.GoodsAddtionPayments", "GoodsAddtion_Id", "dbo.GoodsAddtions");
            DropForeignKey("dbo.GoodsAddtionPayments", "TagerId", "dbo.Tagers");
            DropForeignKey("dbo.GoodsSellPayments", "Seller_Id", "dbo.Sellers");
            DropForeignKey("dbo.GoodsSellPayments", "SellerAdminId", "dbo.Sellers");
            DropForeignKey("dbo.GoodsSellPayments", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.GoodsAddtionPayments", "SellerId", "dbo.Sellers");
            DropIndex("dbo.StoreReportViewModels", new[] { "Name" });
            DropIndex("dbo.GoodsSellPayments", new[] { "GoodsSell_Id" });
            DropIndex("dbo.GoodsSellPayments", new[] { "Seller_Id" });
            DropIndex("dbo.GoodsSellPayments", new[] { "SellerId" });
            DropIndex("dbo.GoodsSellPayments", new[] { "SellerAdminId" });
            DropIndex("dbo.GoodsAddtionPayments", new[] { "GoodsAddtion_Id" });
            DropIndex("dbo.GoodsAddtionPayments", new[] { "SellerId" });
            DropIndex("dbo.GoodsAddtionPayments", new[] { "TagerId" });
            AlterColumn("dbo.GoodsSellPayments", "GoodsSell_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.GoodsAddtionPayments", "GoodsAddtion_Id", c => c.Int(nullable: false));
            DropColumn("dbo.GoodsSellPayments", "Seller_Id");
            DropColumn("dbo.GoodsSellPayments", "SellerId");
            DropColumn("dbo.GoodsSellPayments", "SellerAdminId");
            DropColumn("dbo.GoodsAddtionPayments", "SellerId");
            DropColumn("dbo.GoodsAddtionPayments", "TagerId");
            DropTable("dbo.StoreReportViewModels");
            RenameColumn(table: "dbo.GoodsSellPayments", name: "GoodsSell_Id", newName: "GoodsSellId");
            RenameColumn(table: "dbo.GoodsAddtionPayments", name: "GoodsAddtion_Id", newName: "GoodsAddtionId");
            CreateIndex("dbo.GoodsSellPayments", "GoodsSellId");
            CreateIndex("dbo.GoodsAddtionPayments", "GoodsAddtionId");
            AddForeignKey("dbo.GoodsSellPayments", "GoodsSellId", "dbo.GoodsSells", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GoodsAddtionPayments", "GoodsAddtionId", "dbo.GoodsAddtions", "Id", cascadeDelete: true);
        }
    }
}
