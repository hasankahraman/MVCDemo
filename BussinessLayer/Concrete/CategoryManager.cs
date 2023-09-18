using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BussinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categoryDAL;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public void Add(Category category)
        {
            _categoryDAL.Insert(category);
        }

        public void Delete(Category category)
        {
            _categoryDAL.Delete(category);
        }

        public List<Category> GetAll()
        {
            return _categoryDAL.Get();
        }

        public Category GetById(int id)
        {
            return _categoryDAL.GetByFilter(x=> x.Id == id);
        }

        public void Update(Category category)
        {
            _categoryDAL.Update(category);
        }
    }
}
