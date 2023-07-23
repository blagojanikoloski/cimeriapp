using Cimeri.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimeri.Repository.Interface
{
    public interface ICityRepository
    {
        List<City> GetAll();

        City getCityById(int cityId);
    }
}
