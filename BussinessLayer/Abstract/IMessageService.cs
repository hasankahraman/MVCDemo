using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BussinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAllInbox();
        List<Message> GetAllSentbox();
        void Add(Message message);
        void Delete(Message message);
        Message GetById(int id);
        void Update(Message message);
    }
}
