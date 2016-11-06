using AssetTracking.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace AssetTracking.DAL
{
    public class OrganizationRepository : IDisposable
    {
        private AssetTrackingSystemDBContext db;
        public OrganizationRepository()
        {
            db=new AssetTrackingSystemDBContext();
        }

        public int Save(Organization organization)
        {
            db.Organizations.Add(organization);

            int rowAffected=db.SaveChanges();

            return rowAffected;

        }

        public int Edit(Organization organization)
        {
            db.Organizations.Attach(organization);
            db.Entry(organization).State = EntityState.Modified;
            int rowAffected = db.SaveChanges();

            return rowAffected;
        }

        public int Delete(Organization organization)
        {
            var singleOrganization = db.Organizations.FirstOrDefault(x => x.id == organization.id);
            db.Organizations.Remove(singleOrganization);
            db.Entry(singleOrganization).State = EntityState.Deleted;
            int rowAffected = db.SaveChanges();

            return rowAffected;
        }
        public List<Organization> GetAll()
        {
            return db.Organizations.ToList();
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