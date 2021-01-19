using GradeBook.Models;
using System.Collections.Generic;
using System;
using GradeBook.Types;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        private StatisticsBuilder _statsBuilder;
        private readonly List<double> grades = new List<double>();
        public event GradeAddedDelegate GradeAdded;

        public InMemoryBook(string name, GradeAddedDelegate assignGradeAdded) : base(name)
        {
            GradeAdded = assignGradeAdded;
            _statsBuilder = new StatisticsBuilder();
        }

        public List<double> GetGrades()
        {
            return grades;
        }

        public override List<double> AddGrade(double grade)
        {
            if(grade <= 100 && grade >=0)
            {
                grades.Add(grade);
                GradeAdded?.Invoke(Name, new EventArgs());
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

            return grades;
        }

        public Statistics GenerateStatistics()
        {
            return _statsBuilder.ComputeStatistics(grades);
        }

        public void DeleteGrades()
        {
            grades.Clear();
        }
    }
}
