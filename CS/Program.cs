using System;
using System.Collections.Generic;
using System.IO;
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
            GradeBook book = CreateThrowAwayGradeBook();

            //GetBookName(book);
            AddGradesToBook(book);
            SaveGrades(book);
            WriteResults(book);

        }

        private static ThrowAwayGradeBook CreateThrowAwayGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(GradeBook book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(GradeBook book)
        {
            //File.CreateText() returns something 
            //of type StreamWriter. Note that StreamWriter
            //is a type of TextWriter. This action will create
            //a file Grades.txt in the bin folder where the
            //assembly lives.
            //Something happened here that we are writing something
            //to the stream. Be careful on streams, weather File or 
            //Network stream. Streams has the tendency to buffer any
            //information you write into them. IF YOU DONT flush, close
            //or dispose of that stream, there is a chance the program
            //can exit without the information arriving in the intended destination.
            //that is what outputFile.Close() is for.

            /*
             * this approach works, but for streams, using keyword can be used too!
            StreamWriter outputFile = null;
            try
            {
                outputFile = File.CreateText("Grades.txt");
                book.WriteGrades(outputFile);
            }
            finally
            {
                outputFile.Close();
            }
            */

            //this stuff does not even need the close method
            //it will take care on its own because using handles streams.
            using (StreamWriter outputFile = File.CreateText("Grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void AddGradesToBook(GradeBook book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(GradeBook book)
        {
            book.NameChanged += OnNameChange;
            try
            {
                Console.WriteLine("Write a book name: ");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
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
            Console.WriteLine($"{desc}: {result:F2}");
        }

        static void WriteResult(string desc, string result)
        {
            Console.WriteLine($"{desc}: {result}"); // new style! :)
        }
    }
}
