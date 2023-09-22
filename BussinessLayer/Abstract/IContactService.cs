using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetAll();
        void Add(Contact contact);
        void Delete(Contact contact);
        Contact GetById(int id);
        void Update(Contact contact);
    }
}
