namespace CafeDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationToPaymentsRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GoodsSellPayments", "GoodsSell_Id", "dbo.GoodsSells");
            DropForeignKey("dbo.GoodsAddtionPayments", "GoodsAddtion_Id", "dbo.GoodsAddtions");
            DropIndex("dbo.GoodsAddtionPayments", new[] { "GoodsAddtion_Id" });
            DropIndex("dbo.GoodsSellPayments", new[] { "GoodsSell_Id" });
            DropColumn("dbo.GoodsAddtionPayments", "GoodsAddtion_Id");
            DropColumn("dbo.GoodsSellPayments", "GoodsSell_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GoodsSellPayments", "GoodsSell_Id", c => c.Int());
            AddColumn("dbo.GoodsAddtionPayments", "GoodsAddtion_Id", c => c.Int());
            CreateIndex("dbo.GoodsSellPayments", "GoodsSell_Id");
            CreateIndex("dbo.GoodsAddtionPayments", "GoodsAddtion_Id");
            AddForeignKey("dbo.GoodsAddtionPayments", "GoodsAddtion_Id", "dbo.GoodsAddtions", "Id");
            AddForeignKey("dbo.GoodsSellPayments", "GoodsSell_Id", "dbo.GoodsSells", "Id");
        }
    }
}
