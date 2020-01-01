namespace CafeDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificationsForPriceAndCount : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GoodsSells", "SellerAdminId", "dbo.Sellers");
            DropForeignKey("dbo.GoodsSells", "Seller_Id", "dbo.Sellers");
            DropIndex("dbo.GoodsSells", new[] { "SellerAdminId" });
            DropIndex("dbo.GoodsSells", new[] { "Seller_Id" });
            RenameColumn(table: "dbo.Goods", name: "NumberByBox", newName: "TotalItemsCount");
            AddColumn("dbo.Goods", "NumberOfItemsInBox", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.GoodsAddtions", name: "NumberByBox", newName: "NumberOfItems");
            AddColumn("dbo.GoodsAddtions", "ItemsSellPrice", c => c.Double(nullable: false));
            AddColumn("dbo.GoodsAddtions", "ItemsBuyPrice", c => c.Double(nullable: false));
            RenameColumn(table: "dbo.GoodsSells", name: "NumberByBox", newName: "NumberOfItems");
            AddColumn("dbo.GoodsSells", "ItemsSellPrice", c => c.Double(nullable: false));
            AddColumn("dbo.GoodsSells", "ItemsBuyPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.GoodsSells", "SellerId", c => c.Int(nullable: false));
            DropColumn("dbo.GoodsSells", "SellerAdminId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GoodsSells", "NumberByBox", c => c.Int(nullable: false));
            AddColumn("dbo.GoodsSells", "SellerAdminId", c => c.Int(nullable: false));
            AddColumn("dbo.GoodsAddtions", "NumberByBox", c => c.Int(nullable: false));
            AddColumn("dbo.Goods", "NumberOfItemInBox", c => c.Int(nullable: false));
            AddColumn("dbo.Goods", "NumberByBox", c => c.Int(nullable: false));
            DropForeignKey("dbo.GoodsSells", "SellerId", "dbo.Sellers");
            DropIndex("dbo.GoodsSells", new[] { "SellerId" });
            AlterColumn("dbo.GoodsSells", "SellerId", c => c.Int());
            DropColumn("dbo.GoodsSells", "ItemsBuyPrice");
            DropColumn("dbo.GoodsSells", "ItemsSellPrice");
            DropColumn("dbo.GoodsSells", "NumberOfItems");
            DropColumn("dbo.GoodsAddtions", "ItemsBuyPrice");
            DropColumn("dbo.GoodsAddtions", "ItemsSellPrice");
            DropColumn("dbo.GoodsAddtions", "NumberOfItems");
            DropColumn("dbo.Goods", "NumberOfItemsInBox");
            DropColumn("dbo.Goods", "TotalItemsCount");
            RenameColumn(table: "dbo.GoodsSells", name: "SellerId", newName: "Seller_Id");
            AddColumn("dbo.GoodsSells", "SellerId", c => c.Int(nullable: false));
            CreateIndex("dbo.GoodsSells", "Seller_Id");
            CreateIndex("dbo.GoodsSells", "SellerId");
            CreateIndex("dbo.GoodsSells", "SellerAdminId");
            AddForeignKey("dbo.GoodsSells", "Seller_Id", "dbo.Sellers", "Id");
            AddForeignKey("dbo.GoodsSells", "SellerAdminId", "dbo.Sellers", "Id", cascadeDelete: true);
        }
    }
}
