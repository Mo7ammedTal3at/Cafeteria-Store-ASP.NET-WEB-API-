namespace CafeDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationForGoodsSells2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GoodsSellProducts", "GoodsSellId", "dbo.GoodsSells");
            DropIndex("dbo.GoodsSellProducts", new[] { "GoodsSellId" });
            DropTable("dbo.GoodsSellProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GoodsSellProducts",
                c => new
                    {
                        GoodsSellId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GoodsSellId, t.ProductId });
            
            CreateIndex("dbo.GoodsSellProducts", "GoodsSellId");
            AddForeignKey("dbo.GoodsSellProducts", "GoodsSellId", "dbo.GoodsSells", "Id", cascadeDelete: true);
        }
    }
}
