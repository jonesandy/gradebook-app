using AutoFixture.Xunit2;
using GradeBook.Tests.TestData;
using System;
using System.ComponentModel.DataAnnotations;
using Xunit;
using Xunit.Abstractions;

namespace GradeBook.Tests
{
    [Trait("SUT", "Book")]
    public class BookTests : IClassFixture<BookFixture>, IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly BookFixture _sut;

        public BookTests(ITestOutputHelper output, BookFixture book)
        {
            _output = output;
            _sut = book;
        }

        [Trait("TypeOfGrade", "Number")]
        [Theory, AutoData]
        public void Grade_should_be_added_to_book([Range(0, 100)] double grade)
        {
            _output.WriteLine($"Using book with Name: {_sut.Book.Name}");
            _output.WriteLine($"Adding grade: {grade}");
            var result = _sut.Book.AddGrade(grade);

            Assert.Contains(grade, result);
        }

        [Trait("TypeOfGrade", "Number")]
        [Theory]
        [MemberData(nameof(TestGradesData.InvalidGrades), MemberType = typeof(TestGradesData))]
        public void Grade_should_not_be_added_and_exception_thrown(double grade)
        {
            _output.WriteLine($"Using book with Name: {_sut.Book.Name}");
            Assert.Throws<ArgumentException>(() => _sut.Book.AddGrade(grade));
        }

        [Trait("TypeOfGrade", "Number")]
        [Theory, AutoData]
        public void All_grades_should_be_returned([Range(0, 100)]double grade)
        {
            _output.WriteLine($"Using book with Name: {_sut.Book.Name}");
            _output.WriteLine($"Adding grade: {grade}");
            _sut.Book.AddGrade(grade);
            _sut.Book.AddGrade(grade);
            var result = _sut.Book.GetGrades();

            Assert.Equal(2, result.Count);
        }

        public void Dispose()
        {
            _sut.Book.DeleteGrades();
        }
    }
}
