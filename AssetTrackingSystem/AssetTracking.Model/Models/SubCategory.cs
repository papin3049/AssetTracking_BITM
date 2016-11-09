using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssetTracking.Model
{
    public class SubCategory
    {
        public int id { get; set; }


        public string SubCategoryName { get; set; }

        [DisplayName("Sub Category/Brand")]
        public string SubCategoryCode { get; set; }

        public string Description { get; set; }
        public int CategoryId { get; set; }


        public virtual GeneralCategory GeneralCategory { get; set; }

        
        public virtual Category Category { get; set; }
    }
}