﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Last
{
    public static class RegularExpressions
    {
        private static Regex regex = null;


        private static string _01_09 = @"0?[1-9]";
        private static string _10_29 = @"[12]\d";
        private static string hours = @"((0[0-9])|(1[0-9])|(2[0-3]))";
        private static string minutes = @"((0[0-9])|([1-5][0-9]))";
        private static string seconds = @"((0[0-9])|([1-5][0-9]))";



        private static string username = @"^[^\s]+";
        private static string reboot = @"^reboot";
        private static string loged_in = @"still logged in";
        private static string down = @"down";
        private static string year = @"20[0-9][0-9]";
        private static string terminal = @"((pts\/\d?\d)|(tty\d))";

        private static string WeekDay = @"(Mon|T(ue|hu)|Wed|Fri|S(un|at))";
        private static string month = @"((J(an|un|ul)|Feb|Ma(r|y)|A(pr|ug)|Sep|Oct|Nov|Dec))";
        private static string day_of_month = @"((0?[1-9])|([12]\d)|(3[01]))";

        private static string time =
            @"(((0[0-9])|(1[0-9])|(2[0-3]))):(((0[0-9])|([1-5][0-9]))):(((0[0-9])|([1-5][0-9])))";

        private static string duration = @"\((\d?\d\+)?(((0[0-9])|(1[0-9])|(2[0-3]))):(((0[0-9])|([1-5][0-9])))\)";
        private static string host = @"([^ ]+)?$";

        private static string LogTime = WeekDay + @"\s+" + month + @"\s+" + day_of_month + @"\s+" + time + @"\s+" + year;

        private static string SYSTEM_CRASH = username + @"\s+" + terminal + @"\s+" + WeekDay + @"\s+" + month + @"\s+" +
                                             day_of_month + @"\s+" + time + @"\s+" + year + @"\s+" + @"-" + @"\s+" +
                                             down + @"\s+" + duration;

        private static string SYSTEM_SHUTDOWN = @"^shutdown" + @"\s+" + "system" + @"\s+" + "down" + @"\s+" + LogTime +
                                                @"\s+" + @"-" + @"\s+" + LogTime + @"\s+" + duration + @"\s+" + host;

        private static string COMPLETE_KNOWN_TERMINAL_SYSTEM_CRASH = username + @"\s+" + terminal + @"\s+" + LogTime + @"\s+" + @"-" +
                                                        @"\s+" + down + @"\s+" + duration + @"\s+" + host;

        private static string COMPLETE_KNOWN_TERMINAL_KNOWN_LOGOFF = username + @"\s+" + terminal + @"\s+" + LogTime + @"\s+" + @"-" + @"\s+" + LogTime + @"\s+" + duration + @"\s+" + host;

        private static string COMPLETE_UNKNOWN_TERMINAL_KNOWN_LOGOFF = username + @"\s+" + terminal + @"\s+" + LogTime + @"\s+" + @"-" + @"\s+" + LogTime + @"\s+" + duration;

        private static string INCOMPLETE_LOGIN_KNOWN_TERMINAL = username + @"\s+" + terminal + @"\s+" + LogTime + @"\s+" + loged_in + @"\s+" + host;


        public static string isSystemCrash(String line)
        {
            string type = null;
            regex = new Regex(SYSTEM_CRASH);
            Match match = regex.Match(line);
            if (match.Success)
                type = "SYSTEM CRASH";

            return type;




        }

        public static string isSystemShutdown(String line)
        {
            string type = null;
            regex = new Regex(SYSTEM_SHUTDOWN);
            Match match = regex.Match(line);
            if (match.Success)
                type = "SYSTEM SHUTDOWN";

            return type;


        }

        public static string isCompleteLogInSessionCrash(String line)
        {
            string type = null;
            regex = new Regex(COMPLETE_KNOWN_TERMINAL_SYSTEM_CRASH);
            Match match = regex.Match(line);
            if (match.Success)
                type = "COMPLETE KNOWN_TERMINAL_SYSTEM_CRASH";

            return type;


        }

        public static string isCompleteKnownLogTimes(String line)
        {
            string type = null;
            regex = new Regex(COMPLETE_KNOWN_TERMINAL_KNOWN_LOGOFF);
            Match match = regex.Match(line);
            if (match.Success)
                type = "COMPLETE KNOWN_TERMINAL KNOWN LOG OFF";

            return type;


        }

        public static string isCompleteUnknownTerminal(String line)
        {
            string type = null;
            regex = new Regex(COMPLETE_UNKNOWN_TERMINAL_KNOWN_LOGOFF);
            Match match = regex.Match(line);
            if (match.Success)
                type = "COMPLETE UKNOWN_TERMINAL KNOWN LOG OFF";

            return type;


        }

        public static string isIncomplete(String line)
        {
            string type = null;
            regex = new Regex(INCOMPLETE_LOGIN_KNOWN_TERMINAL);
            Match match = regex.Match(line);
            if (match.Success)
                type = "INCOMPLETE KNOWN_TERMINAL KNOWN LOG OFF";

            return type;


        }






    }

}