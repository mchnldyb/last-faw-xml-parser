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
            StreamWriter xmlOutput = new StreamWriter();

            try
            {
                StreamReader file = new StreamReader(filename);

                while ((line = file.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
                    //currentLine.getFields(line);
                    Console.WriteLine("<" + RegularExpressions.getRecordType(line) + ">" + line + "</" + RegularExpressions.getRecordType(line) + ">");
                    
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
