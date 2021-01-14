using System;

namespace GradeBook
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the GradeBook App.");
            Console.WriteLine("Please name your book.");

            var name = Console.ReadLine();
            var book = new Book(name, ConsoleWriteLine.PrintWhenGradeAdded);

            while (true)
            {
                Console.WriteLine("Please add a grade to your book, or 'q' to quit.");
                var x = Console.ReadLine();

                try
                {
                    if (x != "q" && x != "Q")
                    {
                        book.AddGrade(double.Parse(x));
                        Console.WriteLine("----------");
                    }
                    else
                    {
                        break;
                    }
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            var stats = book.GenerateStatistics();

            DisplayFormatter.PrintStatistics(stats);
        }
    }
}
