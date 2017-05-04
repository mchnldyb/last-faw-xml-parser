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


        //Constructor
        public InputFile(string name)
        {
            this.filename = name;
        }



        //Returns the Input File Name
        public String getFileName()
        {
            return this.filename;
        }




        //Checks Validity of Input File , If WTMP trailer is missing, reutns false
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


        //gets the creation time for the Input File.
        public DateTime getCreationTime()
        {
            return File.GetCreationTime(this.getFileName());
        }



        //Gets the input start date or WTMP time for InputFile
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
