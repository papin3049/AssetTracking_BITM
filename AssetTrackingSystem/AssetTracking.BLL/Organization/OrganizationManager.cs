using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssetTracking.DAL;
using AssetTracking.Model;

namespace AssetTracking.BLL
{
    public class OrganizationManager
    {
        private OrganizationRepository organizationRepository;

        public OrganizationManager()
        {
            organizationRepository =new OrganizationRepository();
        }

        public bool Save(Organization organization)
        {
            int rowAffected = organizationRepository.Save(organization);

            bool isSaved = rowAffected > 0;

            return isSaved;
        }

        public bool Update(Organization organization)
        {
            int rowAffected = organizationRepository.Edit(organization);
            bool isSaved = rowAffected > 0;

            return isSaved;
        }

        public bool Delete(Organization organization)
        {
            int rowAffected = organizationRepository.Delete(organization);

            bool isSaved = rowAffected > 0;

            return isSaved;
        }

    }
}