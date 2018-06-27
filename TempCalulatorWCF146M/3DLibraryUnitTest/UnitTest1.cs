namespace _3DLibraryUnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using Array3DLibrary;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestingGetting()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9,
                                               11, 21, 31, 41, 51, 61, 71, 81, 91,
                                               12, 22, 32, 42, 52, 62, 72, 82, 92,};

            Array3D<int> array3D = new Array3D<int>(3, 3, 3, list);

            int expected = 52;
            int actual = array3D[1, 1, 2];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestingSetting()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9,
                                               11, 21, 31, 41, 51, 61, 71, 81, 91,
                                               12, 22, 32, 42, 52, 62, 72, 82, 92,};

            Array3D<int> array3D = new Array3D<int>(3, 3, 3, list);
            int expected = 10;
            array3D[1, 1, 1] = expected;

            Assert.AreEqual(expected, array3D[1, 1, 1]);
        }
    }
}
