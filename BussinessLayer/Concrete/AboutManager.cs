using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDAL _aboutDAL;

        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }

        public void Add(About about)
        {
            _aboutDAL.Insert(about);
        }

        public void Delete(About about)
        {
            _aboutDAL.Delete(about);
        }

        public List<About> GetAll()
        {
            return _aboutDAL.Get().Where(x=> x.Status == true).ToList();
        }

        public About GetById(int id)
        {
            return _aboutDAL.GetByFilter(x => x.Id == id);
        }

        public void Update(About about)
        {
            _aboutDAL.Update(about);
        }
    }
}
