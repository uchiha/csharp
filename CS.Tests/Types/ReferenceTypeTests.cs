using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Tests.Types
{
    [TestFixture]
    class ReferenceTypeTests
    {
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
