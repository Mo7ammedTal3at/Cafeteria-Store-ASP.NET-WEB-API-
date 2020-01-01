namespace CafeDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        SellPrice = c.Single(nullable: false),
                        BuyPrice = c.Single(nullable: false),
                        Count = c.Int(nullable: false),
                        AlertLimit = c.Int(nullable: false),
                        AddtionTime = c.DateTime(nullable: false),
                        Seller_Id = c.Int(),
                        Order_Id = c.Int(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sellers", t => t.Seller_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.Seller_Id)
                .Index(t => t.Order_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Single(nullable: false),
                        Time = c.DateTime(nullable: false),
                        BuyerId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        SellerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SellerId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.SellerId);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CountOfProduct = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Single(nullable: false),
                        PersonId = c.Int(nullable: false),
                        PaymentOptionId = c.Int(nullable: false),
                        SellerId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentOptions", t => t.PaymentOptionId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: false)
                .ForeignKey("dbo.Sellers", t => t.SellerId, cascadeDelete: false)
                .Index(t => t.PersonId)
                .Index(t => t.PaymentOptionId)
                .Index(t => t.SellerId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.PaymentOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        MilitaryNumber = c.String(nullable: false),
                        DaragaId = c.Int(nullable: false),
                        Far3Id = c.Int(nullable: false),
                        AddtionTime = c.DateTime(nullable: false),
                        Ta2re4aId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Daragas", t => t.DaragaId, cascadeDelete: true)
                .ForeignKey("dbo.Far3", t => t.Far3Id, cascadeDelete: true)
                .ForeignKey("dbo.Ta2re4a", t => t.Ta2re4aId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.DaragaId)
                .Index(t => t.Far3Id)
                .Index(t => t.Ta2re4aId);
            
            CreateTable(
                "dbo.Daragas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Far3",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ta2re4a",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaxValue = c.Single(nullable: false),
                        CurrentValue = c.Single(nullable: false),
                        AddtionTime = c.DateTime(nullable: false),
                        IsOpen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        MilitaryNumber = c.String(nullable: false, maxLength: 13),
                        Username = c.String(nullable: false, maxLength: 13),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.MilitaryNumber, unique: true)
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Products", "Seller_Id", "dbo.Sellers");
            DropForeignKey("dbo.Payments", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.Orders", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.People", "Ta2re4aId", "dbo.Ta2re4a");
            DropForeignKey("dbo.Payments", "PersonId", "dbo.People");
            DropForeignKey("dbo.Orders", "PersonId", "dbo.People");
            DropForeignKey("dbo.People", "Far3Id", "dbo.Far3");
            DropForeignKey("dbo.People", "DaragaId", "dbo.Daragas");
            DropForeignKey("dbo.Payments", "PaymentOptionId", "dbo.PaymentOptions");
            DropForeignKey("dbo.Payments", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "OrderId", "dbo.Orders");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Sellers", new[] { "Username" });
            DropIndex("dbo.Sellers", new[] { "MilitaryNumber" });
            DropIndex("dbo.Sellers", new[] { "Name" });
            DropIndex("dbo.People", new[] { "Ta2re4aId" });
            DropIndex("dbo.People", new[] { "Far3Id" });
            DropIndex("dbo.People", new[] { "DaragaId" });
            DropIndex("dbo.People", new[] { "Name" });
            DropIndex("dbo.Payments", new[] { "OrderId" });
            DropIndex("dbo.Payments", new[] { "SellerId" });
            DropIndex("dbo.Payments", new[] { "PaymentOptionId" });
            DropIndex("dbo.Payments", new[] { "PersonId" });
            DropIndex("dbo.OrderProducts", new[] { "ProductId" });
            DropIndex("dbo.OrderProducts", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "SellerId" });
            DropIndex("dbo.Orders", new[] { "PersonId" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropIndex("dbo.Products", new[] { "Seller_Id" });
            DropIndex("dbo.Products", new[] { "Name" });
            DropIndex("dbo.Categories", new[] { "Name" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Sellers");
            DropTable("dbo.Ta2re4a");
            DropTable("dbo.Far3");
            DropTable("dbo.Daragas");
            DropTable("dbo.People");
            DropTable("dbo.PaymentOptions");
            DropTable("dbo.Payments");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Orders");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
