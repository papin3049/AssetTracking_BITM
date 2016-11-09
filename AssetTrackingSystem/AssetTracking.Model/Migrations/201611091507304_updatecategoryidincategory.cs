namespace AssetTracking.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecategoryidincategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "GeneralCategory_id", "dbo.GeneralCategories");
            DropIndex("dbo.Categories", new[] { "GeneralCategory_id" });
            RenameColumn(table: "dbo.Categories", name: "GeneralCategory_id", newName: "GeneralCategoryId");
            AlterColumn("dbo.Categories", "GeneralCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "GeneralCategoryId");
            AddForeignKey("dbo.Categories", "GeneralCategoryId", "dbo.GeneralCategories", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "GeneralCategoryId", "dbo.GeneralCategories");
            DropIndex("dbo.Categories", new[] { "GeneralCategoryId" });
            AlterColumn("dbo.Categories", "GeneralCategoryId", c => c.Int());
            RenameColumn(table: "dbo.Categories", name: "GeneralCategoryId", newName: "GeneralCategory_id");
            CreateIndex("dbo.Categories", "GeneralCategory_id");
            AddForeignKey("dbo.Categories", "GeneralCategory_id", "dbo.GeneralCategories", "id");
        }
    }
}
