using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AssetTracking.Model;

namespace AssetTracking.Model
{
   public class AssetLocationCreateVM
    {
        public List<SelectListItem> Organizations{ get; set; }
        public List<SelectListItem> Branches{ get; set; }
        public List<AssetLocation> AssetLocations { get; set; }
        public AssetLocation AssetLocation { get; set; }

    }
}
