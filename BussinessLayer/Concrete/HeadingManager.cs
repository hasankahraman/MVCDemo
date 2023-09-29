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
    public class HeadingManager : IHeadingService
    {
        IHeadingDAL _headingDAL;

        public HeadingManager(IHeadingDAL headingDAL)
        {
            _headingDAL = headingDAL;
        }

        public void Add(Heading heading)
        {
            _headingDAL.Insert(heading);
        }

        public void Delete(Heading heading)
        {
            _headingDAL.Update(heading);
        }

        public List<Heading> GetAll()
        {
            return _headingDAL.Get().Where(x=> x.Status == true).ToList();
        }

        public List<Heading> GetAllByWriter(int writerId)
        {
            return _headingDAL.Get().Where(x => x.Status == true).Where(x=> x.WriterId == writerId).ToList();
        }

        public Heading GetById(int id)
        {
            return _headingDAL.GetByFilter(x => x.Id == id);
        }

        public void Update(Heading heading)
        {
            _headingDAL.Update(heading);
        }
    }
}
