namespace AssetTracking.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Branches", new[] { "Organization_id1" });
            DropColumn("dbo.Branches", "Organization_id");
            RenameColumn(table: "dbo.Branches", name: "Organization_id1", newName: "Organization_id");
            AlterColumn("dbo.Branches", "Organization_id", c => c.Int());
            CreateIndex("dbo.Branches", "Organization_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Branches", new[] { "Organization_id" });
            AlterColumn("dbo.Branches", "Organization_id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Branches", name: "Organization_id", newName: "Organization_id1");
            AddColumn("dbo.Branches", "Organization_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Branches", "Organization_id1");
        }
    }
}
