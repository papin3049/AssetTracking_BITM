using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTracking.Model;
using AssetTracking.BLL;

namespace AssetTrackingSystem.Controllers
{
    public class SubCategoryController : Controller
    {
        private BaseCategoryManager baseCategoryManager;

        public SubCategoryController()
        {
            baseCategoryManager = new BaseCategoryManager();
        }
        // GET: AssetLocation
        public ActionResult Create()
        {
            SubCategoryCreateVM modeVm = new SubCategoryCreateVM();

            var generalCategories = baseCategoryManager.GetAllGeneralCategories();
            List<SelectListItem> generalCategoriesSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "Select..."}
            };

            foreach (var generalCategory in generalCategories)
            {
                SelectListItem item = new SelectListItem() { Value = generalCategory.id.ToString(), Text = generalCategory.Name };

                generalCategoriesSelectListItems.Add(item);
            }
            modeVm.GeneralCategories = generalCategoriesSelectListItems;
            return View(modeVm);
        }
        [HttpPost]
        public ActionResult Create(SubCategory subCategory)
        {
            ViewBag.Message = "Saved Successfully!";
            return View();
        }
        public JsonResult GetCategoriesByGeneralCategory(int generalCategoryId)
        {

            var categories = baseCategoryManager
                .GetCategoriesByGeneralCategory(generalCategoryId)
                .Select(c => new { Id = c.id, Name = c.CategoryName });

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

    }
}