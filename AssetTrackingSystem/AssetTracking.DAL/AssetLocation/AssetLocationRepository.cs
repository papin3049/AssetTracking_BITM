using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.Model;

namespace AssetTracking.DAL
{
   public class AssetLocationRepository :IDisposable
    {

        private AssetTrackingSystemDBContext db;

        public AssetLocationRepository()
        {
            db = new AssetTrackingSystemDBContext();

        }
        public int Save(AssetLocation assetLocation)
        {
            db.AssetLocations.Add(assetLocation);

            int rowAffected = db.SaveChanges();

            return rowAffected;

        }

        public int Edit(AssetLocation assetLocation)
        {
            db.AssetLocations.Attach(assetLocation);
            db.Entry(assetLocation).State = EntityState.Modified;
            int rowAffected = db.SaveChanges();

            return rowAffected;
        }

        public int Delete(AssetLocation assetLocation)
        {
            var singleAssetLocation = db.AssetLocations.FirstOrDefault(x => x.id == assetLocation.id);
            db.AssetLocations.Remove(singleAssetLocation);
            db.Entry(singleAssetLocation).State = EntityState.Deleted;
            int rowAffected = db.SaveChanges();

            return rowAffected;
        }
        public List<AssetLocation> GetAll()
        {
            return db.AssetLocations.ToList();
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

