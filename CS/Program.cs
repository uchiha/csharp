using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace CS
{
    class Program
    {
        static void Main(string[] args)
        {        
            GradeBook book = new GradeBook();

            
            book.NameChanged += OnNameChange;
            Console.WriteLine("Write a book name: ");
            string check = Console.ReadLine();

            while (string.IsNullOrEmpty(check))
            {
                Console.WriteLine("Write a book name: ");
                check = Console.ReadLine();
            }
            book.Name = check;
            //book.Name = "Another change is here!";
            
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Average" , stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);


        }

        static void OnNameChange(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }

        

        static void WriteResult(string desc, int result)
        {
            Console.WriteLine(desc + ": " + result);
        }

        static void WriteResult(string desc, float result)
        {
            Console.WriteLine($"{desc}: {result:F2}"); // new style! :)
        }

        static void WriteResult(string desc, string result)
        {
            Console.WriteLine($"{desc}: {result}"); // new style! :)
        }
    }
}
