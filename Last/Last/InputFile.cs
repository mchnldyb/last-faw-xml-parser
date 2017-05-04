using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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





        public bool isValid()
        {
            string last_line = null;

            foreach (var line in File.ReadLines(this.getFileName()).Reverse())
            {
                last_line = line;
                break;
            }

            if (RegularExpressions.getwtmpTrailerStatus(last_line))
                return true;

            return false;

        }



        public DateTime getCreationTime()
        {
            return File.GetCreationTime(this.getFileName());
        }




        public string getInputStartTime()
        {
            string last_line = null;

            foreach (var line in File.ReadLines(this.getFileName()).Reverse())
            {
                last_line = line;
                break;
            }

            Match match = Regex.Match(last_line, RegularExpressions.getPattern("date"));

            return match.Value;
        }


    }
}
