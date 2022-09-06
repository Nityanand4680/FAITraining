using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    static class Util
    {
        public static string GetString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public static int GetNumber(string question) => int.Parse(GetString(question));
        
        public static short GetShortNumber(string question) => short.Parse(GetString(question));

        public static double GetDoubleNumber(string question) => double.Parse(GetString(question));
    }
}
