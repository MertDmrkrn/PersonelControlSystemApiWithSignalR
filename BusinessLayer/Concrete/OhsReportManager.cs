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
    public class OhsReportManager:IOhsReportService
    {
        private readonly IOhsReportDal _ohsReportDal;

        public OhsReportManager(IOhsReportDal ohsReportDal)
        {
            _ohsReportDal = ohsReportDal;
        }

        public void TAdd(OhsReport entity)
        {
            _ohsReportDal.Add(entity);
        }

        public void TDelete(OhsReport entity)
        {
            _ohsReportDal.Delete(entity);
        }

        public OhsReport TGetByID(int id)
        {
            return _ohsReportDal.GetByID(id);
        }

        public List<OhsReport> TGetListAll()
        {
            return _ohsReportDal.GetListAll();
        }

        public void TUpdate(OhsReport entity)
        {
            _ohsReportDal.Update(entity);
        }
    }
}
