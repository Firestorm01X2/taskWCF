using SolveIntegralLib;
using Matrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAskieva
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSequentialRectangle()
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
        public void TestSequentialTrapeze()
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
        public void TestSequenticalSimpson()
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
        public void TestParallelRectangleMed()
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
        public void TestParallelTrapeze()
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
        public void TestParallelSimpson()
        {
            ParallelMets pm = new ParallelMets();
            double a = 1;
            double b = 10000;
            int N = 100000000;
            double ans = pm.Simpson(a, b, N, (x) => x * x);
            double expected = 333333333333;
            Assert.AreEqual(expected, ans, 1);
        }

        [TestMethod]
        public void TestMatrixSum()
        {
            MatrixT<int> MatA = new MatrixT<int>(new int[,] { { 1, 1 }, { 1, 1 } });
            MatrixT<int> MatB = new MatrixT<int>(new int[,] { { 2, 2 }, { 2, 2 } });
            MatrixT<int> Ans = MatA + MatB;
            MatrixT<int> MatC = new MatrixT<int>(new int[,] { { 3, 3 }, { 3, 3 } });
            int[,] ansArr = new int[2, 2];
            int[,] expArr = new int[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    ansArr[i, j] = Ans[i, j];
                    expArr[i, j] = 3;
                }
            }
            CollectionAssert.AreEqual(expArr, ansArr);
        }

        [TestMethod]
        public void TestMatrixMul()
        {
            MatrixT<int> MatA = new MatrixT<int>(new int[,] { { 1, 1 }, { 1, 1 } });
            MatrixT<int> MatB = new MatrixT<int>(new int[,] { { 3, 3 }, { 3, 3 } });
            MatrixT<int> Ans = MatA * MatB;
            int[,] ansArr = new int[2, 2];
            int[,] expArr = new int[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    ansArr[i, j] = Ans[i, j];
                    expArr[i, j] = 6;
                }
            }
            CollectionAssert.AreEqual(expArr, ansArr);
        }
    }
}
