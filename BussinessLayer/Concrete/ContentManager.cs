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
    public class ContentManager : IContentService
    {
        IContentDAL _contentDAL;

        public ContentManager(IContentDAL contentDAL)
        {
            _contentDAL = contentDAL;
        }

        public void Add(Content content)
        {
            _contentDAL.Insert(content);
        }

        public void Delete(Content content)
        {
            _contentDAL.Delete(content);
        }

        public List<Content> GetAll(string param)
        {
            return _contentDAL.Get(x => x.Value.Contains(param));
        }

        public Content GetById(int id)
        {
            return _contentDAL.GetByFilter(x => x.Id == id);
        }

        public void Update(Content content)
        {
            _contentDAL.Update(content);
        }

        public List<Content> GetContentsByHeading(int headingId)
        {
            return _contentDAL.Get(x => x.HeadingId == headingId).OrderByDescending(x=> x.CreatedAt).ToList();
        }

        public List<Content> GetContentsByWriter(int id)
        {
            return _contentDAL.Get(x => x.WriterId == id).OrderByDescending(x => x.CreatedAt).ToList();
        }
    }
}
