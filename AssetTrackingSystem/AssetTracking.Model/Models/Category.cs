using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssetTracking.Model
{
    public class Category
    {

        public int id { get; set; }

        public string CategoryName { get; set; }

        [Required]
        
        [StringLength(3, ErrorMessage = "The Field Short Name must be 3 character long")]
        public string CategoryCode { get; set; }

        public virtual GeneralCategory GeneralCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; }


    }
}