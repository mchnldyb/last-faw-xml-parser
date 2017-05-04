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
        private ErrorLog error = new ErrorLog();


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
                    mParser.parseXML(singleSession,RegularExpressions.getRecordType(singleSession));
                    break;
                }

                case "incomplete":
                {
                     mParser.parseXML(singleSession,RegularExpressions.getRecordType(singleSession));
                     break;
                }

                default:
                {
                    Console.WriteLine("other");
                        break;
                }
                
            }
        }




        public void writeToSuspenseFile(String unparsableSession)
        {
            if (!File.Exists(Argconstants.SUSPENSE_FILE))
            {
                File.Create(Argconstants.SUSPENSE_FILE).Dispose();
            }

            using (StreamWriter writer = new StreamWriter(Argconstants.SUSPENSE_FILE, true))
            {
                writer.WriteLine(unparsableSession);
                writer.Close();
            }
        }





        public void readSessions()
        {
            if (!lastInputFile.isValid())
            {
                //Write to error log and exit here
                error.writeError("Specified file is not valid");
                Console.WriteLine("Is valid");
            }
            int counter = 0;
            String line;
            
            Console.WriteLine(this.lastInputFile.getInputStartTime());
            Console.WriteLine(this.lastInputFile.getCreationTime());

            try
            {
                StreamReader file = new StreamReader(this.lastInputFile.getFileName());

                while ((line = file.ReadLine()) != null)
                {

                    if (RegularExpressions.getRecordType(line).Equals("none"))
                    {
                        this.writeToSuspenseFile(line);
                        continue;
                    }

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
