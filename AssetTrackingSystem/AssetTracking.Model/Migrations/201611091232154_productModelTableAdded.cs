namespace AssetTracking.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productModelTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        modelName = c.String(),
                        modelDetails = c.String(),
                        subCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.SubCategories", t => t.subCategoryId, cascadeDelete: true)
                .Index(t => t.subCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductModels", "subCategoryId", "dbo.SubCategories");
            DropIndex("dbo.ProductModels", new[] { "subCategoryId" });
            DropTable("dbo.ProductModels");
        }
    }
}
