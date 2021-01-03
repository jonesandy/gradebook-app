using AutoFixture;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Grade_should_be_added_to_book()
        {
            var fixture = new Fixture();
            var grade = fixture.Create<double>();
            var sut = new Book(fixture.Create<string>());

            var result = sut.AddGrade(grade);

            Assert.Contains(grade, result);
        }

        [Fact]
        public void All_grades_should_be_returned()
        {
            var fixture = new Fixture();
            var grade1 = fixture.Create<double>();
            var grade2 = fixture.Create<double>();
            var sut = new Book(fixture.Create<string>());
            
            sut.AddGrade(grade1);
            sut.AddGrade(grade2);
            var result = sut.GetGrades();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void Statistics_should_be_computed_and_returned()
        {
            var fixture = new Fixture();
            var grade1 = 10;
            var grade2 = 2;
            var sut = new Book(fixture.Create<string>());

            sut.AddGrade(grade1);
            sut.AddGrade(grade2);
            var result = sut.ComputeStatistics();

            Assert.Equal(grade1, result.HighGrade);
            Assert.Equal(grade2, result.LowGrade);
            Assert.Equal(6, result.AverageGrade);
        }
    }
}
