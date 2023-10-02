using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetAll();
        void Add(Content content);
        void Delete(Content content);
        Content GetById(int id);
        void Update(Content content);
        List<Content> GetContentsByHeading(int headingId);
        List<Content> GetContentsByWriter(int id);
    }
}
