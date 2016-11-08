using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssetTracking.Model
{
    public class GeneralCategory
    {
        public int id { get; set; }
        

        public string Name { get; set; }

      

        [Required]
        
        [StringLength(2, ErrorMessage = "The Field Short Name must be 2 character long")]
        public string Code { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }

        public ICollection<Category> Categories { get; set; }

    }
}