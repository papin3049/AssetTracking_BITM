using AssetTracking.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.DAL
{
    public class CategoryRepository :IDisposable
    {
        private AssetTrackingSystemDBContext db;

        public CategoryRepository()
        {
            db =new AssetTrackingSystemDBContext();
        }

        public int Save(Category category)
        {
           db.Categories.Add(category);
            int rowAffeted = db.SaveChanges();
            return rowAffeted;
        }
        public int Edit(Category category)
        {
            db.Categories.Attach(category);
            db.Entry(category).State = EntityState.Modified;
            int rowAffected = db.SaveChanges();

            return rowAffected;
        }

        public int Delete(Category category)
        {
            var singleCategory = db.Categories.FirstOrDefault(x => x.id == category.id);
            db.Categories.Remove(singleCategory);
            db.Entry(singleCategory).State = EntityState.Deleted;
            int rowAffected = db.SaveChanges();

            return rowAffected;
        }
        public List<Category> GetCategoriesByGeneralCategory(int generalCategoryId)
        {
            return db.Categories.Where(x => x.GeneralCategoryId.Equals(generalCategoryId)).ToList();
        }
        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }
    }
}
