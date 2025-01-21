using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfShiftDal : GenericRepository<Shift>, IShiftDal
    {
        public EfShiftDal(Context context) : base(context)
        {
        }
    }
}
