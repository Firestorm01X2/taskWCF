using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using Array3DLibrary;

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

        OutputForTemp3D IService1.CalculateTemp3D(InputForTemp3D input)
        {
            OutputForTemp3D result = new OutputForTemp3D();
            result.U=new Array3D<double>(input.U.XLength, input.U.YLength, input.U.ZLength);
            try
            {
                for (int i = 0; i < input.U.XLength; i++)
                    for (int j = 0; j < input.U.YLength; j++)
                        for (int k = 0; k < input.U.ZLength; k++)
                            result.U[i, j, k] = input.U[i, j, k] + 111;

                // u = CalcNewT3D(u, input.C, input.H, input.Tau, input.TimeSteps);

                result.OutputMessage = "Calculations are correct";
            }
            catch (Exception e)
            {
                result.OutputMessage = e.Message.ToString();
            }
            return result;
        }

        public double[,] ProgonkaPPM(double R, double[,] U)
        {
          //  double A = -R/2, B = -R/2, C = 1 +2 * R;
             int M = U.GetLength(0);
            int N = U.GetLength(1);

            for (int i = 1; i < M-1; i++)
            {
                double[] L = new double[N];
                double[] K = new double[N];
                L[1] = 0;
                K[1] = U[i, 0];
                for (int q = 2; q < M; q++)
                {
                    L[q] = R / (1 + 2 * R - R * L[q - 1]);
                    K[q] = ((U[i, q - 1] + R * K[q - 1]) / (1 + 2 * R - R * L[q - 1]));
                }
                for (int q = N - 2; q > 0; q--)
                {
                    U[i, q] = L[q + 1] * U[i, q + 1] + K[q + 1];
                }
            }

            for (int i = 1; i < N-1; i++)
            {
                double[] L = new double[N];
                double[] K = new double[N];
                L[1] = 0;
                K[1] = U[0, i];
                for (int q = 2; q < N; q++)
                {
                    L[q] = R / (1 + 2 * R - R * L[q - 1]);
                    K[q] = ((U[q-1, i] + R * K[q - 1]) / (1 + 2 * R - R * L[q-1]));
                }
                for (int q = M - 2; q > 0; q--)
                {
                    U[q, i] = L[q + 1] * U[q + 1, i] + K[q + 1];
                }
            }

                return U;
        }
        public double[,] CalcNewTN(double[,] U, double a, double h, double tau, int steps)
        {
            double R = a * a * tau / h / h;
            int M = U.GetLength(0);
            int N = U.GetLength(1);
            double[,] UNew = new double[M, N];
            ///
             int k = 0;
            do
            {
            U=ProgonkaPPM(R, U);
            k++;
           } while (k < steps);

            return U;
        }

        public double[,] CalcNewT(double[,] U, double a, double h, double tau, int steps)
        {
            double R = a * a * tau / h / h;
            if (R >= 0.25)
            {
                // throw new Exception("Stability condition is not met!");
                return CalcNewTN(U, a, h, tau, steps);
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

        public Array3D<double> CalcNewT3D(Array3D<double> U, double a, double h, double tau, int steps)
        {
            double R = a * a * tau / h / h;
            //if (R >= 0.25)
            //{
            //    // throw new Exception("Stability condition is not met!");
            //    return CalcNewTN(U, a, h, tau, steps);
            //}

            int M = U.XLength;
            int N = U.YLength;
            int K = U.ZLength;
            //
            Array3D<double> UNew = new Array3D<double>(M,N, K);

            //for (int i = 0; i < N; i++)
            //{
            //    UNew[0, i] = U[0, i];
            //    UNew[M - 1, i] = U[M - 1, i];
            //}
            //for (int i = 0; i < M; i++)
            //{
            //    UNew[i, 0] = U[i, 0];
            //    UNew[i, N - 1] = U[i, N - 1];
            //}

            //int k = 0;
            //do
            //{
            //    for (int i = 1; i < M - 1; i++)
            //    {
            //        for (int j = 1; j < N - 1; j++)
            //        {
            //            UNew[i, j] = U[i, j] + R * (U[i + 1, j] + U[i - 1, j] + U[i, j + 1] + U[i, j - 1] - 4 * U[i, j]);
            //        }
            //    }

            //    for (int i = 1; i < M - 1; i++)
            //    {
            //        for (int j = 1; j < N - 1; j++)
            //        {
            //            U[i, j] = UNew[i, j];
            //        }
            //    }

            //    k++;
            //} while (k < steps);

            return U;
        }
    }
}
