namespace GradeBook
{
    class Program
    {
        private const string V = "q"; 
        private const string W = "Q";
        private delegate string DecorateConsole();

        static void Main()
        {
            System.Console.WriteLine("Welcome to the GradeBook App.");
            System.Console.WriteLine("Please name your book.");

            var name = System.Console.ReadLine();
            var book = new Book(name);
            DecorateConsole display;

            while (true)
            {
                System.Console.WriteLine("Please add a grade to your book, or 'q' to quit.");
                var x = System.Console.ReadLine();

                try
                {
                    if (x != V && x != W)
                    {
                        book.AddGrade(double.Parse(x));
                    }
                    else
                    {
                        break;
                    }
                }
                catch(System.ArgumentException e)
                {
                    System.Console.WriteLine(e.Message);
                }
                catch(System.FormatException e)
                {
                    System.Console.WriteLine(e.Message);
                }
            }

            var stats = book.GenerateStatistics();

            display = ConsoleDecorator.ReturnStars;
            System.Console.WriteLine(display());

            DisplayFormatter.PrintStatistics(stats);

            display = ConsoleDecorator.ReturnDashes;
            System.Console.WriteLine(display());
        }
    }
}
