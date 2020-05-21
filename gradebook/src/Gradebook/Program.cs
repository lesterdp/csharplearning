using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Deric's Grade Book");
            
            while(true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if(input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            var stats = book.GetStatistics();
            
            Console.WriteLine($"Highest: {stats.High:N1}");
            Console.WriteLine($"Lowest: {stats.Low:N1}");
            Console.WriteLine($"Average: {stats.Average:N1}");
            Console.WriteLine($"Letter: {stats.Letter:N1}");

            
        }
    }
}