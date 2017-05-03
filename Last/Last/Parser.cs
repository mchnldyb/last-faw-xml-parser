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



            }
        }

        public void createOutputFile()
        {
            if (!File.Exists(outputFilePath))
            {
                outputFilePath = @"C:\Users\Hero\Documents\Visual Studio 2015\Projects\Last\Last\output.xml";
                document = new XDocument(new XElement("Sessions"));
                document.Save(outputFilePath);
            }
        }
    }
}
