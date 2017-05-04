using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last
{
    class ErrorLog
    {
        private String errorFile;

        public ErrorLog()
        {
            
        }

        
        public void writeError(String description)
        {
            if (!File.Exists(Argconstants.ERROR_FILE))
            {
                File.Create(Argconstants.ERROR_FILE).Dispose();
            }

            using (StreamWriter writer = new StreamWriter(Argconstants.ERROR_FILE, true))
            {
                writer.WriteLine(description);
                writer.Close();
            }
        }
    }
}
