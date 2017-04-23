using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Last
{
    class InputFile
    {
        private string filename;


        public InputFile(string name)
        {
            filename = name;
        }


        public String getFileName()
        {
            return filename;
        }


        public void readInputFile()
        {
            int counter = 0;
            String line;
            //Field currentLine = new Field();

            try
            {
                StreamReader file = new StreamReader(filename);

                while ((line = file.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
                    //currentLine.getFields(line);
                    Console.WriteLine(RegularExpressions.isSystemCrash(line));
                    Console.WriteLine(RegularExpressions.isSystemShutdown(line));
                    Console.WriteLine(RegularExpressions.isCompleteKnownLogTimes(line));
                    Console.WriteLine(RegularExpressions.isCompleteLogInSessionCrash(line));
                    Console.WriteLine(RegularExpressions.isIncomplete(line));
                    Console.WriteLine(RegularExpressions.isCompleteUnknownTerminal(line));
                    counter++;
                }

                file.Close();

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
