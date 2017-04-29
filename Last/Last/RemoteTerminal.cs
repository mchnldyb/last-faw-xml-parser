using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Last
{
    class RemoteTerminal : Field
    {
        public override string getField(string session)
        {
            Match match = Regex.Match(session, RegularExpressions.getPattern("remote-terminal"));

            return match.Value;
        }
    }
}
