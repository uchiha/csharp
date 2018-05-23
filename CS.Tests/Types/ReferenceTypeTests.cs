using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Tests.Types
{
    [TestFixture]
    class TypeTests
    {
        [Test]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            //grades = new float[5]; // this will cause the test to fail because remember that arrays in C#
                                   // are reference types. thus, it will create a new array in memory here
                                   // and will no longer point to the same array that is used in the parameter.
            grades[1] = 89.1f;
        }

        [Test]
        public void UppercaseAString()
        {
            string name = "scott";
            name = name.ToUpper(); // note that these types of methods does not modify the string we are pointing to
                            // instead they create a new string and return that string from the method. So we
                            // need to capture that by assigning a ref to that new string back in our name variable

            Assert.AreEqual("SCOTT", name);
        }

        [Test]
        public void AddDaysToADateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
            date = date.AddDays(1); // if date was not initialized here, this test will fail! :|
                                    // because AddDays will construct a new DateTime. So this assignment 
                                    // will assign that new DateTime to the one we did here.

            Assert.AreEqual(2, date.Day);
        }

        [Test]
        public void ValueTypesPassedByValue()
        {
            int x = 46;
            IncrementNumber(x);

            Assert.AreEqual(46, x);
            // it didn't become a 47, why? what happened was we took the 46 that is inside of x 
            // and that is being copied into the parameter "number" when IncrementNumber was invoked.
            // since that is a copy of that value, we can do anything in IncrementNumber and nothing will 
            // happen in the context of this method: ValueTypesPassedByValue()
        }

        private void IncrementNumber(int number)
        {
            number += 1;
        }
        [Test]
        public void ReferenceTypesPassedByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            // when this method was invoked, the value inside of book2
            // is copied into the parameter "book" of that method
            // and that value is a pointer so there is a period of time during
            // exec of this test where we have 3 variables that are pointing to 
            // the same GradeBook obj. They are book1, book2 and the parameter
            // book. And any changes that we make to the GradeBook through
            // any of those variables, they will be visible if we look through
            // that obj through any of the variables. 
            GiveBookAName(book2);

            Assert.AreEqual("A GradeBook", book1.Name);
        }

        private void GiveBookAName(GradeBook book)
        {
            book.Name = "A GradeBook";
        }

        [Test]
        public void StringComparisons()
        {
            string name1 = "Scott";
            string name2 = "scott";

            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            //bool result = String.Equals(name1, name2);  this fails
            Assert.IsTrue(result);
        }

        [Test]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1 = new GradeBook();
            g1.Name = "Scott's grade book!";
            Assert.AreNotEqual(g1.Name, g2.Name);
            //Assert.AreEqual("Scott's grade book!", g2.Name);
        }

        [Test]
        public void IntVariablesHoldAValue()
        {
            // these are value types, typically called primitives
            // it does not hold a pointer to any address in the memory
            int x1 = 100;
            int x2 = x1;

            x1 = 4;

            Assert.AreNotEqual(x1, x2);
        }
    }
}
