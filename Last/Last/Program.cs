using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last
{
    class Program
    {
        static void Main(string[] args)
        {
            InputFile infFile = new InputFile(@"validdata.txt");
            Session mySession = new Session(infFile);
            mySession.readSessions();
           
        }
    }
}
