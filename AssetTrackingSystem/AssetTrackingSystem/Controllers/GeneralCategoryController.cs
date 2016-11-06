using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTracking.Model;
using AssetTracking.BLL;

namespace AssetTrackingSystem.Controllers
{
    public class GeneralCategoryController : Controller
    {
        AssetTrackingSystemDBContext db = new AssetTrackingSystemDBContext();
        private GeneralCategoryManager generalCategoryManager;

        public GeneralCategoryController()
        {
            generalCategoryManager =new GeneralCategoryManager();
        }
        // GET: GeneralCategory
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ViewResult Create(GeneralcategoryCreateVM generalcategoryCreateVm)
        {
            var generalCategory= new GeneralcategoryCreateVM();
           generalCategory = generalcategoryCreateVm;
            if (ModelState.IsValid)
            {

                bool isSaved = generalCategoryManager.Save(generalCategory.GeneralCategory);

                if (isSaved)
                {
                    ViewBag.Message = "Saved Successfully!";
                }
            }
           
            return View(generalCategory);
           
        }
        [HttpPost]
        public ActionResult Edit(GeneralCategory generalCategory)
        {

            bool isSaved = generalCategoryManager.Update(generalCategory);


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

            var existingGeneralCategory = db.GeneralCategories.SingleOrDefault(c => c.id == id);

            if (existingGeneralCategory == null)
            {
                return HttpNotFound();
            }
            return View(existingGeneralCategory);
        }
        [HttpPost]
        public ActionResult Delete(GeneralCategory generalCategory)
        {
           

            bool isSaved =generalCategoryManager.Delete(generalCategory);


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

            var existinggeneralCategory= db.GeneralCategories.SingleOrDefault(c => c.id == id);

            if (existinggeneralCategory == null)
            {
                return HttpNotFound();
            }
            return View(existinggeneralCategory);
        }
        public PartialViewResult SearchGeneralCategory(String keyword)

        {


            var vm = new GeneralcategoryCreateVM();

            var searchlist = db.GeneralCategories.Where(x => x.Name.Contains(keyword)).ToList();

            vm.GeneralCategories = searchlist;
            return PartialView("SearchGeneralCategory", vm);
        }

    }
}