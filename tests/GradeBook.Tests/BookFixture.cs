using System;

namespace GradeBook.Tests
{
    public class BookFixture 
    {
        public Book Book { get; private set; }

        public BookFixture()
        {
            Book = new Book("TestGradeBook", ConsoleWriteLine.PrintWhenGradeAdded);
        }
    }
}
