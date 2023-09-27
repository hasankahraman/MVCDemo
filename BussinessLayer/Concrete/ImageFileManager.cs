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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDAL _imageFile;

        public ImageFileManager(IImageFileDAL imageFile)
        {
            _imageFile = imageFile;
        }

        public void Add(ImageFile imageFile)
        {
            _imageFile.Insert(imageFile);
        }

        public void Delete(ImageFile imageFile)
        {
            _imageFile.Delete(imageFile);
        }

        public List<ImageFile> GetAll()
        {
            return _imageFile.Get();
        }

        public ImageFile GetById(int id)
        {
            return _imageFile.GetByFilter(x => x.Id == id);
        }

        public void Update(ImageFile imageFile)
        {
            _imageFile.Update(imageFile);
        }
    }
}
