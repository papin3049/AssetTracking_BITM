using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.DAL;
using AssetTracking.Model;

namespace AssetTracking.BLL
{
  public  class BaseCategoryManager
    {
        private GeneralCategoryRepository _generalCategoryRepository;
        private CategoryRepository _categoryRepository;
        private SubCategoryRepository _subCategoryRepository;

        public BaseCategoryManager()
        {
            _generalCategoryRepository = new GeneralCategoryRepository();
            _categoryRepository = new CategoryRepository();
            _subCategoryRepository = new SubCategoryRepository();
        }
        public bool Save(SubCategory subCategory)
        {
            int rowAffected = _subCategoryRepository.Save(subCategory);

            bool isSaved = rowAffected > 0;

            return isSaved;
        }

        public bool Update(SubCategory subCategory)
        {
            int rowAffected = _subCategoryRepository.Edit(subCategory);
            bool isSaved = rowAffected > 0;

            return isSaved;
        }

        public bool Delete(SubCategory subCategory)
        {
            int rowAffected = _subCategoryRepository.Delete(subCategory);

            bool isSaved = rowAffected > 0;

            return isSaved;
        }
        public List<AssetTracking.Model.GeneralCategory> GetAllGeneralCategories()
        {
            return _generalCategoryRepository.GetAll();
        }

        public List<AssetTracking.Model.Category> GetCategoriesByGeneralCategory(int generalCategoryId)
        {
            return _categoryRepository.GetCategoriesByGeneralCategory(generalCategoryId);
        }
    }
}
