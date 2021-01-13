using GradeBook.Models;
using System.Collections.Generic;
using System;

namespace GradeBook
{
    public class Book
    {
        private StatisticsBuilder _statsBuilder;
        private List<double> grades = new List<double>();
        public string Name { get; set; }
        public readonly string Category;
        public const string USAGE = "Grades";

        public Book(string name) 
        {
            Category = "School Book";
            Name = name;
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
