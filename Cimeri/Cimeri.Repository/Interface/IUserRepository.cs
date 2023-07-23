using Cimeri.Domain.DTO;
using Cimeri.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cimeri.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<CimeriApplicationUser> GetAll();
        void Insert(CimeriApplicationUser entity);
        void Update(CimeriApplicationUser entity);
        void Delete(CimeriApplicationUser entity);

        CimeriApplicationUser GetUserById(string userId);


    }
}
