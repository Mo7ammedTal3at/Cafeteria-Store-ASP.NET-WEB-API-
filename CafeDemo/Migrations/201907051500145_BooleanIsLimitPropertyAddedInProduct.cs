namespace CafeDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BooleanIsLimitPropertyAddedInProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "IsLimited", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "IsLimited");
        }
    }
}
