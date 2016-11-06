using AssetTracking.DAL;
using AssetTracking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AssetTracking.BLL
{
   public class CategoryManager
   {
       private CategoryRepository categoryRepository;

       public CategoryManager()
       {
           categoryRepository =new CategoryRepository();
       }

       public bool Save(Category category)
       {
           int rowAffected = categoryRepository.Save(category);

           bool isSaved = rowAffected > 0;
           return isSaved;
       }
        public bool Update(Category category)
        {
            int rowAffected = categoryRepository.Edit(category);
            bool isSaved = rowAffected > 0;

            return isSaved;
        }

        public bool Delete(Category category)
        {
            int rowAffected = categoryRepository.Delete(category);

            bool isSaved = rowAffected > 0;

            return isSaved;
        }

    }
}
