using System;
using Algorithms.CTCI.Hard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Hard
{
    [TestClass]
    public class HardTests
    {
        [TestMethod]
        public void ex_17_1()
        {
            var ex = new ex_17_1();
            int res = ex.AddWithoutArithmetic(75, 15);
            Assert.AreEqual(90, res);
        }
    }
}
