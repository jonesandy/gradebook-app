using System.Collections.Generic;

namespace GradeBook.Types
{
    public interface IBook
    {
        string Name { get; }
        List<double> AddGrade(double grade);
    }
}
