using AssetTracking.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AssetTracking.DAL
{
    public class ProductModelRepository : IDisposable
    {


        private AssetTrackingSystemDBContext db;

        public ProductModelRepository()
        {
            db = new AssetTrackingSystemDBContext();

        }
        public int Save(ProductModel productModel)
        {
            db.ProductModels.Add(productModel);

            int rowAffected = db.SaveChanges();

            return rowAffected;

        }

        public int Edit(ProductModel productModel)
        {
            db.ProductModels.Attach(productModel);
            db.Entry(productModel).State = EntityState.Modified;
            int rowAffected = db.SaveChanges();

            return rowAffected;
        }

        public int Delete(ProductModel ProductModel)
        {
            var singleProductModel = db.ProductModels.FirstOrDefault(x => x.id == ProductModel.id);
            db.ProductModels.Remove(singleProductModel);
            db.Entry(singleProductModel).State = EntityState.Deleted;
            int rowAffected = db.SaveChanges();

            return rowAffected;
        }
        public List<ProductModel> GetAll()
        {
            return db.ProductModels.ToList();
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