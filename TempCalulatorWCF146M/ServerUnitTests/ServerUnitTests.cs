namespace ServerUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Array3DLibrary;

    [TestClass]
    public class ServerUnitTests
    {
        [TestMethod]
        public void testNoExceptions()
        {
            try
            {
                double [,] U = NewMathLib.HeatFlow.CalcNewT(new double[3, 4] { { 0, 0, 0, 0 },
                                             { 1, 0, 0, 1 },
                                             { 1, 0, 0, 2} }, 1, 0.1, 0.001, 10);
            }
            catch(Exception e)
            {
                Assert.Fail("Expected no exception, but got: " + e.Message);
            }
        }
        [TestMethod]
        public void testNoExceptions3D()
        {
            
            try
            {
                Array3D<double> u = new Array3D<double>(3, 3, 3);
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        for (int k = 0; k < 3; k++)
                            u[i, j, k] = 1;
                Array3D<double> U = NewMathLib.HeatFlow.CalcNewT3D(u, 1, 0.1, 0.001, 10);
            }
            catch (Exception e)
            {
                Assert.Fail("Expected no exception, but got: " + e.Message);
            }
        }

        [TestMethod]
        public void testNoExceptionsN3D()
        {
            
            try
            {
                Array3D<double> u = new Array3D<double>(3, 3, 3);
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        for (int k = 0; k < 3; k++)
                            u[i, j, k] = 1;
                Array3D<double> U = NewMathLib.HeatFlow.CalcNewTN3D(u, 30, 0.4, 0.001, 10);
            }
            catch (Exception e)
            {
                Assert.Fail("Expected no exception, but got: " + e.Message);
            }
        }
    }
}
