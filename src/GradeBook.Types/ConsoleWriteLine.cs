using System;

namespace GradeBook
{
    public class ConsoleWriteLine
    {
        public static void PrintWhenGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine($"{sender} just added a grade");
        }
    }
}
