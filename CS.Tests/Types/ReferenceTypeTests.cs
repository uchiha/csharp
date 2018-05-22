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
        public void VariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Scott's grade book!";
            Assert.AreEqual(g1.Name, g2.Name);
            Assert.AreEqual("Scott's grade book!", g2.Name);
        }
    }
}
