using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimeri.Domain.DomainModels
{
    public class CimeriPost
    {
        public int CimeriPostID { get; set; }
        public int CityID { get; set; }
        public int budget { get; set; }
        public int sameGenderRequired { get; set; } // -1: Not selected, 0: No, 1: Yes
        public int studentRequired { get; set; } // -1: Not selected, 0: No, 1: Yes
        public int optimalNumberOfRoommates { get; set; }

        // 1 - 3 months or less
        // 2 - 3 months to 1 year
        // 3 - 1+ year
        public int howLong { get; set; }

        public int isSmoker { get; set; } // -1: Not selected, 0: No, 1: Yes

        public int guestsAllowed { get; set; } // -1: Not selected, 0: No, 1: Yes

        public string userID { get; set; }
    }
}