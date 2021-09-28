using System;

namespace GradeBook
{
    class Program
    {
        // static - not associated with an object. Can only be called directly from the class.
        static void Main(string[] args)
        {
            var book = new Book("Sebi's Grade Book");
            book.GradeAdded += OnGradeAdded;

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
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
                
            }
            
            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named {Book.CATEGORY}");
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter is {stats.Letter}");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A Grade was added");
        }
    }
}
