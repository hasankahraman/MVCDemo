using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace BussinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDAL _contactDAL;

        public ContactManager(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }

        public void Add(Contact contact)
        {
            _contactDAL.Insert(contact);
        }

        public void Delete(Contact contact)
        {
            _contactDAL.Delete(contact);
        }

        public List<Contact> GetAll()
        {
            return _contactDAL.Get().Where(x => x.Status == true).ToList();
        }

        public Contact GetById(int id)
        {
            return _contactDAL.GetByFilter(x => x.Id == id);
        }

        public void Update(Contact contact)
        {
            _contactDAL.Update(contact);
        }
    }
}
