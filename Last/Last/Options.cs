using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace Last
{
    class Options
    {
        /*Command Line Menu Items. Contains the various switches for the command line parser and the corresponding variables*/

            //Menu Option for InputFile 
        [Option('i', "input", Required = true,
            HelpText = "Input files to be processed.")]
        public string InputFile { get; set; }

        //Menu Option for ErrorFile 
        [Option('e', "error", Required = true,
          HelpText = "Error files which to write errors to")]
        public string ErrorFile { get; set; }

        //Menu Option for SupenseFile 
        [Option('s', "suspense", Required = true,
            HelpText = "Suspense file for unparsable records")]
        public string SuspenseFile { get; set; }

        //Menu Option for MarkUpFile / XML File 
        [Option('m', "markup", Required = true,
            HelpText = "Markup file for parsed output")]
        public string MarkupFile { get; set; }

    }
}
