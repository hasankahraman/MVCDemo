using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BussinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAllInbox(string email);
        List<Message> GetAllSentbox(string email);
        void Add(Message message);
        void Delete(Message message);
        Message GetById(int id);
        void Update(Message message);
    }
}
