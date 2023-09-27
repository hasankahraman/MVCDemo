using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> GetAll();
        void Add(ImageFile imageFile);
        void Delete(ImageFile imageFile);
        ImageFile GetById(int id);
        void Update(ImageFile imageFile);
    }
}
