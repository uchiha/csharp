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

            // the previous syntax of book.NameChanged += new NameChangedDelegate(OnNameChanged);
            // is a little verbose. "new NameChangedDelegate()" can actually be removed and
            // below will still work and easier in the eyes. This is a legal C# code.
            book.NameChanged += OnNameChange;
            
            book.Name = "Sample!";
            book.Name = "Another change is here!";
            
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Average" , stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            

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
            //Console.WriteLine(desc + ": " + result);
            //Console.WriteLine("{0}: {1:F2}", desc, result); // the F2 denotes that we want to display the float in 2 decimal places
            //Console.WriteLine("{0}: {1}", desc, result); // formatting string style
            Console.WriteLine($"{desc}: {result:F2}"); // new style! :)
        }
    }
}
