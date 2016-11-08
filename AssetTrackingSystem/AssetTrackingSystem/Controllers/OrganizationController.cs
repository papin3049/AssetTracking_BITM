using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTracking.BLL;
using System.Web.UI.WebControls;
using AssetTracking.Model;

namespace AssetTrackingSystem.Controllers
{
    public class OrganizationController : Controller
    {
        AssetTrackingSystemDBContext db = new AssetTrackingSystemDBContext();
        const int RecordsPerPage = 2;

        private OrganizationManager organizationManager;

        public OrganizationController()
        {
            organizationManager = new OrganizationManager();
        }
        // GET: Organization
        public ActionResult Create(int? page)
        {
            
            var organizationList = db.Organizations.ToList();
            var pager = new Pager(organizationList.Count(), page);

            var organization = new OrganizationCreateVM
            {
                Organization = new Organization(),
                Organizations = organizationList.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };


            return View(organization);
        }
        [HttpPost]
        public ViewResult Create(OrganizationCreateVM organizationVm)
        {
            

            var organization = new OrganizationCreateVM();
            organization = organizationVm;
            if (ModelState.IsValid)
            {

                bool isSaved = organizationManager.Save(organization.Organization);

                if (isSaved)
                {
                    ViewBag.Message = "Saved Successfully!";
                }
            }
            organization.Organizations = db.Organizations.OrderByDescending(x=>x.id).ToList();
            return View(organization);
        }


        [HttpPost]
        public ActionResult Edit(Organization organization)
        {

            bool isSaved = organizationManager.Update(organization);


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

            var existingOrganization = db.Organizations.SingleOrDefault(c => c.id == id);

            if (existingOrganization == null)
            {
                return HttpNotFound();
            }
            return View(existingOrganization);
        }
        [HttpPost]
        public ActionResult Delete(Organization selectedOrganization)
        {
          

            bool isSaved = organizationManager.Delete(selectedOrganization);


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

            var existingOrganization = db.Organizations.SingleOrDefault(c => c.id == id);

            if (existingOrganization == null)
            {
                return HttpNotFound();
            }
            return View(existingOrganization);
        }

        public PartialViewResult SearchOrganization(String keyword, int? page)

        {


            var searchlist = db.Organizations.Where(x => x.Name.Contains(keyword)).ToList();
            var pager = new Pager(searchlist.Count(), page);

            var organization = new OrganizationCreateVM
            {
                Organization = new Organization(),
                Organizations = searchlist.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            //organization.Organizations = searchlist;
            return PartialView(organization);
        }
    }
}