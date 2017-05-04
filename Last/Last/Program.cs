using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Last
{
    class Program
    {
        static void Main(string[] args)
        {
            //Call Menu to display and read Command Line arguments
            Options options = new Options();
            var isValid = CommandLine.Parser.Default.ParseArgumentsStrict(args, options);

            //Assign Command Line Arguments to Global variables
            Argconstants.MARKUP_FILE = options.MarkupFile;
            Argconstants.ERROR_FILE = options.ErrorFile;
            Argconstants.SUSPENSE_FILE = options.SuspenseFile;
            Argconstants.INPUT_FILE = options.InputFile;

            //Checks if input file exists, If not, Exit Application and Write Error
            if (File.Exists(options.InputFile))
            {
                InputFile infFile = new InputFile(options.InputFile);
                Session mySession = new Session(infFile);
                mySession.readSessions();
            }

            else
            {
                Console.WriteLine("InputFile does not exist or is not valid");
                Environment.Exit(2);
            }
            


        }
    }
}
