namespace GestionFlux.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addfieldstoblackboard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuggEquipments", "BlackBoard_Id", c => c.Int());
            AddColumn("dbo.SuggProducts", "BlackBoard_Id", c => c.Int());
            AddColumn("dbo.SuggResources", "BlackBoard_Id", c => c.Int());
            CreateIndex("dbo.SuggEquipments", "BlackBoard_Id");
            CreateIndex("dbo.SuggProducts", "BlackBoard_Id");
            CreateIndex("dbo.SuggResources", "BlackBoard_Id");
            AddForeignKey("dbo.SuggEquipments", "BlackBoard_Id", "dbo.BlackBoards", "Id");
            AddForeignKey("dbo.SuggProducts", "BlackBoard_Id", "dbo.BlackBoards", "Id");
            AddForeignKey("dbo.SuggResources", "BlackBoard_Id", "dbo.BlackBoards", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SuggResources", "BlackBoard_Id", "dbo.BlackBoards");
            DropForeignKey("dbo.SuggProducts", "BlackBoard_Id", "dbo.BlackBoards");
            DropForeignKey("dbo.SuggEquipments", "BlackBoard_Id", "dbo.BlackBoards");
            DropIndex("dbo.SuggResources", new[] { "BlackBoard_Id" });
            DropIndex("dbo.SuggProducts", new[] { "BlackBoard_Id" });
            DropIndex("dbo.SuggEquipments", new[] { "BlackBoard_Id" });
            DropColumn("dbo.SuggResources", "BlackBoard_Id");
            DropColumn("dbo.SuggProducts", "BlackBoard_Id");
            DropColumn("dbo.SuggEquipments", "BlackBoard_Id");
        }
    }
}
