using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RequestManager:IRequestService
    {
        private readonly IRequestDal _requestDal;

        public RequestManager(IRequestDal requestDal)
        {
            _requestDal = requestDal;
        }

        public void TAdd(Request entity)
        {
            _requestDal.Add(entity);
        }

        public void TDelete(Request entity)
        {
            _requestDal.Delete(entity);
        }

        public Request TGetByID(int id)
        {
            return _requestDal.GetByID(id);
        }

        public List<Request> TGetListAll()
        {
            return _requestDal.GetListAll();
        }

        public void TUpdate(Request entity)
        {
            _requestDal.Update(entity);
        }
    }
}
