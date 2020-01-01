namespace CafeDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteSoldiersCafeTabes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderProducts", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.OrderProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Payments", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "PersonId", "dbo.People");
            DropForeignKey("dbo.Orders", "SellerId", "dbo.Sellers");
            DropIndex("dbo.Orders", new[] { "PersonId" });
            DropIndex("dbo.Orders", new[] { "SellerId" });
            DropIndex("dbo.OrderProducts", new[] { "OrderId" });
            DropIndex("dbo.OrderProducts", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "Name" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Payments", new[] { "OrderId" });
            DropColumn("dbo.Payments", "OrderId");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        SellPrice = c.Single(nullable: false),
                        BuyPrice = c.Single(nullable: false),
                        TotalItemsCount = c.Int(nullable: false),
                        NumberOfItemsInBox = c.Int(nullable: false),
                        AlertLimit = c.Int(nullable: false),
                        AddtionTime = c.DateTime(nullable: false),
                        IsLimited = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CountOfProduct = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId });
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Single(nullable: false),
                        Time = c.DateTime(nullable: false),
                        BuyerName = c.String(),
                        PersonId = c.Int(nullable: false),
                        SellerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Payments", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Payments", "OrderId");
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.Products", "Name", unique: true);
            CreateIndex("dbo.OrderProducts", "ProductId");
            CreateIndex("dbo.OrderProducts", "OrderId");
            CreateIndex("dbo.Orders", "SellerId");
            CreateIndex("dbo.Orders", "PersonId");
            AddForeignKey("dbo.Orders", "SellerId", "dbo.Sellers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "PersonId", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderProducts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderProducts", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
