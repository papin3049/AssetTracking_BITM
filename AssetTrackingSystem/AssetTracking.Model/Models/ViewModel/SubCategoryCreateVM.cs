using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AssetTracking.Model;

namespace AssetTracking.Model
{
    public class SubCategoryCreateVM
    {
        public List<SelectListItem> GeneralCategories { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public IEnumerable<SubCategory> Subcategories { get; set; }
        public SubCategory SubCategory { get; set; }

    }
}
