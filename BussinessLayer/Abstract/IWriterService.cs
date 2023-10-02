using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetAll();
        void Add(Writer writer);
        void Delete(Writer writer);
        Writer GetById(int id);
        void Update(Writer writer);
        Writer Login(Writer writer);
        int GetWriterIdByEmail(string email);
    }
}
