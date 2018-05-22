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
        public void ValueTypesPassedByValue()
        {
            int x = 46;
            IncrementNumber(x);

            Assert.AreEqual(46, x);
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
