using GradeBook.Models;
using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class StatisticsBuilder
    {
        public Statistics ComputeStatistics(List<double> grades)
        {
            double total = 0.0;
            double average = 0.0;
            double highGrade = double.MinValue;
            double lowGrade = double.MaxValue;

            foreach (var score in grades)
            {
                highGrade = Math.Max(score, highGrade);
                lowGrade = Math.Min(score, lowGrade);
                total += score;
            }

            if(total != 0.0)
            {
                average = total / grades.Count;
            }

            char rating = GetLetterRating(average);

            return new Statistics
            {
                AverageGrade = average,
                HighGrade = highGrade == double.MinValue? 0 : highGrade,
                LowGrade = lowGrade == double.MaxValue? 0 : lowGrade,
                Rating = rating
            };
        }

        public char GetLetterRating(double grade)
        {
            switch (grade)
            {
                case var g when g >= 90.0:
                    return 'A';

                case var g when g >= 80.0:
                    return 'B';

                case var g when g >= 70.0:
                    return 'C';

                default:
                    return 'F';
            }
        }
    }
}
