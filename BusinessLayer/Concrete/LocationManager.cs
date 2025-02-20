﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LocationManager : ILocationService
    {
        private readonly ILocationDal _locationDal;

        public LocationManager(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }

        public void TAdd(Location entity)
        {
            _locationDal.Add(entity);
        }

        public void TDelete(Location entity)
        {
            _locationDal.Delete(entity);
        }

        public Location TGetByID(int id)
        {
            return _locationDal.GetByID(id);
        }

        public List<Location> TGetListAll()
        {
            return _locationDal.GetListAll();
        }

        public void TUpdate(Location entity)
        {
            _locationDal.Update(entity);
        }
    }
}
