using Cimeri.Domain.DomainModels;
using Cimeri.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimeri.Repository.Implementation
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CityRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<City> GetAll()
        {
            return _dbContext.City.ToList();
        }

        public City getCityById(int cityId)
        {
            return _dbContext.City.FirstOrDefault(c => c.CityID == cityId);
        }
    }
}
