namespace ManageMuseum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1st : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OutSideSpaces", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OutSideSpaces", "Name");
        }
    }
}
