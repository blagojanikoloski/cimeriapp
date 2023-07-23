using Cimeri.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimeri.Service.Interface
{
    public interface ICityService
    {
        List<City> getAll();

        City getCityById(int cityId);
    }
}
