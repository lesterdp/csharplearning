using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("gradeBook");
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"Book: {book.Name}");
            Console.WriteLine($"Highest: {stats.High:N1}");
            Console.WriteLine($"Lowest: {stats.Low:N1}");
            Console.WriteLine($"Average: {stats.Average:N1}");
            Console.WriteLine($"Letter: {stats.Letter:N1}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
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
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }

    }
}