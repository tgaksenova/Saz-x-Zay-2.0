using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SomeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int sum = 4 + 4;
            Assert.AreEqual(sum, 8);
            Assert.AreNotEqual(sum, 100);
            Assert.IsTrue(sum > 0);
            Assert.IsFalse(sum > 20);
        }
    }
}
