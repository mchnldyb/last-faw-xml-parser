using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Last
{
    class Duration : Field
    {
        //Subclass of Field to Hold Information related to the Duration of Sessions

        public override string getField(string session)
        {
            //Returns the Duration from a parsed session
            Match match = Regex.Match(session, RegularExpressions.getPattern("duration"));

            return match.Value;
        }
    }
}
