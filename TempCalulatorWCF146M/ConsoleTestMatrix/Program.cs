using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfMathLibrary;
using Matrix;
using ConsoleTestMatrix.ServiceReference1;

namespace ConsoleTestMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrixInput input = new MatrixInput();
            input.matrix1 = new MatrixT<int>(new int[,] { { 2, 2 }, { 2, 2 } });
            input.matrix2 = new MatrixT<int>(new int[,] { { 2, 2 }, { 2, 2 } });
            Service1Client client = new Service1Client();
            MatrixOutput output = client.MatrixSum(input);
            //Console.WriteLine(output.OutputMessage);
            MatrixT<int> otv = output.matrixResult;
            Console.ReadKey();
        }
    }
}
