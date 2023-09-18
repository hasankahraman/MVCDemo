using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BussinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDAL _writerDAL;

        public WriterManager(IWriterDAL writerDAL)
        {
            _writerDAL = writerDAL;
        }

        public void Add(Writer writer)
        {
            _writerDAL.Insert(writer);
        }

        public void Delete(Writer writer)
        {
            _writerDAL.Delete(writer);
        }

        public List<Writer> GetAll()
        {
            return _writerDAL.Get();
        }

        public Writer GetById(int id)
        {
            return _writerDAL.GetByFilter(x=> x.Id == id);
        }

        public void Update(Writer writer)
        {
            _writerDAL.Update(writer);
        }
    }
}
