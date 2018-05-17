using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Calculate
    {
        public double[,] DoCalculateProd(int A_i, int A_j, int B_k)
        {
            double[,] mat_A = new double[A_i, A_j];
            double[,] mat_B = new double[A_j, B_k];
            double[,] mat_C = new double[A_i, B_k];
            Random random = new Random();
            //заполняем матрицы рандомными числами 
            for (int i = 0; i < A_i; i++)
            {
                for (int j = 0; j < A_j; j++)
                {
                    mat_A[i, j] = random.NextDouble();
                    mat_B[j, i] = random.NextDouble();
                }
            }
            //последовательное перемножение матриц
            for (int i = 0; i < A_i; i++)
                for (int k = 0; k < A_i; k++)
                {
                    mat_C[i, k] = 0.0;
                    for (int j = 0; j < A_j; j++)
                        mat_C[i, k] += mat_A[i, j] * mat_B[j, k];
                }
            return mat_C;
        }

        public double[,] DoCalculateSum(int A_i, int A_j, int B_j, int B_k)
        {
            double[,] mat_A = new double[A_i, A_j];
            double[,] mat_B = new double[B_j, B_k];
            double[,] mat_C = new double[A_i, A_j];
            Random random = new Random();
            //заполняем матрицы рандомными числами 
            for (int i = 0; i < A_i; i++)
            {
                for (int j = 0; j < A_j; j++)
                {
                    mat_A[i, j] = random.NextDouble();
                    mat_B[i, j] = random.NextDouble();
                }
            }
            //последовательное сложение матриц
            for (int i = 0; i < A_i; i++)
                {
                    for (int j = 0; j < A_j; j++)
                        mat_C[i, j] = mat_A[i, j] + mat_B[i, j];
                }
            return mat_C;
        }
    }
}
