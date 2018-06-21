using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {

        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();
        }

        private List<float> grades;
        private String _name;

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

        public void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
        }
        public event NameChangedDelegate NameChanged;

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
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;

            }
            stats.AverageGrade = (sum / grades.Count);


            return stats;

        }
    }
}

