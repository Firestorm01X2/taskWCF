using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfMathLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        OutputForTemp IService1.CalculateTemp(InputForTemp input)
        {
            OutputForTemp result = new OutputForTemp();
            try
            {
                double[,] u= Utils.ToMultiD(input.U);
                u = CalcNewT(u, input.C, input.H, input.Tau, input.TimeSteps);
                result.U = Utils.ToJagged(u);
                result.OutputMessage = "Calculations are correct";
            }
            catch (Exception e)
            {
                result.OutputMessage = e.Message.ToString();
            }
            return result;
        }

        public double[,] CalcNewT(double[,] U, double a, double h, double tau, int steps)
        {
            double R = a * a * tau / h / h;
            if (R >= 0.25)
            {
                throw new Exception("Stability condition is not met!");
            }

            int M = U.GetLength(0);
            int N = U.GetLength(1);
            double[,] UNew = new double[M, N];

            for (int i = 0; i < N; i++)
            {
                UNew[0, i] = U[0, i];
                UNew[M - 1, i] = U[M - 1, i];
            }
            for (int i = 0; i < M; i++)
            {
                UNew[i, 0] = U[i, 0];
                UNew[i, N - 1] = U[i, N - 1];
            }

            int k = 0;
            do
            {
                for (int i = 1; i < M - 1; i++)
                {
                    for (int j = 1; j < N - 1; j++)
                    {
                        UNew[i, j] = U[i, j] + R * (U[i + 1, j] + U[i - 1, j] + U[i, j + 1] + U[i, j - 1] - 4 * U[i, j]);
                    }
                }

                for (int i = 1; i < M - 1; i++)
                {
                    for (int j = 1; j < N - 1; j++)
                    {
                        U[i, j] = UNew[i, j];
                    }
                }

                k++;
            } while (k < steps);

            return U;
        }
    }
}
