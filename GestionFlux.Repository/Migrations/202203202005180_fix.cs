namespace GestionFlux.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlackBoards", "MostProfitableProduct_Id", "dbo.Products");
            DropForeignKey("dbo.ConsumerReports", "PreferredProduct_Id", "dbo.Products");
            DropForeignKey("dbo.ProductProfiles", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.EquipmentUses", "ProductProfile_Id", "dbo.ProductProfiles");
            DropIndex("dbo.BlackBoards", new[] { "MostProfitableProduct_Id" });
            DropIndex("dbo.ConsumerReports", new[] { "PreferredProduct_Id" });
            DropIndex("dbo.EquipmentUses", new[] { "ProductProfile_Id" });
            DropIndex("dbo.ProductProfiles", new[] { "Product_Id" });
            DropIndex("dbo.Users", new[] { "department_Id" });
            RenameColumn(table: "dbo.BlackBoards", name: "ConsumerChoiceProduct_Id", newName: "HighValueProduct_Id");
            RenameIndex(table: "dbo.BlackBoards", name: "IX_ConsumerChoiceProduct_Id", newName: "IX_HighValueProduct_Id");
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Locality = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Ref = c.String(),
                        InStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResourceUses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Product_Id = c.Int(),
                        Resource_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Resources", t => t.Resource_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Resource_Id);
            
            CreateTable(
                "dbo.SuggEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        InAccess = c.Boolean(nullable: false),
                        Equipment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.Equipment_Id)
                .Index(t => t.Equipment_Id);
            
            CreateTable(
                "dbo.SuggProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SuggPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InAccess = c.Boolean(nullable: false),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.SuggResources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        InAccess = c.Boolean(nullable: false),
                        Resource_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resources", t => t.Resource_Id)
                .Index(t => t.Resource_Id);
            
            AddColumn("dbo.Products", "Score", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Ref", c => c.String());
            AddColumn("dbo.Equipments", "Ref", c => c.String());
            AddColumn("dbo.Equipments", "InStock", c => c.Int(nullable: false));
            AddColumn("dbo.EquipmentUses", "Product_Id", c => c.Int());
            AddColumn("dbo.Users", "Username", c => c.String());
            AddColumn("dbo.Users", "Matricule", c => c.String());
            AddColumn("dbo.Purchases", "Client_Id", c => c.Int());
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Users", "Password", c => c.Int(nullable: false));
            CreateIndex("dbo.EquipmentUses", "Product_Id");
            CreateIndex("dbo.Users", "Department_Id");
            CreateIndex("dbo.Purchases", "Client_Id");
            AddForeignKey("dbo.EquipmentUses", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Purchases", "Client_Id", "dbo.Clients", "Id");
            DropColumn("dbo.BlackBoards", "EquipmentAssignment");
            DropColumn("dbo.BlackBoards", "MostProfitableProduct_Id");
            DropColumn("dbo.EquipmentUses", "ProductProfile_Id");
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "Email");
            DropTable("dbo.ConsumerReports");
            DropTable("dbo.ProductProfiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        Product_Id = c.Int(),
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "Name", c => c.String());
            AddColumn("dbo.EquipmentUses", "ProductProfile_Id", c => c.Int());
            AddColumn("dbo.BlackBoards", "MostProfitableProduct_Id", c => c.Int());
            AddColumn("dbo.BlackBoards", "EquipmentAssignment", c => c.Int(nullable: false));
            DropForeignKey("dbo.SuggResources", "Resource_Id", "dbo.Resources");
            DropForeignKey("dbo.SuggProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.SuggEquipments", "Equipment_Id", "dbo.Equipments");
            DropForeignKey("dbo.ResourceUses", "Resource_Id", "dbo.Resources");
            DropForeignKey("dbo.ResourceUses", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Purchases", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.EquipmentUses", "Product_Id", "dbo.Products");
            DropIndex("dbo.SuggResources", new[] { "Resource_Id" });
            DropIndex("dbo.SuggProducts", new[] { "Product_Id" });
            DropIndex("dbo.SuggEquipments", new[] { "Equipment_Id" });
            DropIndex("dbo.ResourceUses", new[] { "Resource_Id" });
            DropIndex("dbo.ResourceUses", new[] { "Product_Id" });
            DropIndex("dbo.Purchases", new[] { "Client_Id" });
            DropIndex("dbo.Users", new[] { "Department_Id" });
            DropIndex("dbo.EquipmentUses", new[] { "Product_Id" });
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Products", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.Purchases", "Client_Id");
            DropColumn("dbo.Users", "Matricule");
            DropColumn("dbo.Users", "Username");
            DropColumn("dbo.EquipmentUses", "Product_Id");
            DropColumn("dbo.Equipments", "InStock");
            DropColumn("dbo.Equipments", "Ref");
            DropColumn("dbo.Products", "Ref");
            DropColumn("dbo.Products", "Score");
            DropTable("dbo.SuggResources");
            DropTable("dbo.SuggProducts");
            DropTable("dbo.SuggEquipments");
            DropTable("dbo.ResourceUses");
            DropTable("dbo.Resources");
            DropTable("dbo.Clients");
            RenameIndex(table: "dbo.BlackBoards", name: "IX_HighValueProduct_Id", newName: "IX_ConsumerChoiceProduct_Id");
            RenameColumn(table: "dbo.BlackBoards", name: "HighValueProduct_Id", newName: "ConsumerChoiceProduct_Id");
            CreateIndex("dbo.Users", "department_Id");
            CreateIndex("dbo.ProductProfiles", "Product_Id");
            CreateIndex("dbo.EquipmentUses", "ProductProfile_Id");
            CreateIndex("dbo.ConsumerReports", "PreferredProduct_Id");
            CreateIndex("dbo.BlackBoards", "MostProfitableProduct_Id");
            AddForeignKey("dbo.EquipmentUses", "ProductProfile_Id", "dbo.ProductProfiles", "Id");
            AddForeignKey("dbo.ProductProfiles", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.ConsumerReports", "PreferredProduct_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.BlackBoards", "MostProfitableProduct_Id", "dbo.Products", "Id");
        }
    }
}
