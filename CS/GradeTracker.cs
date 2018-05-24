using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS
{
    public abstract class GradeTracker : IGradeTracker
    {
        // we need the ability to add a new grade to a tracker.
        // but we don't know how that grade will be stored. 
        // file? list? database? Those implementation details 
        // will be left to a derived class so this method is abstract
        public abstract void AddGrade(float grade);

        // for the reason of the design, we looked at the public implementation
        // details of a gradebook and give GradeTracker all the capabilities but
        // without the implementation details. 
        // below, GradeTracker should be able to compute statistics
        public abstract GradeStatistics ComputeStatistics();

        public abstract void WriteGrades(TextWriter destination);

        // the following: Name, NameChanged and _name can be cut here
        // from GradeBook because they should not change their implementation
        // across other classes.
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

        public event NameChangedDelegate NameChanged;

        protected string _name;

    }
}
