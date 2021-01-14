using GradeBook.Models;
using System.Collections.Generic;
using System;
using GradeBook.Types;

namespace GradeBook
{
    public class Book
    {
        private StatisticsBuilder _statsBuilder;
        private List<double> grades = new List<double>();

        public const string USAGE = "Grades";
        public event GradeAddedDelegate GradeAdded;
        public readonly string Category;
        public string Name { 
            get;
            private set;
        }

        public Book(string name, GradeAddedDelegate assignGradeAdded) 
        {
            Name = name;
            GradeAdded = assignGradeAdded;
            Category = "School Book";
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
    }
}
