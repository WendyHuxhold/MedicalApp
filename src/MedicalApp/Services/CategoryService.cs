using MedicalApp.Infrastructure;
using MedicalApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.Services
{
    public class CategoryService
    {
        private CategoryRepository _catRepo;

        public CategoryService(CategoryRepository catRepo)
        {
            _catRepo = catRepo;
        }


        //return (from c in _db.Categories
        //        select c.CatType).ToList();
        public IList<CategoryDTO> GetCategoryList()
        {
            return (from c in _catRepo.List()
                    select new CategoryDTO()
                    {
                        CatType = c.CatType
                    }).ToList();
        }
    }
}
