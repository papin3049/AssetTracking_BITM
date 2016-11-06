using AssetTracking.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.DAL
{
   public class GeneralCategoryRepository :IDisposable
   {
       private AssetTrackingSystemDBContext db;
        public GeneralCategoryRepository()
        {
             db = new AssetTrackingSystemDBContext();
        }

       public int Save(GeneralCategory generalCategory)
       {
           db.GeneralCategories.Add(generalCategory);

           int rowAffected = db.SaveChanges();

           return rowAffected;

       }
        public int Edit(GeneralCategory generalCategory)
        {
            db.GeneralCategories.Attach(generalCategory);
            db.Entry(generalCategory).State = EntityState.Modified;
            int rowAffected = db.SaveChanges();

            return rowAffected;
        }

        public int Delete(GeneralCategory generalCategory)
        {
            var singleGeneralCategory = db.GeneralCategories.FirstOrDefault(x => x.id == generalCategory.id);
            db.GeneralCategories.Remove(singleGeneralCategory);
            db.Entry(singleGeneralCategory).State = EntityState.Deleted;
            int rowAffected = db.SaveChanges();

            return rowAffected;
        }
        public List<GeneralCategory> GetAll()
        {
            return db.GeneralCategories.ToList();
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
