using AutoFixture;
using AutoFixture.Xunit2;
using System.ComponentModel.DataAnnotations;
using Xunit;
using Xunit.Abstractions;

namespace GradeBook.Tests
{
    public class BookTests
    {
        private readonly ITestOutputHelper _output;

        public BookTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory, AutoData]
        public void Grade_should_be_added_to_book([Range(0, 100)] double grade)
        {
            var fixture = new Fixture();
            var sut = new Book(fixture.Create<string>());

            var result = sut.AddGrade(grade);

            Assert.Contains(grade, result);
        }

        [Fact]
        public void Grade_should_not_be_added()
        {
            var fixture = new Fixture();
            var grade = 105;
            var sut = new Book(fixture.Create<string>());

            sut.AddGrade(grade);
            var result = sut.AddGrade(grade);

            Assert.DoesNotContain(grade, result);
        }

        [Theory, AutoData]
        public void All_grades_should_be_returned([Range(0, 100)]double grade)
        {
            var fixture = new Fixture();
            var sut = new Book(fixture.Create<string>());

            sut.AddGrade(grade);
            sut.AddGrade(grade);
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
