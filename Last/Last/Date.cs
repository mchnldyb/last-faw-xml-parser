using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Last
{
    class Date : Field
    {
        //Subclass of Field to Hold Information related to the Date of Sessions

        //Returns the date from a parsed session
        public override string getField(string session)
        {
            Match match = Regex.Match(session, RegularExpressions.getPattern("date"));

            return match.Value;
        }
    }
}
