using AssetTracking.DAL;
using AssetTracking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AssetTracking.BLL
{
   public class AssetLocationManager
    {
        private OrganizationRepository _organizationRepository;
        private BranchRepository _branchRepository;
        private AssetLocationRepository _assetLocationRepository;

        public AssetLocationManager()
        {
            _organizationRepository = new OrganizationRepository();
            _branchRepository = new BranchRepository();
            _assetLocationRepository = new AssetLocationRepository();
        }
        public bool Save(AssetLocation assetLocation)
        {
            int rowAffected = _assetLocationRepository.Save(assetLocation);

            bool isSaved = rowAffected > 0;

            return isSaved;
        }

        public bool Update(AssetLocation assetLocation)
        {
            int rowAffected = _assetLocationRepository.Edit(assetLocation);
            bool isSaved = rowAffected > 0;

            return isSaved;
        }

        public bool Delete(AssetLocation assetLocation)
        {
            int rowAffected = _assetLocationRepository.Delete(assetLocation);

            bool isSaved = rowAffected > 0;

            return isSaved;
        }
        public List<Organization> GetAllGeneralOrganizations()
        {
            return _organizationRepository.GetAll();
        }

        public List<Branch> GetBranchByOrganization(int organizationId)
        {
            return _branchRepository.GetBranchByOrganization(organizationId);
        }
    }
}

