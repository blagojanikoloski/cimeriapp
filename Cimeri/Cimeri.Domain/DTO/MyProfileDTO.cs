using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimeri.Domain.DTO
{
    public class MyProfileDTO
    {
        public int CimeriPostID { get; set; }
        public string city { get; set; }
        public int budget { get; set; }
        public string sameGenderRequired { get; set; } // -1: Not selected, 0: No, 1: Yes
        public string studentRequired { get; set; } // -1: Not selected, 0: No, 1: Yes
        public string optimalNumberOfRoommates { get; set; }

        // 1 - 3 months or less
        // 2 - 3 months to 1 year
        // 3 - 1+ year
        public string howLong { get; set; }

        public string isSmoker { get; set; } // -1: Not selected, 0: No, 1: Yes

        public string guestsAllowed { get; set; } // -1: Not selected, 0: No, 1: Yes

        public string userID { get; set; }
    }
}
