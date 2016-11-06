using AssetTracking.DAL;
using AssetTracking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AssetTracking.BLL
{
    public class BranchManager
    {

        private BranchRepository branchRepository;

        public BranchManager()
        {
            branchRepository = new BranchRepository();
        }

        public bool Save(Branch branch)
        {
            int rowAffected = branchRepository.Save(branch);

            bool isSaved = rowAffected > 0;

            return isSaved;

        }
        public bool Update(Branch branch)
        {
            int rowAffected = branchRepository.Edit(branch);
            bool isSaved = rowAffected > 0;

            return isSaved;
        }

        public bool Delete(Branch branch)
        {
            int rowAffected = branchRepository.Delete(branch);

            bool isSaved = rowAffected > 0;

            return isSaved;
        }

    }
}
