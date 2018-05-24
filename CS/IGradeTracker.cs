using System.IO;

namespace CS
{
    internal interface IGradeTracker
    {
        // note that it does not make sense to add
        // access modifier details on an interface because
        // one we cant use it and two because when someone has
        // an object that implements IGradeTracker, these members has to be
        // available. Thus, hiding them makes no sense at all.
        // also, being part of an interface makes methods implicitly
        // virtual, so abstract keyword should be removed as well.
        void AddGrade(float grade);
        GradeStatistics ComputeStatistics();

        void WriteGrades(TextWriter destination);
        //string Name; //<- this will contain an error saying 
                       //that interfaces cant contain fields
                       // so {get; set;} is required
        string Name { get; set; }
        
    }
}