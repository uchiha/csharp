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
            
            
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello! This is the grade book program");
            
            GradeBook book = new GradeBook();

            // #3 on delegates, when we first created a book
            // we want to do this below...
            // Also a delegate can hold references to multiple methods. 
            // Thus the += here will curiously do what is shown.
            book.NameChanged += new NameChangedDelegate(OnNameChange);
            book.NameChanged += new NameChangedDelegate(OnNameChange2);
            //book.NameChanged = null;  <== this becomes an error, because it is illegal in C# to obliterate all events.
                                          //we can only add (+=) or subtract (-=)
            book.Name = "Sample!";
            book.Name = "Another change is here!";
            //both lines below wont work because we set a logic
            // to check for null and empty strings in our setters.
            book.Name = null;
            book.Name =  "";

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Average" , stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            

        }

        static void OnNameChange(string existingName, string newName)
        {
            Console.WriteLine($"Grade book changing name from {existingName} to {newName}");
        }

        static void OnNameChange2(string existingName, string newName)
        {
            Console.WriteLine("***");
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
