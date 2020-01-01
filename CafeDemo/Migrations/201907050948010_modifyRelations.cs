namespace CafeDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "PersonId", "dbo.People");
            DropForeignKey("dbo.Payments", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.Products", "Seller_Id", "dbo.Sellers");
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Seller_Id" });
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Payments", new[] { "PersonId" });
            DropIndex("dbo.Payments", new[] { "SellerId" });
            RenameColumn(table: "dbo.Products", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "Seller_Id");
            DropColumn("dbo.Products", "Order_Id");
            DropColumn("dbo.Payments", "PersonId");
            DropColumn("dbo.Payments", "SellerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "SellerId", c => c.Int(nullable: false));
            AddColumn("dbo.Payments", "PersonId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Order_Id", c => c.Int());
            AddColumn("dbo.Products", "Seller_Id", c => c.Int());
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            AlterColumn("dbo.Products", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Payments", "SellerId");
            CreateIndex("dbo.Payments", "PersonId");
            CreateIndex("dbo.Products", "Category_Id");
            CreateIndex("dbo.Products", "Order_Id");
            CreateIndex("dbo.Products", "Seller_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Products", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Products", "Seller_Id", "dbo.Sellers", "Id");
            AddForeignKey("dbo.Payments", "SellerId", "dbo.Sellers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "PersonId", "dbo.People", "Id", cascadeDelete: true);
        }
    }
}
