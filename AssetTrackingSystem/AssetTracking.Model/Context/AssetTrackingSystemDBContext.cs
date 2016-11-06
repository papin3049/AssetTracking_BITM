using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AssetTracking.Model;


namespace AssetTracking.Model
{
    public class AssetTrackingSystemDBContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<GeneralCategory> GeneralCategories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AssetLocation> AssetLocations { get; set; }
    }
}