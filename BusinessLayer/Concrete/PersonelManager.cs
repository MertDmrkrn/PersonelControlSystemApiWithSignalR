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
    public class PersonelManager : IPersonelService
    {
        private readonly IPersonelDal _personelDal;

        public PersonelManager(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }

        public void TAdd(Personel entity)
        {
            _personelDal.Add(entity);
        }

        public void TDelete(Personel entity)
        {
            _personelDal.Delete(entity);
        }

        public Personel TGetByID(int id)
        {
            return _personelDal.GetByID(id);
        }

        public List<Personel> TGetListAll()
        {
            return _personelDal.GetListAll();
        }

        public void TUpdate(Personel entity)
        {
            _personelDal.Update(entity);
        }
    }
}
