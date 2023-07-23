using Cimeri.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimeri.Repository.Interface
{
    public interface ICimeriPostRepository
    {
        List<CimeriPost> GetCimeriPostsByUserId(string userId);
        CimeriPost GetById(int id);

        List<CimeriPost> GetAll();

        int GetLargestCimeriPostID();
    }
}
