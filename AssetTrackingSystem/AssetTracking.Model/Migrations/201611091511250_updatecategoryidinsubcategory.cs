namespace AssetTracking.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecategoryidinsubcategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubCategories", "Category_id", "dbo.Categories");
            DropIndex("dbo.SubCategories", new[] { "Category_id" });
            RenameColumn(table: "dbo.SubCategories", name: "Category_id", newName: "CategoryId");
            AlterColumn("dbo.SubCategories", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.SubCategories", "CategoryId");
            AddForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            AlterColumn("dbo.SubCategories", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.SubCategories", name: "CategoryId", newName: "Category_id");
            CreateIndex("dbo.SubCategories", "Category_id");
            AddForeignKey("dbo.SubCategories", "Category_id", "dbo.Categories", "id");
        }
    }
}
