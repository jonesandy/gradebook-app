using System.Collections.Generic;

namespace GradeBook.Tests.TestData
{
    public class TestGradesData
    {
        public static IEnumerable<object[]> InvalidGrades => _invalidData;
        public static IEnumerable<object[]> ValidGrades => _validData;
        public static IEnumerable<object[]> AverageGradeLetterMapping => _averageGradeLetterMapping;


        private static readonly List<object[]> _invalidData = new List<object[]>
        {
            new object[]{ 105 },
            new object[]{ -1 }
        };

        private static readonly List<object[]> _validData = new List<object[]>
        {
            new object[]{ 40, 50, 60, 50, 'F' }
        };

        private static readonly List<object[]> _averageGradeLetterMapping = new List<object[]>
        {
            new object[]{ 'A', 90.0 },
            new object[]{ 'B', 80.0 },
            new object[]{ 'C', 70.0 },
            new object[]{ 'F', 69.9 },
        };
    }
}
