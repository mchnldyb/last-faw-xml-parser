using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


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
            XmlTextWriter xWriter = new XmlTextWriter(@"C:\Users\Hero\Documents\Visual Studio 2015\Projects\Last\Last\output.xml", Encoding.UTF8);
            xWriter.Formatting = Formatting.Indented;

            try
            {
                StreamReader file = new StreamReader(filename);

                while ((line = file.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
                    //currentLine.getFields(line);
                    xWriter.WriteStartElement("session");
                    xWriter.WriteStartElement(RegularExpressions.getRecordType(line));
                    xWriter.WriteString(line);
                    xWriter.WriteEndElement();
                    xWriter.WriteEndElement();
                    //Console.WriteLine("<" + RegularExpressions.getRecordType(line) + ">" + line + "</" + RegularExpressions.getRecordType(line) + ">");

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

            xWriter.Close();
        }
    }
}
