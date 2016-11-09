using AssetTracking.DAL;
using AssetTracking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetTracking.BLL
{
    public class ProdeuctModelManager
    {
        private GeneralCategoryRepository _generalCategoryRepository;
        private CategoryRepository _categoryRepository;
        private SubCategoryRepository _subCategoryRepository;
        private ProductModelRepository _productModelRepository;

        public ProdeuctModelManager()
        {
            _generalCategoryRepository = new GeneralCategoryRepository();
            _categoryRepository = new CategoryRepository();
            _subCategoryRepository = new SubCategoryRepository();
            _productModelRepository = new ProductModelRepository();
        }
        public bool Save(ProductModel productModel)
        {
            int rowAffected = _productModelRepository.Save(productModel);

            bool isSaved = rowAffected > 0;

            return isSaved;
        }

        public bool Update(ProductModel productModel)
        {
            int rowAffected = _productModelRepository.Edit(productModel);
            bool isSaved = rowAffected > 0;

            return isSaved;
        }

        public bool Delete(ProductModel productModel)
        {
            int rowAffected = _productModelRepository.Delete(productModel);

            bool isSaved = rowAffected > 0;

            return isSaved;
        }
        public List<GeneralCategory> GetAllGeneralCategories()
        {
            return _generalCategoryRepository.GetAll();
        }

        public List<Category> GetCategoriesByGeneralCategory(int generalCategoryId)
        {
            return _categoryRepository.GetCategoriesByGeneralCategory(generalCategoryId);
        }

        public List<SubCategory> GetSubCategoriesByCategory(int categoryId)
        {
            return _subCategoryRepository.GetSubCategoriesByCategory(categoryId);
        }

    }
}