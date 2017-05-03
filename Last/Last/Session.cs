using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Last
{
    class Session
    {
     
        private InputFile lastInputFile;
        private Parser mParser = new Parser(); 


        public Session(InputFile inputFile)
        {
            this.lastInputFile = inputFile;
        }

        public void parse(String singleSession)
        {
            

            switch (RegularExpressions.getRecordType(singleSession))
            {
                case "complete":
                {
                    mParser.parseXML(singleSession,"complete");
                    break;
                }

                case "incomplete":
                {
                     mParser.parseXML(singleSession,"incomplete");
                     break;
                }

                default:
                {
                    Console.WriteLine("other");
                        break;
                }
                
            }
        }

        public void readSessions()
        {
            lastInputFile.isValid();
            int counter = 0;
            String line;
            //Field currentLine = new Field();
            

            try
            {
                StreamReader file = new StreamReader(this.lastInputFile.getFileName());

                while ((line = file.ReadLine()) != null)
                {
                    
                    if(RegularExpressions.getRecordType(line).Equals("none"))
                        continue; //write to error log here

                    this.parse(line);


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
