using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetTracking.Model
{
    public class OrganizationBranchCreateVM
    {
        public Branch Branch { get; set; }
        public List<Branch> Branches { get; set; } 
        public List<SelectListItem> OrganizationList { get; set; }
    }
}