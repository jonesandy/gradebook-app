using GradeBook.Models;
using System;

namespace GradeBook
{
    public static class DisplayFormatter
    {
        public static void PrintStatistics(Statistics stats)
        {
            Console.WriteLine($"The lowest grade was: {stats.LowGrade:N1}");
            Console.WriteLine($"The highest grade was: {stats.HighGrade:N1}");
            Console.WriteLine($"The average grade was: {stats.AverageGrade:N1}");
            Console.WriteLine($"The pupil rating was: {stats.Rating}");
        }
    }
}
