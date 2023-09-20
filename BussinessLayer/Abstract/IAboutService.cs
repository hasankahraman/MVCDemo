using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetAll();
        void Add(About about);
        void Delete(About about);
        About GetById(int id);
        void Update(About about);
    }
}
