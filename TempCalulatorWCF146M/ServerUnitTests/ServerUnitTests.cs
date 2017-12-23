using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfMathLibrary;
using Array3DLibrary;

namespace ServerUnitTests
{
    [TestClass]
    public class ServerUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "Stability condition is not met!")]
        public void TestNonStability()
        {
            Service1 serv = new Service1();
            serv.CalcNewT(new double[2, 2] { { 0, 0 }, { 0, 0 } }, 1, 0.01, 0.1, 2);
        }

        [TestMethod]
        public void testNoExceptions()
        {
            Service1 serv = new Service1();
            try
            {
                double [,] U = serv.CalcNewT(new double[3, 4] { { 0, 0, 0, 0 },
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
            Service1 serv = new Service1();
            try
            {
                Array3D<double> u = new Array3D<double>(3, 3, 3);
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        for (int k = 0; k < 3; k++)
                            u[i, j, k] = 1;
                Array3D<double> U = serv.CalcNewT3D(u, 1, 0.1, 0.001, 10);
            }
            catch (Exception e)
            {
                Assert.Fail("Expected no exception, but got: " + e.Message);
            }
        }

        [TestMethod]
        public void testNoExceptionsN3D()
        {
            Service1 serv = new Service1();
            try
            {
                Array3D<double> u = new Array3D<double>(3, 3, 3);
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        for (int k = 0; k < 3; k++)
                            u[i, j, k] = 1;
                Array3D<double> U = serv.CalcNewTN3D(u, 30, 0.4, 0.001, 10);
            }
            catch (Exception e)
            {
                Assert.Fail("Expected no exception, but got: " + e.Message);
            }
        }

    }
}
