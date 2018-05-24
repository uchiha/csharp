using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS
{
    public class GradeBook
    {
        private List<float> grades;
        private string _name; // this is something to aid the "Name" field below
                              // through the use of getters and setters

        // this field is set with getters and setters now.
        public string Name
        {
            // just returns _name
            get
            {
                return _name;
            }

            // with a logic that prevents 
            // override of values that we dont
            // want from someone consuming our class
            set
            {

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can't be null or empty!");
                }

                if (_name != value)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);
                }
                _name = value;

            }

        }

        internal void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
            
        }

        // simply add the word "event" to this delegate
        // and voila! its an event
        public event NameChangedDelegate NameChanged;

        public GradeBook()
        {
            _name = "Empty!!";
            grades = new List<float>();
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in grades)
            {
                /* this is one approach
                 * below is another, using static
                 * methods of the Math class
                if(grade > stats.HighestGrade)
                {
                    stats.HighestGrade = grade;
                }
                */
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;

            return stats;
        }
    }
}
