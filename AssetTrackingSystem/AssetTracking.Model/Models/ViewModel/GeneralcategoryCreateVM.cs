using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.Model;

namespace AssetTracking.Model
{
   public class GeneralcategoryCreateVM
    {
        public GeneralCategory GeneralCategory { get; set; }
        public List<GeneralCategory> GeneralCategories { get; set; } 
    }
}
