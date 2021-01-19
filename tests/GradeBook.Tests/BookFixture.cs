namespace GradeBook.Tests
{
    public class BookFixture 
    {
        public InMemoryBook Book { get; private set; }

        public BookFixture()
        {
            Book = new InMemoryBook("TestGradeBook", ConsoleWriteLine.PrintWhenGradeAdded);
        }
    }
}
