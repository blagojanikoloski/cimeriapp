
using Cimeri.Domain.DomainModels;
using Cimeri.Repository.Interface;
using Cimeri.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimeri.Service.Implementation
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public List<City> getAll()
        {
            return _cityRepository.GetAll();
        }

        public City getCityById(int cityId)
        {
            return _cityRepository.getCityById(cityId);
        }
    }
}
