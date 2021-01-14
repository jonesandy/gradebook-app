using AutoFixture;
using AutoFixture.Xunit2;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Theory, AutoData]
        public void Grade_should_be_added_to_book([Range(0, 100)] double grade)
        {
            var fixture = new Fixture();
            var sut = new Book(fixture.Create<string>(), ConsoleWriteLine.PrintWhenGradeAdded);

            var result = sut.AddGrade(grade);

            Assert.Contains(grade, result);
        }

        [Theory]
        [InlineData(105)]
        [InlineData(-1)]
        public void Grade_should_not_be_added_and_exception_thrown(double grade)
        {
            var fixture = new Fixture();
            var sut = new Book(fixture.Create<string>(), ConsoleWriteLine.PrintWhenGradeAdded);

            Assert.Throws<System.ArgumentException>(() => sut.AddGrade(grade));
        }

        [Theory, AutoData]
        public void All_grades_should_be_returned([Range(0, 100)]double grade)
        {
            var fixture = new Fixture();
            var sut = new Book(fixture.Create<string>(), ConsoleWriteLine.PrintWhenGradeAdded);

            sut.AddGrade(grade);
            sut.AddGrade(grade);
            var result = sut.GetGrades();

            Assert.Equal(2, result.Count);
        }
    }
}
