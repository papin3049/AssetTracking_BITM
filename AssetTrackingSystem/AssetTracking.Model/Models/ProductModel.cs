using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssetTracking.Model
{
    public class ProductModel
    {
        public int id { get; set; }
        public string modelName { get; set; }
        public string modelDetails { get; set; }
        public int subCategoryId { get; set; }
        [ForeignKey("subCategoryId")]
        public virtual SubCategory subCategory { get; set; }
    }
}