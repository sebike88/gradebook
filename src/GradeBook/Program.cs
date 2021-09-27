using System;

namespace GradeBook
{
    class Program
    {
        // static - not associated with an object. Can only be called directly from the class.
        static void Main(string[] args)
        {
            var book = new Book("Sebi's Grade Book");

            while (true)
            {
                Console.WriteLine("Please add a grade or type 'Q' to quit");
                var input = Console.ReadLine();

                if (input == "Q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            
            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter is {stats.Letter}");
        }
    }
}
