using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolveIntegralLib;

namespace UnitTestSolveIntegralLib
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSeqRM()
        {
            SeqMeth sm = new SeqMeth();
            double a = 1;
            double b = 10000;
            int N = 10000000;
            double ans = sm.RectangleMedium(a, b, N, (x) => x * x);
            double expected = 333333333333;
            Assert.AreEqual(expected, ans, 1);
        }

        [TestMethod]
        public void TestSeqTrapeze()
        {
            SeqMeth sm = new SeqMeth();
            double a = 1;
            double b = 10000;
            int N = 10000000;
            double ans = sm.Trapeze(a, b, N, (x) => x * x);
            double expected = 333333333333;
            Assert.AreEqual(expected, ans, 1);
        }

        [TestMethod]
        public void TestSeqSimpson()
        {
            
            SeqMeth sm = new SeqMeth();
            double a = 1;
            double b = 10000;
            int N = 10000000;
            double ans = sm.Simpson(a, b, N, (x) => x * x);
            double expected = 333333333333;
            Assert.AreEqual(expected, ans, 1);
        }

        [TestMethod]
        public void TestParalRm()
        {
            ParallelMets pm = new ParallelMets();
            double a = 1;
            double b = 10000;
            int N = 10000000;
            double ans = pm.RectangleMedium(a, b, N, (x) => x * x);
            double expected = 333333333333;
            Assert.AreEqual(expected, ans, 1);
        }

        [TestMethod]
        public void TestParalTrapeze()
        {
            ParallelMets pm = new ParallelMets();
            double a = 1;
            double b = 10000;
            int N = 10000000;
            double ans = pm.Trapeze(a, b, N, (x) => x * x);
            double expected = 333333333333;
            Assert.AreEqual(expected, ans, 1);
        }

        [TestMethod]
        public void TestParalSimpson()
        {
            ParallelMets pm = new ParallelMets();
            double a = 1;
            double b = 10000;
            int N = 100000000;
            double ans = pm.Simpson(a, b, N, (x) => x * x);
            double expected = 333333333333;
            Assert.AreEqual(expected, ans, 1);
        }
    }
}
