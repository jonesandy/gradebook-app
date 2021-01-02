namespace GradeBook
{
    class Program
    {
        static void Main()
        {
            var book = new Book("Andy");
            book.AddGrade(87.9);
            book.AddGrade(75.3);
            book.AddGrade(86.3);
            book.AddGrade(92.1);

            book.ShowStatistics();
        }
    }
}
