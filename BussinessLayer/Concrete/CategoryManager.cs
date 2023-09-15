using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BussinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> genericRepository = new GenericRepository<Category>();

        public List<Category> GetAll()
        {
            return genericRepository.Get();
        }

        public void AddCategory(Category category)
        {
                genericRepository.Insert(category);
        }




    }
}
