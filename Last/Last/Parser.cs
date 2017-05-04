using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Last
{
    class Parser
    {
        Username  mUsername = new Username();
        Terminal mTerminal = new Terminal();
        Date mDate = new Date();
        Duration mDuration = new Duration();
        RemoteTerminal mRemoteTerminal = new RemoteTerminal();

        private XDocument document;

        private String outputFilePath;



        public Parser()
        {
            this.createOutputFile();
        }

   
        public void parseXML(String line, String type)
        {
            switch (type)
            {
                case "complete":
                    {
                        document = XDocument.Load(outputFilePath);
                        document.Element("Sessions").Add(new XElement(type,
                                                        new XElement(mUsername.GetType().Name, new XText(mUsername.getField(line)))
                                                        , new XElement(mTerminal.GetType().Name, new XText(mTerminal.getField(line)))
                                                        , new XElement(mDate.GetType().Name, new XText(mDate.getField(line)))
                                                        , new XElement(mDuration.GetType().Name, new XText(mDuration.getField(line)))
                                                        , new XElement(mRemoteTerminal.GetType().Name, new XText(mRemoteTerminal.getField(line)))
                                                        )); 
                            
                        document.Save(outputFilePath);
                        break;
                    }

                case "incomplete":
                {
                    document = XDocument.Load(outputFilePath);
                    document.Element("Sessions").Add(new XElement(type, 
                                                             new XElement(mUsername.GetType().Name,new XText(mUsername.getField(line)))
                                                            , new XElement(mTerminal.GetType().Name, new XText(mTerminal.getField(line)))
                                                            , new XElement(mDate.GetType().Name, new XText(mDate.getField(line)))
                                                            , new XElement(mDuration.GetType().Name, new XText(mDuration.getField(line)))
                                                            , new XElement(mRemoteTerminal.GetType().Name, new XText(mRemoteTerminal.getField(line)))
                                                            ));
                    document.Save(outputFilePath);
                    break;
                }


                case "system-crash":
                {
                        document = XDocument.Load(outputFilePath);
                        document.Element("Sessions").Add(new XElement(type,
                                                        new XElement(mUsername.GetType().Name, new XText(mUsername.getField(line)))
                                                       ,new XElement(mTerminal.GetType().Name, new XText(mTerminal.getField(line)))
                                                       ,new XElement(mDate.GetType().Name, new XText(mDate.getField(line)))
                                                       ,new XElement(mDuration.GetType().Name, new XText(mDuration.getField(line)))
                                                        ));
                        document.Save(outputFilePath);
                        break;

                }

                case "system-shutdown":
                {
                        document = XDocument.Load(outputFilePath);
                        document.Element("Sessions").Add(new XElement(type,
                                                         new XElement(mDate.GetType().Name, new XText(mDate.getField(line)))
                                                       , new XElement(mDuration.GetType().Name, new XText(mDuration.getField(line)))
                                                       , new XElement(mTerminal.GetType().Name, new XText(mTerminal.getField(line)))
                                                        ));
                        document.Save(outputFilePath);
                        break;

                 }

                case "reboot":
                {
                        document = XDocument.Load(outputFilePath);
                        document.Element("Sessions").Add(new XElement(type,
                                                         new XElement(mDate.GetType().Name, new XText(mDate.getField(line)))
                                                       , new XElement(mDuration.GetType().Name, new XText(mDuration.getField(line)))
                                                       , new XElement(mTerminal.GetType().Name, new XText(mTerminal.getField(line)))
                                                        ));
                        document.Save(outputFilePath);
                        break;

                 }

                case "runlevel-change":
                {
                        document = XDocument.Load(outputFilePath);
                        document.Element("Sessions").Add(new XElement(type,
                                                        new XElement("Description"), new XText(RegularExpressions.getRunLevel(line))
                                                       , new XElement(mDate.GetType().Name, new XText(mDate.getField(line)))
                                                       , new XElement(mDuration.GetType().Name, new XText(mDuration.getField(line)))
                                                       , new XElement(mTerminal.GetType().Name, new XText(mTerminal.getField(line)))
                                                        ));
                        document.Save(outputFilePath);
                        break;

                    }



            }
        }

        public void createOutputFile()
        {
            if (!File.Exists(outputFilePath))
            {
                outputFilePath = Argconstants.MARKUP_FILE;
                document = new XDocument(new XElement("Sessions"));
                document.Save(outputFilePath);
            }
        }
    }
}
