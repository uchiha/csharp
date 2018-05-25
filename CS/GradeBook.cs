using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS
{
    public class GradeBook : GradeTracker
    {
        protected List<float> grades;

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }

        // used to be "virtual" but since we implemented GradeTracker
        // need to be "override" to avoid error that this class didn't
        // implement this method.
        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
            
        }

        public GradeBook()
        {
            _name = "Empty!!";
            grades = new List<float>();
        }

        // used to be "virtual" but since we implemented GradeTracker
        // need to be "override" to avoid error that this class didn't
        // implement this method.
        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        // used to be "virtual" but since we implemented GradeTracker
        // need to be "override" to avoid error that this class didn't
        // implement this method.
        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("@GradeBook::ComputeStatistics");
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
