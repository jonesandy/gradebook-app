using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main()
        {
            var total = 0.0;
            var grades = new List<double>()
            {
                87.9,
                75.3,
                86.3,
                92.1
            };

            foreach(var score in grades)
            {
                total += score;
            }

            double average = total / grades.Count;

            Console.WriteLine($"The tallied score for all grades: {total:N1}");
            Console.WriteLine($"The average grade: {average:N1}");
        }
    }
}
