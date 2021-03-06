﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Last
{
    public static class RegularExpressions
    {
        //Regular Expressions Class to hold all Regex Patters and Methods to compare record types


        //Begin Regex Patterns for Record Types    
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
        private static string runlevel_desc = @"\(to+\s+lvl\s+[1-5]\)";
        private static string year = @"20[0-9][0-9]";
        private static string terminal = @"((pts\/\d?\d)|(tty\d))";

        private static string WeekDay = @"(Mon|T(ue|hu)|Wed|Fri|S(un|at))";
        private static string month = @"((J(an|un|ul)|Feb|Ma(r|y)|A(pr|ug)|Sep|Oct|Nov|Dec))";
        private static string day_of_month = @"((0?[1-9])|([12]\d)|(3[01]))";

        private static string time =
            @"(((0[0-9])|(1[0-9])|(2[0-3]))):(((0[0-9])|([1-5][0-9]))):(((0[0-9])|([1-5][0-9])))";

        private static string duration = @"\((\d?\d\+)?(((0[0-9])|(1[0-9])|(2[0-3]))):(((0[0-9])|([1-5][0-9])))\)";
        private static string host = @"([^ ]+)?$";

        private static string wtmp_trailer = @"^wtmp\s+begins\s+(Mon|T(ue|hu)|Wed|Fri|S(un|at))\s+((J(an|un|ul)|Feb|Ma(r|y)|A(pr|ug)|Sep|Oct|Nov|Dec))\s+";

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

        private static string REBOOT_RECORD = reboot + @"\s+" + @"system" + @"\s+" + @"boot" + @"\s+" + LogTime + @"\s+" +
                                              @"-" + @"\s+" + LogTime + @"\s+" + duration + @"\s+" + host;

        private static string RUNLEVEL_CHANGE = @"^runlevel" + @"\s+" + runlevel_desc + @"\s+" + LogTime + @"\s+" + @"-" +
                                                @"\s+" + LogTime + @"\s+" + duration + @"\s+" + host;
        //End Regex Patterns for All Records

        
        //Returns type of record based on Regular Expressions stated above for various record types
        public static string getRecordType(String line)
        {
            String rec_type = null;

            if (new Regex(SYSTEM_CRASH).IsMatch(line))
            { 
                return "system-crash";
            }
            else if (new Regex(SYSTEM_SHUTDOWN).IsMatch(line))
            { 
                return "system-shutdown";
            }
            else if (new Regex(COMPLETE_KNOWN_TERMINAL_SYSTEM_CRASH).IsMatch(line))
            { 
                return "complete";
            }
            else if (new Regex(COMPLETE_KNOWN_TERMINAL_KNOWN_LOGOFF).IsMatch(line))
            { 
                return "complete";
            }
            else if (new Regex(COMPLETE_UNKNOWN_TERMINAL_KNOWN_LOGOFF).IsMatch(line))
            {
                return "complete";
            }
            else if (new Regex(INCOMPLETE_LOGIN_KNOWN_TERMINAL).IsMatch(line))
            {
                return "incomplete";
            }
            else if (new Regex(REBOOT_RECORD).IsMatch(line))
            {
                return "reboot";
            }
            else if (new Regex(RUNLEVEL_CHANGE).IsMatch(line))
            {
                return "runlevel-change";
            }
            else
            {
                return "none";
            }

        }

        //Returns the pattern for the various record types based on the Caller to the sub field types
        public static string getPattern(string _caller)
        {
            string pattern = null;

            switch (_caller)
            {
                case "username":
                    pattern = username;
                    break;

                case "terminal":
                    pattern = terminal;
                    break;
                case "duration":
                    pattern = duration;
                    break;
                case "remote-terminal":
                    pattern = host;
                    break;
                case "date":
                    pattern = LogTime;
                    break;

            }

            return pattern;
        }

        //Validates the WTMP trailer in the InputFile based on Regular Expressions
        public static bool getwtmpTrailerStatus(String line)
        {
            if (new Regex(wtmp_trailer).IsMatch(line))
                return true;

            return false;

        }



        //Returns the RunLevel change for a specified run level Session type
        public static string getRunLevel(String line)
        {
            Match match = Regex.Match(line, RegularExpressions.runlevel_desc);

            return match.Value;
        }

     }

}
