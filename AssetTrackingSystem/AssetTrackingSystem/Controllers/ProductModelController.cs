using AssetTracking.BLL;
using AssetTracking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetTrackingSystem.Controllers
{
    public class ProductModelController : Controller
    {
        AssetTrackingSystemDBContext db = new AssetTrackingSystemDBContext();
        List<SelectListItem> generalCategoriesSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "Select..."}
            };
        private ProdeuctModelManager productModelManager;

        public ProductModelController()
        {
            productModelManager = new ProdeuctModelManager();
        }
        // GET: AssetLocation
        public ActionResult Create()
        {
            ProductModelCreateVM modeVm = new ProductModelCreateVM();



            var generalCategories = productModelManager.GetAllGeneralCategories();
            var categories = productModelManager.GetCategoriesByGeneralCategory();
            var subCategories = productModelManager.GetSubCategoriesByCategory();

            foreach (var generalCategory in generalCategories)
            {
                SelectListItem item = new SelectListItem() { Value = generalCategory.id.ToString(), Text = generalCategory.Name };

                generalCategoriesSelectListItems.Add(item);
            }
            modeVm.GeneralCategories = generalCategoriesSelectListItems;
            return View(modeVm);
        }



        [HttpPost]
        public ViewResult Create(ProductModelCreateVM productModelVM)
        {
            var productModel = new ProductModelCreateVM();
            productModel = productModelVM;

            bool isSaved = productModelManager.Save(productModel.singleModel);
            if (isSaved)
            {
                ViewBag.Message = "Saved Successfully!";
            }
            productModel.GeneralCategories = generalCategoriesSelectListItems;
            //productModel.SubCategories = sub
            return View(productModelVM);
        }
        public PartialViewResult SearchSubCategory(string keyword)
        {
            var vm = new SubCategoryCreateVM();

            var searchlist = db.SubCategories.Where(x => x.SubCategoryName.Contains(keyword)).ToList();

            vm.SubCategories = searchlist;

            return PartialView("SearchSubCategory", vm);


        }
        [HttpPost]
        public ActionResult Edit(SubCategory subCategory)
        {

            bool isSaved = baseCategoryManager.Update(subCategory);


            if (isSaved)
            {
                ViewBag.Message = "Updated Successfully!";

            }
            return RedirectToAction("Create");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var existingsubCategory = db.SubCategories.SingleOrDefault(c => c.id == id);

            if (existingsubCategory == null)
            {
                return HttpNotFound();
            }
            return View(existingsubCategory);
        }
        [HttpPost]
        public ActionResult Delete(SubCategory subCategory)
        {


            bool isSaved = baseCategoryManager.Delete(subCategory);


            if (isSaved)
            {
                ViewBag.Message = "Deleted Successfully!";

            }
            return RedirectToAction("Create");

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var existingsubCategory = db.SubCategories.SingleOrDefault(c => c.id == id);

            if (existingsubCategory == null)
            {
                return HttpNotFound();
            }
            return View(existingsubCategory);
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