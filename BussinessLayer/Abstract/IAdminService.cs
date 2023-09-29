using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetAll();
        void Add(Admin admin);
        void Delete(Admin admin);
        Admin GetById(int id);
        void Update(Admin admin);
        Admin Login(Admin admin);
        String GetAdminRoles(string username);

    }
}
