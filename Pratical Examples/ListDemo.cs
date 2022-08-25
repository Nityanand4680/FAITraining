using System;
using System.Collections.Generic;
using SampleConApp;
namespace RecapConApp
{
    class ListDemo
    {
        const string menu = "----------List Demo-----------\nTo add Name----------->Press 1\nTo View all Added Names----->Press 2\n";
       static List<string> values = new List<string>();
        static void Main(string[] args)
        {
            bool processing = true;
            do
            {
                int choice = Util.GetNumber(menu);
                processing = processMenu(choice);
            } while (processing);
        }

        private static bool processMenu(int choice)
        {
            if (choice == 1)
            {
                string name = Util.GetString("Enter the Name to add to List");
                values.Add(name);
            }
            else if (choice == 2)
            {
                foreach (var name in values) Console.WriteLine(name);
            }
            else
                return false;
            return true;
        }
    }
}
