using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Last
{
    class Username : Field
    {
        public override String getField(String session)
        {
            Match match = Regex.Match(session, RegularExpressions.getPattern("username"));

            return match.Value;
        }

    }
}
