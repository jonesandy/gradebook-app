using AutoFixture;
using GradeBook.Tests.TestData;
using Xunit;

namespace GradeBook.Tests
{
    [Trait("SUT", "Statistic Builder")]
    public class StatisticsBuilderTests
    {
        [Trait("TypeOfGrade", "Letter")]
        [Theory]
        [MemberData(nameof(TestGradesData.AverageGradeLetterMapping), MemberType = typeof(TestGradesData))]
        public void Letter_rating_should_be_computed_and_returned(char rating, double grade)
        {
            var sut = new StatisticsBuilder();

            var result = sut.GetLetterRating(grade);

            Assert.Equal(rating, result);
        }

        [Theory]
        [MemberData(nameof(TestGradesData.ValidGrades), MemberType = typeof(TestGradesData))]
        public void Statistics_should_be_computed_and_returned(int grade1, int grade2, int grade3, int average, char letterRating)
        {
            var fixture = new Fixture();
            var sut = new InMemoryBook(fixture.Create<string>(), ConsoleWriteLine.PrintWhenGradeAdded);

            sut.AddGrade(grade1);
            sut.AddGrade(grade2);
            sut.AddGrade(grade3);
            var result = sut.GenerateStatistics();

            Assert.Equal(grade3, result.HighGrade);
            Assert.Equal(grade1, result.LowGrade);
            Assert.Equal(average, result.AverageGrade);
            Assert.Equal(letterRating, result.Rating);
        }
    }
}
