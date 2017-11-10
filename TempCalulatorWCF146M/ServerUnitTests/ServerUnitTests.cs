using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfMathLibrary;

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
    }
}
