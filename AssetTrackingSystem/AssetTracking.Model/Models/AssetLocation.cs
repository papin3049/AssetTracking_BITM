using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.Model;

namespace AssetTracking.Model
{
   public class AssetLocation
    {
        public int id { get; set; }


        public string Name { get; set; }

        
        public string ShortName { get; set; }

        



        public int BranchId { get; set; }

        public virtual Branch Branch { get; set; }


        public virtual Organization Organization{ get; set; }
    }
}

