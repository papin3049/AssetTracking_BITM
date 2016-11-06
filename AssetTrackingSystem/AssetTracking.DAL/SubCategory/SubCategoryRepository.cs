using AssetTracking.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AssetTracking.DAL
{
  public  class SubCategoryRepository :IDisposable
    {
       
        
            private AssetTrackingSystemDBContext db;

            public SubCategoryRepository()
            {
                db = new AssetTrackingSystemDBContext();

            }
        public int Save(SubCategory subCategory)
        {
            db.SubCategories.Add(subCategory);

            int rowAffected = db.SaveChanges();

            return rowAffected;

        }

        public int Edit(SubCategory subCategory)
        {
            db.SubCategories.Attach(subCategory);
            db.Entry(subCategory).State = EntityState.Modified;
            int rowAffected = db.SaveChanges();

            return rowAffected;
        }

        public int Delete(SubCategory subCategory)
        {
            var singleSubCategory = db.SubCategories.FirstOrDefault(x => x.id == subCategory.id);
            db.SubCategories.Remove(singleSubCategory);
            db.Entry(singleSubCategory).State = EntityState.Deleted;
            int rowAffected = db.SaveChanges();

            return rowAffected;
        }
        public List<SubCategory> GetAll()
            {
                return db.SubCategories.ToList();
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
