namespace CafeDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBuyerNameColumnToOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "BuyerName", c => c.String());
            RenameColumn("dbo.Products", "NumberByBox", "TotalItemsCount");
            RenameColumn("dbo.Products", "NumberOfItemInBox", "NumberOfItemsInBox");
            DropColumn("dbo.Orders", "BuyerId");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "BuyerId", c => c.Int(nullable: false));
            RenameColumn("dbo.Products", "TotalItemsCount", "NumberByBox");
            RenameColumn("dbo.Products", "NumberOfItemsInBox", "NumberOfItemInBox" +
                                                               "");
            DropColumn("dbo.Orders", "BuyerName");
        }
    }
}
