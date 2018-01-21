namespace ManageMuseum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1st : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArtPieces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Dimension = c.Double(nullable: false),
                        Year = c.DateTime(nullable: false),
                        Author = c.String(),
                        State = c.String(),
                        ArtPieceState_Id = c.Int(),
                        RoomMuseum_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArtPieceStates", t => t.ArtPieceState_Id)
                .ForeignKey("dbo.RoomMuseums", t => t.RoomMuseum_Id)
                .Index(t => t.ArtPieceState_Id)
                .Index(t => t.RoomMuseum_Id);
            
            CreateTable(
                "dbo.ArtPieceStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoomMuseums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Area = c.Double(nullable: false),
                        Floor = c.Int(nullable: false),
                        Event_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EnDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        EventState_Id = c.Int(),
                        EventType_Id = c.Int(),
                        UserAccount_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventStates", t => t.EventState_Id)
                .ForeignKey("dbo.EventTypes", t => t.EventType_Id)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccount_Id)
                .Index(t => t.EventState_Id)
                .Index(t => t.EventType_Id)
                .Index(t => t.UserAccount_Id);
            
            CreateTable(
                "dbo.EventStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OutSideSpaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Event_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAccounts", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Events", "UserAccount_Id", "dbo.UserAccounts");
            DropForeignKey("dbo.RoomMuseums", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.OutSideSpaces", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes");
            DropForeignKey("dbo.Events", "EventState_Id", "dbo.EventStates");
            DropForeignKey("dbo.ArtPieces", "RoomMuseum_Id", "dbo.RoomMuseums");
            DropForeignKey("dbo.ArtPieces", "ArtPieceState_Id", "dbo.ArtPieceStates");
            DropIndex("dbo.UserAccounts", new[] { "Role_Id" });
            DropIndex("dbo.OutSideSpaces", new[] { "Event_Id" });
            DropIndex("dbo.Events", new[] { "UserAccount_Id" });
            DropIndex("dbo.Events", new[] { "EventType_Id" });
            DropIndex("dbo.Events", new[] { "EventState_Id" });
            DropIndex("dbo.RoomMuseums", new[] { "Event_Id" });
            DropIndex("dbo.ArtPieces", new[] { "RoomMuseum_Id" });
            DropIndex("dbo.ArtPieces", new[] { "ArtPieceState_Id" });
            DropTable("dbo.Roles");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.OutSideSpaces");
            DropTable("dbo.EventTypes");
            DropTable("dbo.EventStates");
            DropTable("dbo.Events");
            DropTable("dbo.RoomMuseums");
            DropTable("dbo.ArtPieceStates");
            DropTable("dbo.ArtPieces");
        }
    }
}
