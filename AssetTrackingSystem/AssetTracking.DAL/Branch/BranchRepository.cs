using AssetTracking.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AssetTracking.DAL
{ 
   public class BranchRepository :IDisposable
   {
       private AssetTrackingSystemDBContext db;

       public BranchRepository()
       {
           db = new AssetTrackingSystemDBContext();
       }

       public int Save(Branch branch)
       {
           db.Branches.Add(branch);
           int rowAffected = db.SaveChanges();
           return rowAffected;

       }
        public int Edit(Branch branch)
        {
            db.Branches.Attach(branch);
            db.Entry(branch).State = EntityState.Modified;
            int rowAffected = db.SaveChanges();

            return rowAffected;
        }

        public int Delete(Branch branch)
        {
            var singlebranch = db.Branches.FirstOrDefault(x => x.id == branch.id);
            db.Branches.Remove(singlebranch);
            db.Entry(singlebranch).State = EntityState.Deleted;
            int rowAffected = db.SaveChanges();

            return rowAffected;
        }
        public List<Branch> GetBranchByOrganization(int organizationId)
        {
            return db.Branches.Where(x => x.Organization.id == organizationId).ToList();
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
