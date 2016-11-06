using AssetTracking.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.Model;


namespace AssetTracking.BLL
{ 
   public class GeneralCategoryManager
    {
        private GeneralCategoryRepository generalCategoryRepository;

        public GeneralCategoryManager()
        {
            generalCategoryRepository = new GeneralCategoryRepository();
        }

        public bool Save(GeneralCategory generalCategory)
        {
            int rowAffected = generalCategoryRepository.Save(generalCategory);

            bool isSaved = rowAffected > 0;

            return isSaved;
        }
        public bool Update(GeneralCategory generalCategory)
        {
            int rowAffected = generalCategoryRepository.Edit(generalCategory);
            bool isSaved = rowAffected > 0;

            return isSaved;
        }

        public bool Delete(GeneralCategory generalCategory)
        {
            int rowAffected = generalCategoryRepository.Delete(generalCategory);

            bool isSaved = rowAffected > 0;

            return isSaved;
        }
    }
}
