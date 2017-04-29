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
            this.filename = name;
        }



        public String getFileName()
        {
            return this.filename;
        }


        public void isValid()
        {
            string last_line = null;

            foreach (var line in File.ReadLines(this.getFileName()).Reverse())
            {
                last_line = line;
                break;
            }

        }


    }
}
