using GradeBook.Models;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private StatisticsBuilder _statsBuilder;
        private List<double> grades = new List<double>();
        private string name;

        public Book(string name)
        {
            this.name = name;
            _statsBuilder = new StatisticsBuilder();
        }

        public List<double> GetGrades()
        {
            return grades;
        }

        public List<double> AddGrade(double grade)
        {
            if(grade <= 100 && grade >=0)
            {
                grades.Add(grade);
            }

            return grades;
        }

        public Statistics GenerateStatistics()
        {
            return _statsBuilder.ComputeStatistics(grades);
        }
    }
}
