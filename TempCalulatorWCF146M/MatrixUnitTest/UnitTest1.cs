namespace MatrixUnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Matrix;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Matrix_Plus()
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
        public void TestMatrix_Mul()
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
