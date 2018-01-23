namespace ManageMuseum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1st : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoomMuseums", "SumRoomArtPieces", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "SumArtPieces", c => c.Int(nullable: false));
            AddColumn("dbo.OutSideSpaces", "Area", c => c.Double(nullable: false));
            AddColumn("dbo.OutSideSpaces", "SpaceState_Id", c => c.Int());
            CreateIndex("dbo.OutSideSpaces", "SpaceState_Id");
            AddForeignKey("dbo.OutSideSpaces", "SpaceState_Id", "dbo.SpaceStates", "Id");
            DropColumn("dbo.RoomMuseums", "Area");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoomMuseums", "Area", c => c.Double(nullable: false));
            DropForeignKey("dbo.OutSideSpaces", "SpaceState_Id", "dbo.SpaceStates");
            DropIndex("dbo.OutSideSpaces", new[] { "SpaceState_Id" });
            DropColumn("dbo.OutSideSpaces", "SpaceState_Id");
            DropColumn("dbo.OutSideSpaces", "Area");
            DropColumn("dbo.Events", "SumArtPieces");
            DropColumn("dbo.RoomMuseums", "SumRoomArtPieces");
        }
    }
}
