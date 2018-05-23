using System;
using System.Collections.Generic;
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
                if(!String.IsNullOrEmpty(value))
                {
                    _name = value;
                }
            }
            
        }

        public GradeBook()
        {
            grades = new List<float>();
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats =  new GradeStatistics();

            float sum = 0;
            foreach(float grade in grades)
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
