using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests {


        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);


        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f ;
        }

        [TestMethod]
        public void UpperCaseAString()
        {
            string name = "tom";
            name = name.ToUpper();


            Assert.AreEqual("TOM", name);
        }

        [TestMethod]
    public void AddDaysToDateTime()
    {
            //DateTime date = DateTime.Now;
            DateTime date = new DateTime(2018,01,01);
            date = date.AddDays(1);

            Assert.AreEqual(2, date.Day);
        }   
    

        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;
            IncrementNumber(x);

            Assert.AreEqual(46, x);
        }

        private void IncrementNumber(int num)
        {
            num += 1;
        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(book2);

            Assert.AreEqual("GradeBook", book1.Name);

        }

        private void GiveBookAName(GradeBook book)
        {
            
            book.Name = "GradeBook";

        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Spiderman";
            string name2 = "spiderman";

            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void GradeBookVariblesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "John";
            Assert.AreEqual(g1.Name, g2.Name);
        }

        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;

            Assert.AreNotEqual(x1, x2);
        }
    }
}
