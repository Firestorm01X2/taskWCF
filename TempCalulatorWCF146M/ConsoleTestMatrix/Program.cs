namespace ConsoleTestMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WcfMathLibrary;
    using Matrix;
    using ConsoleTestMatrix.ServiceReference1;
    using WcfMathLibrary.Matrix;

    class Program
    {
        static void Main(string[] args)
        {
            MatrixInput input = new MatrixInput();
            input.matrix1 = new int[2][];
            for (int i = 0; i < 2; i++)
            {
                input.matrix1[i] = new int[2];
            }

            input.matrix2 = new int[2][];
            for (int i = 0; i < 2; i++)
            {
                input.matrix2[i] = new int[2];
            }

            for (int i = 0; i < input.matrix1[0].Length; i++)
            {
                for (int j = 0; j < input.matrix1[0].Length; j++)
                {
                    input.matrix1[i][j] = 1;
                    input.matrix2[i][j] = 2;
                }

            }

            ServiceClient client = new ServiceClient();
            MatrixOutput output = client.MatrixMul(input);
            Console.WriteLine("Исходные матрицы:");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(input.matrix1[i][j]);
                }

                Console.WriteLine();
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(input.matrix2[i][j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine("Ответ:");
            int[][] otv = output.matrixResult;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(otv[i][j]);
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
