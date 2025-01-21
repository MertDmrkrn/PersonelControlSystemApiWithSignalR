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
    public class ShiftManager:IShiftService
    {
        private readonly IShiftDal _shiftDal;

        public ShiftManager(IShiftDal shiftDal)
        {
            _shiftDal = shiftDal;
        }

        public void TAdd(Shift entity)
        {
            _shiftDal.Add(entity);
        }

        public void TDelete(Shift entity)
        {
            _shiftDal.Delete(entity);
        }

        public Shift TGetByID(int id)
        {
            return _shiftDal.GetByID(id);
        }

        public List<Shift> TGetListAll()
        {
            return _shiftDal.GetListAll();
        }

        public void TUpdate(Shift entity)
        {
            _shiftDal.Update(entity);
        }
    }
}
