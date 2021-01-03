using GradeBook.Models;
using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades = new List<double>();
        private string name;
        private double total = 0.0;
        private double highGrade = double.MinValue;
        private double lowGrade = double.MaxValue;

        public Book(string name)
        {
            this.name = name;
        }

        public List<double> GetGrades()
        {
            return grades;
        }

        public List<double> AddGrade(double grade)
        {
            grades.Add(grade);

            return grades;
        }

        public Statistics ComputeStatistics()
        {
            foreach (var score in grades)
            {
                highGrade = Math.Max(score, highGrade);
                lowGrade = Math.Min(score, lowGrade);
                total += score;
            }

            return new Statistics
            {
                AverageGrade = total / grades.Count,
                HighGrade = highGrade,
                LowGrade = lowGrade
            };
        }
    }
}
