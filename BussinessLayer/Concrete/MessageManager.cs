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
    public class MessageManager : IMessageService
    {
        IMessageDAL _messageDAL;

        public MessageManager(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }

        public void Add(Message message)
        {
            _messageDAL.Insert(message);
        }

        public void Delete(Message message)
        {
            _messageDAL.Delete(message);
        }

        public List<Message> GetAllInbox()
        {
            return _messageDAL.Get().Where(x => x.Status == true).Where(x=> x.ReceiverMail == "admin@gmail.com").ToList();
        }

        public List<Message> GetAllSentbox()
        {
            return _messageDAL.Get().Where(x => x.SenderMail == "admin@gmail.com").Where(x => x.Status == true).ToList();
        }

        public Message GetById(int id)
        {
            return _messageDAL.GetByFilter(x => x.Id == id);
        }

        public void Update(Message message)
        {
            _messageDAL.Update(message);
        }
    }
}
