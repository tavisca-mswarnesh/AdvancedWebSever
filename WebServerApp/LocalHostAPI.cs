using Newtonsoft.Json.Linq;
using System;

namespace SimpleWebserver
{
    public class LocalHostAPI
    {
        public LocalHostAPI()
        {

        }
        public string IsLeapYear(JObject yearObj)
        {
            int year = Int32.Parse(yearObj["year"].ToString());
            string text;
            if (year % 400 == 0)
                text = "yes";
            else if (year % 100 == 0)
                text = "No";
            else if (year % 4 == 0)
                text = "Yes";
            else
                text = "No";
            return (text);

        }
    }
}