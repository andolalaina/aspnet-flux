namespace GestionFlux.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlackBoards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EquipmentAssignment = c.Int(nullable: false),
                        ConsumerChoiceProduct_Id = c.Int(),
                        MostProfitableProduct_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ConsumerChoiceProduct_Id)
                .ForeignKey("dbo.Products", t => t.MostProfitableProduct_Id)
                .Index(t => t.ConsumerChoiceProduct_Id)
                .Index(t => t.MostProfitableProduct_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        InStock = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConsumerReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportDate = c.DateTime(nullable: false),
                        PreferredProduct_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.PreferredProduct_Id)
                .Index(t => t.PreferredProduct_Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Usability = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EquipmentUses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UseDuration = c.Int(nullable: false),
                        UseDegradation = c.Int(nullable: false),
                        Equipment_Id = c.Int(),
                        ProductProfile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.Equipment_Id)
                .ForeignKey("dbo.ProductProfiles", t => t.ProductProfile_Id)
                .Index(t => t.Equipment_Id)
                .Index(t => t.ProductProfile_Id);
            
            CreateTable(
                "dbo.ProductProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        SendDate = c.DateTime(nullable: false),
                        SendTo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.SendTo_Id)
                .Index(t => t.SendTo_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        department_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.department_Id)
                .Index(t => t.department_Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        SendDate = c.DateTime(nullable: false),
                        Sender_Id = c.Int(),
                        SendTo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Sender_Id)
                .ForeignKey("dbo.Users", t => t.SendTo_Id)
                .Index(t => t.Sender_Id)
                .Index(t => t.SendTo_Id);
            
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Request_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Requests", t => t.Request_Id)
                .Index(t => t.Request_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Responses", "Request_Id", "dbo.Requests");
            DropForeignKey("dbo.Requests", "SendTo_Id", "dbo.Users");
            DropForeignKey("dbo.Requests", "Sender_Id", "dbo.Users");
            DropForeignKey("dbo.Purchases", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Notifications", "SendTo_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "department_Id", "dbo.Departments");
            DropForeignKey("dbo.EquipmentUses", "ProductProfile_Id", "dbo.ProductProfiles");
            DropForeignKey("dbo.ProductProfiles", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.EquipmentUses", "Equipment_Id", "dbo.Equipments");
            DropForeignKey("dbo.ConsumerReports", "PreferredProduct_Id", "dbo.Products");
            DropForeignKey("dbo.BlackBoards", "MostProfitableProduct_Id", "dbo.Products");
            DropForeignKey("dbo.BlackBoards", "ConsumerChoiceProduct_Id", "dbo.Products");
            DropIndex("dbo.Responses", new[] { "Request_Id" });
            DropIndex("dbo.Requests", new[] { "SendTo_Id" });
            DropIndex("dbo.Requests", new[] { "Sender_Id" });
            DropIndex("dbo.Purchases", new[] { "Product_Id" });
            DropIndex("dbo.Users", new[] { "department_Id" });
            DropIndex("dbo.Notifications", new[] { "SendTo_Id" });
            DropIndex("dbo.ProductProfiles", new[] { "Product_Id" });
            DropIndex("dbo.EquipmentUses", new[] { "ProductProfile_Id" });
            DropIndex("dbo.EquipmentUses", new[] { "Equipment_Id" });
            DropIndex("dbo.ConsumerReports", new[] { "PreferredProduct_Id" });
            DropIndex("dbo.BlackBoards", new[] { "MostProfitableProduct_Id" });
            DropIndex("dbo.BlackBoards", new[] { "ConsumerChoiceProduct_Id" });
            DropTable("dbo.Responses");
            DropTable("dbo.Requests");
            DropTable("dbo.Purchases");
            DropTable("dbo.Users");
            DropTable("dbo.Notifications");
            DropTable("dbo.ProductProfiles");
            DropTable("dbo.EquipmentUses");
            DropTable("dbo.Equipments");
            DropTable("dbo.Departments");
            DropTable("dbo.ConsumerReports");
            DropTable("dbo.Products");
            DropTable("dbo.BlackBoards");
        }
    }
}
