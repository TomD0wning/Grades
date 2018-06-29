using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
        public abstract IEnumerator GetEnumerator();

        protected String _name;

        public event NameChangedDelegate NameChanged;

        public String Name
        {
            get { return _name; }


            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                if (_name != value && NameChanged != null)
                {

                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExisingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);

                }
                _name = value;

            }
        }
    }
}
