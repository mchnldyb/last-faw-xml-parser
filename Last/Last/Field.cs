﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Last
{
    abstract class Field
    {
        //Abstract Class to hold different types of Fields

        public abstract String getField(String session);

    }
}
