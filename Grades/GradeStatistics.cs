using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeStatistics
    {

        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;


        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = float.MaxValue;

        }
    }
}
