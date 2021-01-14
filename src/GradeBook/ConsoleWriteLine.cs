using System;

namespace GradeBook
{
    class ConsoleWriteLine
    {
        public static void PrintWhenGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine($"{sender} just added a grade");
        }
    }
}
