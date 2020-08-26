using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class DPTests
    {
        [TestMethod]
        public void ex_8_1()
        {
            var ex = new Algorithms.CTCI.DynamicProgramming.ex_8_1();
            var res = ex.CountPossibleWays(4);
            Assert.AreEqual(7, res);
            var res1 = ex.CountPossibleWays(5);
            Assert.AreEqual(13, res1);
            var res2 = ex.CountPossibleWays(6);
            Assert.AreEqual(24, res2);
        }
    }
}
