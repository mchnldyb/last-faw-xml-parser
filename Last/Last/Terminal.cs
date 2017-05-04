using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Last
{
    class Terminal : Field
    {
        //Subclass of Field to Hold Information related to the Terminal of Sessions

        //Returns the Terminal from a parsed session
        public override string getField(string session)
        {
            Match match = Regex.Match(session, RegularExpressions.getPattern("terminal"));

            return match.Value;
        }
    }
}
