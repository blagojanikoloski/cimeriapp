using Cimeri.Domain.DomainModels;
using Microsoft.AspNetCore.Identity;

namespace Cimeri.Domain.Identity
{
    public class CimeriApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

    }
}
