using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        private string name;
        private double total = 0.0;
        private double highGrade = double.MinValue;
        private double lowGrade = double.MaxValue;

        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void ShowStatistics()
        {
            ComputeStatistics();
            PrintStatistics();
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        private void ComputeStatistics()
        {
            foreach (var score in grades)
            {
                highGrade = Math.Max(score, highGrade);
                lowGrade = Math.Min(score, lowGrade);
                total += score;
            }
        }

        private void PrintStatistics()
        {
            double average = total / grades.Count;

            Console.WriteLine($"Statistics for GradeBook - {name}");
            Console.WriteLine($"The tallied score for all grades: {total:N1}");
            Console.WriteLine($"The average grade: {average:N1}");
            Console.WriteLine($"The lowest grade was: {lowGrade:N1}");
            Console.WriteLine($"The highest grade was: {highGrade:N1}");
        }
    }
}
