using System;

namespace GradeBook
{
    class Program
    {
        // static - not associated with an object. Can only be called directly from the class.
        static void Main(string[] args)
        {
            var book = new Book("Sebi's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.1);
            
            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
        }
    }
}
