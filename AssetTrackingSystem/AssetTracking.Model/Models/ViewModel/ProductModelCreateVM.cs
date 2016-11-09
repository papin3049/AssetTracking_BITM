using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetTracking.Model
{
    public class ProductModelCreateVM
    {
        public ProductModel singleModel { get; set; }

        public List<SelectListItem> GeneralCategories { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> SubCategories { get; set; }

        public IEnumerable<ProductModel> products { get; set; }
    }
}