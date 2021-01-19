using System.Collections.Generic;

namespace GradeBook.Types
{
    public abstract class Book : IBook
    {
        public const string USAGE = "Grades";
        public readonly string Category;

        public string Name { get; private set;}

        public Book(string name)
        {
            Name = name;
            Category = "School Book";
        }

        public abstract List<double> AddGrade(double grade);
    }
}
