using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTracking.Model;
using AssetTracking.BLL;

namespace AssetTrackingSystem.Controllers
{
    public class OrganizationBranchController : Controller
    {
        AssetTrackingSystemDBContext db = new AssetTrackingSystemDBContext();

        private BranchManager branchManager;

        public OrganizationBranchController()
        {
            branchManager = new BranchManager();
        }
        // GET: Branch
        public ActionResult Create()
        {
           // var organizationBranch = db.Branches.SingleOrDefault(m => m.id == 1);


            var organizationSelectListItems = GetOrganizationSelectListItems();

            var organizationBranchVm = new OrganizationBranchCreateVM();




            organizationBranchVm.OrganizationList = organizationSelectListItems;


            return View(organizationBranchVm);
        }
        [HttpPost]
        public ViewResult Create(OrganizationBranchCreateVM branchCreateVm)
        {
            var branch = new OrganizationBranchCreateVM();
            branch = branchCreateVm;
            if (ModelState.IsValid)
            {

                bool isSaved = branchManager.Save(branch.Branch);

                if (isSaved)
                {
                    ViewBag.Message = "Saved Successfully!";
                }
            }
           // branch.Branches = db.Branches.OrderByDescending(x => x.id).ToList();
            branch.OrganizationList = GetOrganizationSelectListItems();
            return View(branch);
        }


        public PartialViewResult SearchBranch(string keyword)
        {
            var vm = new OrganizationBranchCreateVM();

            var searchlist = db.Branches.Where(x => x.BranchName.Contains(keyword)).ToList();

            vm.Branches = searchlist;

            return PartialView("SearchBranch",vm);


        }
        [HttpPost]
        public ActionResult Edit(Branch branch)
        {

            bool isSaved = branchManager.Update(branch);


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

            var existingbranch = db.Branches.SingleOrDefault(c => c.id == id);

            if (existingbranch == null)
            {
                return HttpNotFound();
            }
            return View(existingbranch);
        }
        [HttpPost]
        public ActionResult Delete(Branch selectedbBranch)
        {
            // var singleOrganization = db.Organizations.FirstOrDefault(x=>x.id == selectedOrganization.id);
            //db.Organizations.Remove(singleOrganization);
            //db.Entry(selectedOrganization).State = EntityState.Deleted;
            //int rowAffected = db.SaveChanges();

            bool isSaved = branchManager.Delete(selectedbBranch);


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

            var existingBranch = db.Branches.SingleOrDefault(c => c.id == id);

            if (existingBranch == null)
            {
                return HttpNotFound();
            }
            return View(existingBranch);
        }


        private List<SelectListItem> GetOrganizationSelectListItems()
        {
            var organizations = db.Organizations.ToList();
            List<SelectListItem> organizationSelectListItems = new List<SelectListItem>();
            organizationSelectListItems.Add(new SelectListItem() { Value = "", Text = "Select..." });

            foreach (var organization in organizations)
            {
                organizationSelectListItems.Add(new SelectListItem()
                {
                    Value = organization.id.ToString(),
                    Text = organization.Name
                });
            }
            return organizationSelectListItems;
        }


    }
}