namespace CafeDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addChangesToCountInGoodsAddtion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GoodsAddtions", "PreviousProductsCount", c => c.Int(nullable: false));
            AddColumn("dbo.GoodsAddtions", "UpdatedProductsCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GoodsAddtions", "UpdatedProductsCount");
            DropColumn("dbo.GoodsAddtions", "PreviousProductsCount");
        }
    }
}
