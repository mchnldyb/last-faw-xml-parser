using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Last
{
    class Program
    {
        static void Main(string[] args)
        {

            Options options = new Options();
            var isValid = CommandLine.Parser.Default.ParseArgumentsStrict(args, options);

            Argconstants.MARKUP_FILE = options.MarkupFile;
            Argconstants.ERROR_FILE = options.ErrorFile;
            Argconstants.SUSPENSE_FILE = options.SuspenseFile;
            Argconstants.INPUT_FILE = options.InputFile;

            InputFile infFile = new InputFile(options.InputFile);
            Session mySession = new Session(infFile);
            mySession.readSessions();

            

        }
    }
}
