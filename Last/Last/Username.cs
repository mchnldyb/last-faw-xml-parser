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

        //Subclass of Field to Hold Information related to the Terminal of Sessions

        //Returns the Terminal from a parsed session
        public override String getField(String session)
        {
            Match match = Regex.Match(session, RegularExpressions.getPattern("username"));

            return match.Value;
        }

    }
}
