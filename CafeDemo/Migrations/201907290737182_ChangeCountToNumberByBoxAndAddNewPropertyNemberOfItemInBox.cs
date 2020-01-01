namespace CafeDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCountToNumberByBoxAndAddNewPropertyNemberOfItemInBox : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Goods", "NumberByBox", c => c.Int(nullable: false));
            AddColumn("dbo.Goods", "NumberOfItemInBox", c => c.Int(nullable: false));
            AddColumn("dbo.GoodsAddtions", "NumberByBox", c => c.Int(nullable: false));
            AddColumn("dbo.GoodsSells", "NumberByBox", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "NumberByBox", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "NumberOfItemInBox", c => c.Int(nullable: false));
            AddColumn("dbo.StoreReportViewModels", "NumberByBox", c => c.Int(nullable: false));
            DropColumn("dbo.Goods", "Count");
            DropColumn("dbo.GoodsAddtions", "Count");
            DropColumn("dbo.GoodsSells", "Count");
            DropColumn("dbo.Products", "Count");
            DropColumn("dbo.StoreReportViewModels", "Count");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StoreReportViewModels", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.GoodsSells", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.GoodsAddtions", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.Goods", "Count", c => c.Int(nullable: false));
            DropColumn("dbo.StoreReportViewModels", "NumberByBox");
            DropColumn("dbo.Products", "NumberOfItemInBox");
            DropColumn("dbo.Products", "NumberByBox");
            DropColumn("dbo.GoodsSells", "NumberByBox");
            DropColumn("dbo.GoodsAddtions", "NumberByBox");
            DropColumn("dbo.Goods", "NumberOfItemInBox");
            DropColumn("dbo.Goods", "NumberByBox");
        }
    }
}
