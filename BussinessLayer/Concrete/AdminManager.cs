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
    public class AdminManager : IAdminService
    {
        IAdminDAL _adminDAL;

        public AdminManager(IAdminDAL adminDAL)
        {
            _adminDAL = adminDAL;
        }

        public void Add(Admin admin)
        {
            _adminDAL.Insert(admin);
        }

        public void Delete(Admin admin)
        {
            _adminDAL.Delete(admin);
        }

        public string GetAdminRoles(string username)
        {
            return _adminDAL.GetByFilter(x => x.Username == username).Role.ToString();
        }

        public List<Admin> GetAll()
        {
            return _adminDAL.Get();
        }

        public Admin GetById(int id)
        {
            return _adminDAL.GetByFilter(x => x.Id == id);
        }

        public Admin Login(Admin admin)
        {
            return _adminDAL.GetByFilter(x => x.Username == admin.Username && x.Password == admin.Password);
        }

        public void Update(Admin admin)
        {
            _adminDAL.Update(admin);
        }
    }
}
