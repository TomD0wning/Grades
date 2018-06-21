using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grades;



namespace Grades.Test


{
    [TestClass]
    public class GradeBookTests
    {
        public GradeBookTests()
        {
        }


        [TestMethod]
        public void ComputeHighestGrade()
        {
            GradeBook gradeBook = new GradeBook();
            gradeBook.AddGrade(10);
            gradeBook.AddGrade(90);

            GradeStatistics gradeStatistics = gradeBook.ComputeStatistics();
            Assert.AreEqual(90, gradeStatistics.HighestGrade);
        }


        [TestMethod]
        public void ComputeLowestGrade()
        {
            GradeBook gradeBook = new GradeBook();
            gradeBook.AddGrade(10);
            gradeBook.AddGrade(90);

            GradeStatistics gradeStatistics = gradeBook.ComputeStatistics();
            Assert.AreEqual(10, gradeStatistics.LowestGrade);
        }

        [TestMethod]
        public void ComputeAverageGrade()
        {
            GradeBook gradeBook = new GradeBook();
            gradeBook.AddGrade(4);
            gradeBook.AddGrade(95.2f);
            gradeBook.AddGrade(45);

            GradeStatistics gradeStatistics = gradeBook.ComputeStatistics();
            Assert.AreEqual(48.0000007, gradeStatistics.AverageGrade, 0.1);
        }

    }
}

