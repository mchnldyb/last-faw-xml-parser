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
            InputFile myInput = new InputFile(@"validdata.txt");
            myInput.readInputFile();
        }
    }
}
