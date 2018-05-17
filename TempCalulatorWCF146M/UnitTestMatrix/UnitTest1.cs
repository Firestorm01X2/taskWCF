using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrix;
namespace UnitTestMatrix
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Matrix_Plus()
        {
            MatrixT<int> MatA = new MatrixT<int>(new int[,] { { 1, 1 }, { 1, 1 } });
            MatrixT<int> MatB = new MatrixT<int>(new int[,] { { 2, 2 }, { 2, 2 } });
            MatrixT<int> Ans = MatA + MatB;
            MatrixT<int> Exp = new MatrixT<int>(new int[,] { { 3, 3 }, { 3, 3 } });
            int[,] ansArr = new int[2, 2];
            int[,] expArr = new int[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    ansArr[i, j] = Ans[i,j];
                    expArr[i, j] = 3;
                }
            }
            bool expbool = ansArr.Equals(ansArr);
            Assert.AreEqual(true, expbool);
        }

        [TestMethod]
        public void Test_Matrix_Prod()
        {
            MatrixT<int> MatA = new MatrixT<int>(new int[,] { { 1, 1 }, { 1, 1 } });
            MatrixT<int> MatB = new MatrixT<int>(new int[,] { { 3, 3 }, { 3, 3 } });
            MatrixT<int> Ans = MatA * MatB;
            MatrixT<int> Exp = new MatrixT<int>(new int[,] { { 4, 4 }, { 4, 4 } });
            int[,] ansArr = new int[2, 2];
            int[,] expArr = new int[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    ansArr[i, j] = Ans[i, j];
                    expArr[i, j] = 4;
                }
            }
            bool expbool = ansArr.Equals(ansArr);
            Assert.AreEqual(true, expbool);
        }
    }
}
