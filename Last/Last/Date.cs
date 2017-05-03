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
        public override string getField(string session)
        {
            Match match = Regex.Match(session, RegularExpressions.getPattern("date"));

            return match.Value;
        }
    }
}
