using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAll();
        void Add(Message message);
        void Delete(Message message);
        Message GetById(int id);
        void Update(Message message);
    }
}
