using AssetTracking.BLL;
using AssetTracking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AssetTrackingSystem.Controllers
{
    public class CategoryController : Controller
    {
        AssetTrackingSystemDBContext db = new AssetTrackingSystemDBContext();
        private CategoryManager categoryManager;

        public CategoryController()
        {
            categoryManager = new CategoryManager();
        }
        // GET: Category
        public ActionResult Create()
        {
            var generalCategoryListItems = GetGeneralCategorySelectListItems();
            var categoryVm = new CategoryCreateVM();

            categoryVm.GeneralCategoryList = generalCategoryListItems;
            return View(categoryVm);
        }
        [HttpPost]
        public ViewResult Create(CategoryCreateVM categoryCreateVm)
        {
            var category = new CategoryCreateVM();
            category = categoryCreateVm;

            bool isSaved = categoryManager.Save(category.Category);
            
                if (isSaved)
                {
                    ViewBag.Message = "Saved Successfully!";
                }
            category.GeneralCategoryList = GetGeneralCategorySelectListItems();
            


            return View(category);
        }
        public PartialViewResult SearchCategory(string keyword)
        {
            var vm = new CategoryCreateVM();

            var searchlist = db.Categories.Where(x => x.CategoryName.Contains(keyword)).ToList();

            vm.Categories = searchlist;

            return PartialView("SearchCategory", vm);


        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {

            bool isSaved =categoryManager.Update(category);


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

            var existingcategory = db.Categories.SingleOrDefault(c => c.id == id);

            if (existingcategory == null)
            {
                return HttpNotFound();
            }
            return View(existingcategory);
        }
        [HttpPost]
        public ActionResult Delete(Category selectedCategory)
        {
            

            bool isSaved = categoryManager.Delete(selectedCategory);


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

            var existingCategory = db.Categories.SingleOrDefault(c => c.id == id);

            if (existingCategory == null)
            {
                return HttpNotFound();
            }
            return View(existingCategory);
        }

        public List<SelectListItem> GetGeneralCategorySelectListItems()
        {
            var genralcategories = db.GeneralCategories.ToList();
            List<SelectListItem> generalCategorySelectListItems = new List<SelectListItem>();
            generalCategorySelectListItems.Add(new SelectListItem() { Value = "", Text = "Select..." });

            foreach (var generalcategory in genralcategories)
            {
                generalCategorySelectListItems.Add(new SelectListItem()
                {
                    Value = generalcategory.id.ToString(),
                    Text = generalcategory.Name
                });
            }
            return generalCategorySelectListItems;
        }
    }
}