using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixSorting;

namespace TestStrategy
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSumAsc()
        {
            double[,] data = new double[,] { { 1, 3, 23 }, { 0, 2, 4 }, { 11, 22, 6 } };
            double[,] dataSorted = new double[,] { { 0, 2, 4 }, { 1, 3, 23 }, { 11, 22, 6 } };
            Matrix matrix = new Matrix(data);
            Matrix matrixSorted = new Matrix(dataSorted);
            matrix.SortingBubble = new SortSum();
            bool dir = true;
            matrix = matrix.Sort(dir);
            Assert.IsTrue(matrix==matrixSorted);
        }
        [TestMethod]
        public void TestSumDesc()
        {
            double[,] data = new double[,] { { 1, 3, 23 }, { 0, 2, 4 }, { 11, 22, 6 } };
            double[,] dataSorted = new double[,] { { 11, 22, 6 }, { 1, 3, 23 },  { 0, 2, 4 }};
            Matrix matrix = new Matrix(data);
            Matrix matrixSorted = new Matrix(dataSorted);
            matrix.SortingBubble = new SortSum();
            bool dir = false;
            matrix = matrix.Sort(dir);
            Assert.IsTrue(matrix == matrixSorted);
        }
        [TestMethod]
        public void TestMaxAsc()
        {
            double[,] data = new double[,] { { 1, 3, 23 }, { 0, 2, 4 }, { 11, 22, 6 } };
            double[,] dataSorted = new double[,] { { 0, 2, 4 }, { 11, 22, 6 }, { 1, 3, 23 }};
            Matrix matrix = new Matrix(data);
            Matrix matrixSorted = new Matrix(dataSorted);
            matrix.SortingBubble = new SortMax();
            bool dir = true;
            matrix = matrix.Sort(dir);
            Assert.IsTrue(matrix == matrixSorted);
        }
        [TestMethod]
        public void TestMaxDesc()
        {
            double[,] data = new double[,] { { 1, 3, 23 }, { 0, 2, 4 }, { 11, 22, 6 } };
            double[,] dataSorted = new double[,] { { 1, 3, 23 }, { 11, 22, 6 }, { 0, 2, 4 } };
            Matrix matrix = new Matrix(data);
            Matrix matrixSorted = new Matrix(dataSorted);
            matrix.SortingBubble = new SortMax();
            bool dir = false;
            matrix = matrix.Sort(dir);
            Assert.IsTrue(matrix == matrixSorted);
        }
        [TestMethod]
        public void TestMinAsc()
        {
            double[,] data = new double[,] { { 1, 3, 23 }, { 0, 2, 4 }, { 11, 22, 6 } };
            double[,] dataSorted = new double[,] { { 0, 2, 4 }, { 1, 3, 23 }, { 11, 22, 6 } };
            Matrix matrix = new Matrix(data);
            Matrix matrixSorted = new Matrix(dataSorted);
            matrix.SortingBubble = new SortMin();
            bool dir = true;
            matrix = matrix.Sort(dir);
            Assert.IsTrue(matrix == matrixSorted);
        }
        [TestMethod]
        public void TestMinDesc()
        {
            double[,] data = new double[,] { { 1, 3, 23 }, { 0, 2, 4 }, { 11, 22, 6 } };
            double[,] dataSorted = new double[,] {{ 11, 22, 6 }, { 1, 3, 23 },  { 0, 2, 4 } };
            Matrix matrix = new Matrix(data);
            Matrix matrixSorted = new Matrix(dataSorted);
            matrix.SortingBubble = new SortMin();
            bool dir = false;
            matrix = matrix.Sort(dir);
            Assert.IsTrue(matrix == matrixSorted);
        }
    }
}