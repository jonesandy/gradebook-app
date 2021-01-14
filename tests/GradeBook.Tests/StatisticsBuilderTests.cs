using AutoFixture;
using Xunit;

namespace GradeBook.Tests
{
    public class StatisticsBuilderTests
    {
        [Theory]
        [InlineData('A', 90.0)]
        [InlineData('B', 80.0)]
        [InlineData('C', 70.0)]
        [InlineData('F', 69.9)]
        public void Letter_rating_should_be_computed_and_returned(char rating, double grade)
        {
            var sut = new StatisticsBuilder();

            var result = sut.GetLetterRating(grade);

            Assert.Equal(rating, result);
        }

        [Fact]
        public void Statistics_should_be_computed_and_returned()
        {
            var fixture = new Fixture();
            var grade1 = 10;
            var grade2 = 2;
            var sut = new Book(fixture.Create<string>(), ConsoleWriteLine.PrintWhenGradeAdded);

            sut.AddGrade(grade1);
            sut.AddGrade(grade2);
            var result = sut.GenerateStatistics();

            Assert.Equal(grade1, result.HighGrade);
            Assert.Equal(grade2, result.LowGrade);
            Assert.Equal(6, result.AverageGrade);
            Assert.Equal('F', result.Rating);
        }
    }
}
