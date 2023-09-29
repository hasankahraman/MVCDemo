using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetAll();
        List<Heading> GetAllByWriter(int writerId);
        void Add(Heading heading);
        void Delete(Heading heading);
        Heading GetById(int id);
        void Update(Heading heading);
    }
}
