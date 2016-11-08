namespace AssetTracking.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssetLocations", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Categories", "GeneralCategoryId", "dbo.GeneralCategories");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.AssetLocations", new[] { "BranchId" });
            DropIndex("dbo.Categories", new[] { "GeneralCategoryId" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            RenameColumn(table: "dbo.AssetLocations", name: "BranchId", newName: "Branch_id");
            RenameColumn(table: "dbo.Categories", name: "GeneralCategoryId", newName: "GeneralCategory_id");
            RenameColumn(table: "dbo.SubCategories", name: "CategoryId", newName: "Category_id");
            AlterColumn("dbo.AssetLocations", "Branch_id", c => c.Int());
            AlterColumn("dbo.Categories", "GeneralCategory_id", c => c.Int());
            AlterColumn("dbo.SubCategories", "Category_id", c => c.Int());
            CreateIndex("dbo.AssetLocations", "Branch_id");
            CreateIndex("dbo.Categories", "GeneralCategory_id");
            CreateIndex("dbo.SubCategories", "Category_id");
            AddForeignKey("dbo.AssetLocations", "Branch_id", "dbo.Branches", "id");
            AddForeignKey("dbo.Categories", "GeneralCategory_id", "dbo.GeneralCategories", "id");
            AddForeignKey("dbo.SubCategories", "Category_id", "dbo.Categories", "id");
            DropColumn("dbo.GeneralCategories", "GeneralCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GeneralCategories", "GeneralCategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.SubCategories", "Category_id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "GeneralCategory_id", "dbo.GeneralCategories");
            DropForeignKey("dbo.AssetLocations", "Branch_id", "dbo.Branches");
            DropIndex("dbo.SubCategories", new[] { "Category_id" });
            DropIndex("dbo.Categories", new[] { "GeneralCategory_id" });
            DropIndex("dbo.AssetLocations", new[] { "Branch_id" });
            AlterColumn("dbo.SubCategories", "Category_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "GeneralCategory_id", c => c.Int(nullable: false));
            AlterColumn("dbo.AssetLocations", "Branch_id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.SubCategories", name: "Category_id", newName: "CategoryId");
            RenameColumn(table: "dbo.Categories", name: "GeneralCategory_id", newName: "GeneralCategoryId");
            RenameColumn(table: "dbo.AssetLocations", name: "Branch_id", newName: "BranchId");
            CreateIndex("dbo.SubCategories", "CategoryId");
            CreateIndex("dbo.Categories", "GeneralCategoryId");
            CreateIndex("dbo.AssetLocations", "BranchId");
            AddForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories", "id", cascadeDelete: true);
            AddForeignKey("dbo.Categories", "GeneralCategoryId", "dbo.GeneralCategories", "id", cascadeDelete: true);
            AddForeignKey("dbo.AssetLocations", "BranchId", "dbo.Branches", "id", cascadeDelete: true);
        }
    }
}
