using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AssetTracking.BLL;
using AssetTracking.Model;

namespace AssetTrackingSystem.Controllers
{
    public class AssetLocationController : Controller
    {
        // GET: AssetLocation
        AssetTrackingSystemDBContext db = new AssetTrackingSystemDBContext();
        List<SelectListItem> organizationsSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "Select..."}
            };
        private AssetLocationManager assetLocationManager;

        public AssetLocationController()
        {
            assetLocationManager = new AssetLocationManager();
        }
        // GET: AssetLocation
        public ActionResult Create()
        {
            AssetLocationCreateVM modeVm = new AssetLocationCreateVM();



            var organizations = assetLocationManager.GetAllGeneralOrganizations();


            foreach (var organization in organizations)
            {
                SelectListItem item = new SelectListItem() { Value = organization.id.ToString(), Text = organization.Name };

                organizationsSelectListItems.Add(item);
            }
            modeVm.Organizations = organizationsSelectListItems;
            return View(modeVm);
        }



        [HttpPost]
        public ViewResult Create(AssetLocationCreateVM assetLocationVm)
        {
            var assetLocation = new AssetLocationCreateVM();
            assetLocation = assetLocationVm;

            bool isSaved = assetLocationManager.Save(assetLocation.AssetLocation);
            if (isSaved)
            {
                ViewBag.Message = "Saved Successfully!";
            }
            assetLocation.Organizations = organizationsSelectListItems;
            return View(assetLocation);
        }
        public PartialViewResult SearchAssetLocation(string keyword)
        {
            var vm = new AssetLocationCreateVM();

            var searchlist = db.AssetLocations.Where(x => x.Name.Contains(keyword)).ToList();

            vm.AssetLocations = searchlist;

            return PartialView("SearchAssetLocation", vm);


        }
        [HttpPost]
        public ActionResult Edit(AssetLocation assetLocation)
        {

            bool isSaved = assetLocationManager.Update(assetLocation);


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

            var existingassetLocation = db.AssetLocations.SingleOrDefault(c => c.id == id);

            if (existingassetLocation == null)
            {
                return HttpNotFound();
            }
            return View(existingassetLocation);
        }
        [HttpPost]
        public ActionResult Delete(AssetLocation assetLocation)
        {


            bool isSaved = assetLocationManager.Delete(assetLocation);


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

            var existingassetLocation = db.AssetLocations.SingleOrDefault(c => c.id == id);

            if (existingassetLocation == null)
            {
                return HttpNotFound();
            }
            return View(existingassetLocation);
        }
        public JsonResult GetBranchesByOrganization(int organizationId)
        {

            var organizations = assetLocationManager
                .GetBranchByOrganization(organizationId)
                .Select(c => new { Id = c.id, Name = c.BranchName });

            return Json(organizations, JsonRequestBehavior.AllowGet);
        }


    }
}