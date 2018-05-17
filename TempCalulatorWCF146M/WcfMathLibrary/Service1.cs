using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using Array3DLibrary;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
using NewMathLib;
>>>>>>> parent of c3fff2d... Revert "Merge branch 'master' into KulakovNewBranch"
=======

using NewMathLib;
=======
using Matrix;
=======
>>>>>>> parent of ea36c67... Merge pull request #15 from V-vltru/AlParMatrix

>>>>>>> parent of e2e5241... Revert troubles

=======
using Matrix;

>>>>>>> parent of 0f196f6... Merge branch 'master' into AlParMatrix
=======
using Matrix;
=======
using NewMathLib;
>>>>>>> parent of abd9ab2... Merge branch 'master' into KulakovNewBranch

>>>>>>> parent of ae9877b... Merge pull request #14 from V-vltru/KulakovNewBranch
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
            result.U = new Array3D<double>(input.U.XLength, input.U.YLength, input.U.ZLength);
            try
            {
                Array3D<double> u = input.U;
                u = CalcNewT3D(u, input.C, input.H, input.Tau, input.TimeSteps);
                result.U = u;
                result.OutputMessage = "Calculations are correct";
            }
            catch (Exception e)
            {
                result.OutputMessage = e.Message.ToString();
            }
            return result;
        }

        OutputForTemp1D IService1.CalculateTemp1D(InputForTemp1D input1D)
        {
            OutputForTemp1D result = new OutputForTemp1D();

            try
            {
                result.U = this.CalcNewT1D(input1D.U, input1D.C, input1D.H, input1D.Tau, input1D.TimeSteps);
                result.OutputMessage = "Calculations are correct";
            }
            catch (Exception e)
            {
                result.OutputMessage = e.Message.ToString();
            }

            return result;
        }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
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
            double R = a * a * tau/2 / h / h;
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
            if (R >= 0.125)
            {
               // throw new Exception("Stability condition is not met!");
                return CalcNewTN3D(U, a, h, tau, steps);
            }

            int M = U.XLength;
            int N = U.YLength;
            int K = U.ZLength;
            //
            Array3D<double> UNew = new Array3D<double>(M, N, K);
            for (int i = 0; i < M; i++)// заполнение грани оХоУ и оХоУ со сдвигом ( дальняя и ближняя стенка)
            {
                for (int j = 0; j < N; j++)
                {
                    UNew[i, j, 0] = U[i, j, 0];
                    UNew[i, j, K - 1] = U[i, j, K - 1];
                }
            }
            for (int i = 0; i < M; i++)// заполнение грани оХоZ и оХоZ со сдвигом ( дно и крышка)
            {
                for (int k = 0; k < N; k++)
                {
                    UNew[i, 0, k] = U[i, 0, k];
                    UNew[i, N - 1, k] = U[i, N - 1, k];
                }
            }
            for (int j = 0; j < M; j++)// заполнение грани оYоZ и оYоZ со сдвигом ( левая и правая стенка)
            {
                for (int k = 0; k < N; k++)
                {
                    UNew[0, j, k] = U[0, j, k];
                    UNew[M - 1, j, k] = U[M - 1, j, k];
                }
            }

            int k1 = 0;
            do
            {
                for (int i = 1; i < M - 1; i++)
                {
                    for (int j = 1; j < N - 1; j++)
                    {
                        for (int k = 1; k < K - 1; k++)
                        {
                            UNew[i, j, k] = U[i, j, k] + R * (U[i + 1, j, k] + U[i - 1, j, k] + U[i, j + 1, k] + U[i, j - 1, k] + U[i, j, k + 1] + U[i, j, k - 1] - 6 * U[i, j, k]);
                        }
                    }
                }

                for (int i = 1; i < M - 1; i++)
                {
                    for (int j = 1; j < N - 1; j++)
                    {
                        for (int k = 1; k < K - 1; k++)
                        {
                            U[i, j, k] = UNew[i, j, k];
                        }
                    }
                }
                k1++;
            } while (k1 < steps);

            return U;

        }

        public double[] CalcNewT1D(double[] U, double a, double h, double tau, int steps)
        {
            double R = a * a * tau / h / h;
            if(R >= 0.5)
            {
                throw new Exception("Stability condition is not met!");
            }

            double[] UNew = new double[U.Length];
            UNew[0] = U[0];
            UNew[U.Length - 1] = U[U.Length - 1];

            int k = 0;
            do
            {
                for (int i = 1; i < U.Length - 1; i++)
                {
                    UNew[i] = U[i] + R * (U[i - 1] + U[i + 1] - 2 * U[i]);
                }

                for (int i = 1; i < U.Length - 1; i++)
                {
                    U[i] = UNew[i];
                }
                k++;
            } while (k < steps);

            return U;
        }


        public Array3D<double> ProgonkaPPM3D(double R, Array3D<double> U)
        {
            R = R / 3;
            int M = U.XLength;
            int N = U.YLength;
            int S = U.ZLength;
            Array3D<double> Unew = new Array3D<double>(M, N, S);

            for (int z = 1; z < S - 1;z++ ) //перебираем по I и Z
                for (int i = 1; i < M - 1; i++)
                {
                    double[] L = new double[N];
                    double[] K = new double[N];
                    
                    L[1] = 0;              //начальные значения прогоночных коэффициентов
                    K[1] = U[i, 0, z];
                    for (int q = 2; q < N; q++)  //вычисление прогоночных коэффициентов (прямой ход прогонки)
                    {
                        L[q] = R / (1 + 2 * R - R * L[q - 1]);
                        K[q] = ((U[i, q - 1,z] + R * K[q - 1]) / (1 + 2 * R - R * L[q - 1]));
                    }
                    for (int q = N - 2; q > 0; q--)    //вычисление температуры (обратный ход прогонки)
                    {
                        U[i, q,z] = L[q + 1] * U[i, q + 1,z] + K[q + 1];
                    }
                }

            for (int z = 1; z < S - 1; z++)
            for (int j = 1; j < N - 1; j++)
            {
                double[] L = new double[M];
                double[] K = new double[M];
                
                L[1] = 0;
                K[1] = U[0, j,z];
                for (int q = 2; q < M; q++)
                {
                    L[q] = R / (1 + 2 * R - R * L[q - 1]);
                    K[q] = ((U[q - 1, j,z] + R * K[q - 1]) / (1 + 2 * R - R * L[q - 1]));
                }
                for (int q = M - 2; q > 0; q--)
                {
                    U[q, j,z] = L[q + 1] * U[q + 1, j,z] + K[q + 1];
                }
            }

            for (int i = 1; i < M - 1; i++)
                for (int j = 1; j < N - 1; j++)
                {
                    double[] L = new double[S];
                    double[] K = new double[S];
                   
                    L[1] = 0;
                    K[1] = U[i, j, 0];
                    for (int q = 2; q < S; q++)
                    {
                        L[q] = R / (1 + 2 * R - R * L[q - 1]);
                        K[q] = ((U[i, j, q-1] + R * K[q - 1]) / (1 + 2 * R - R * L[q - 1]));
                    }
                    for (int q = M - 2; q > 0; q--)
                    {
                        U[i, j, q] = L[q + 1] * U[i, j, q+1] + K[q + 1];
                    }
                }

            return U;
        }
        public Array3D<double> CalcNewTN3D(Array3D<double> U, double a, double h, double tau, int steps)
        {
            double R = a * a * tau / h / h;
            ///
            int k = 0;
            do
            {
                U = ProgonkaPPM3D(R,U);
                k++;
            } while (k < steps);

            return U;
        }
=======
       
>>>>>>> parent of c3fff2d... Revert "Merge branch 'master' into KulakovNewBranch"
=======

=======
>>>>>>> parent of 0f196f6... Merge branch 'master' into AlParMatrix
=======
>>>>>>> parent of ae9877b... Merge pull request #14 from V-vltru/KulakovNewBranch
        MatrixTOutput IService1.MatrixSum(MatrixTInput matrixes)
        {
            MatrixT<int> MatResult = matrixes.matrix1 + matrixes.matrix2;
            MatrixTOutput result = new MatrixTOutput();
            result.matrixOut = MatResult;
            return result;
        }

        MatrixTOutput IService1.MatrixMul(MatrixTInput matrixes)
        {
            MatrixT<int> MatResult = matrixes.matrix1 * matrixes.matrix2;
            MatrixTOutput result = new MatrixTOutput();
            result.matrixOut = MatResult;
            return result;
        }

<<<<<<< HEAD
<<<<<<< HEAD
      
>>>>>>> parent of e2e5241... Revert troubles
=======
=======
>>>>>>> parent of ae9877b... Merge pull request #14 from V-vltru/KulakovNewBranch
=======
>>>>>>> parent of ea36c67... Merge pull request #15 from V-vltru/AlParMatrix
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
            double R = a * a * tau/2 / h / h;
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
            if (R >= 0.125)
            {
               // throw new Exception("Stability condition is not met!");
                return CalcNewTN3D(U, a, h, tau, steps);
            }

            int M = U.XLength;
            int N = U.YLength;
            int K = U.ZLength;
            //
            Array3D<double> UNew = new Array3D<double>(M, N, K);
            for (int i = 0; i < M; i++)// заполнение грани оХоУ и оХоУ со сдвигом ( дальняя и ближняя стенка)
            {
                for (int j = 0; j < N; j++)
                {
                    UNew[i, j, 0] = U[i, j, 0];
                    UNew[i, j, K - 1] = U[i, j, K - 1];
                }
            }
            for (int i = 0; i < M; i++)// заполнение грани оХоZ и оХоZ со сдвигом ( дно и крышка)
            {
                for (int k = 0; k < N; k++)
                {
                    UNew[i, 0, k] = U[i, 0, k];
                    UNew[i, N - 1, k] = U[i, N - 1, k];
                }
            }
            for (int j = 0; j < M; j++)// заполнение грани оYоZ и оYоZ со сдвигом ( левая и правая стенка)
            {
                for (int k = 0; k < N; k++)
                {
                    UNew[0, j, k] = U[0, j, k];
                    UNew[M - 1, j, k] = U[M - 1, j, k];
                }
            }

            int k1 = 0;
            do
            {
                for (int i = 1; i < M - 1; i++)
                {
                    for (int j = 1; j < N - 1; j++)
                    {
                        for (int k = 1; k < K - 1; k++)
                        {
                            UNew[i, j, k] = U[i, j, k] + R * (U[i + 1, j, k] + U[i - 1, j, k] + U[i, j + 1, k] + U[i, j - 1, k] + U[i, j, k + 1] + U[i, j, k - 1] - 6 * U[i, j, k]);
                        }
                    }
                }

                for (int i = 1; i < M - 1; i++)
                {
                    for (int j = 1; j < N - 1; j++)
                    {
                        for (int k = 1; k < K - 1; k++)
                        {
                            U[i, j, k] = UNew[i, j, k];
                        }
                    }
                }
                k1++;
            } while (k1 < steps);

            return U;

        }

        public double[] CalcNewT1D(double[] U, double a, double h, double tau, int steps)
        {
            double R = a * a * tau / h / h;
            if(R >= 0.5)
            {
                throw new Exception("Stability condition is not met!");
            }

            double[] UNew = new double[U.Length];
            UNew[0] = U[0];
            UNew[U.Length - 1] = U[U.Length - 1];

            int k = 0;
            do
            {
                for (int i = 1; i < U.Length - 1; i++)
                {
                    UNew[i] = U[i] + R * (U[i - 1] + U[i + 1] - 2 * U[i]);
                }

                for (int i = 1; i < U.Length - 1; i++)
                {
                    U[i] = UNew[i];
                }
                k++;
            } while (k < steps);

            return U;
        }


        public Array3D<double> ProgonkaPPM3D(double R, Array3D<double> U)
        {
            R = R / 3;
            int M = U.XLength;
            int N = U.YLength;
            int S = U.ZLength;
            Array3D<double> Unew = new Array3D<double>(M, N, S);

            for (int z = 1; z < S - 1;z++ ) //перебираем по I и Z
                for (int i = 1; i < M - 1; i++)
                {
                    double[] L = new double[N];
                    double[] K = new double[N];
                    
                    L[1] = 0;              //начальные значения прогоночных коэффициентов
                    K[1] = U[i, 0, z];
                    for (int q = 2; q < N; q++)  //вычисление прогоночных коэффициентов (прямой ход прогонки)
                    {
                        L[q] = R / (1 + 2 * R - R * L[q - 1]);
                        K[q] = ((U[i, q - 1,z] + R * K[q - 1]) / (1 + 2 * R - R * L[q - 1]));
                    }
                    for (int q = N - 2; q > 0; q--)    //вычисление температуры (обратный ход прогонки)
                    {
                        U[i, q,z] = L[q + 1] * U[i, q + 1,z] + K[q + 1];
                    }
                }

            for (int z = 1; z < S - 1; z++)
            for (int j = 1; j < N - 1; j++)
            {
                double[] L = new double[M];
                double[] K = new double[M];
                
                L[1] = 0;
                K[1] = U[0, j,z];
                for (int q = 2; q < M; q++)
                {
                    L[q] = R / (1 + 2 * R - R * L[q - 1]);
                    K[q] = ((U[q - 1, j,z] + R * K[q - 1]) / (1 + 2 * R - R * L[q - 1]));
                }
                for (int q = M - 2; q > 0; q--)
                {
                    U[q, j,z] = L[q + 1] * U[q + 1, j,z] + K[q + 1];
                }
            }

            for (int i = 1; i < M - 1; i++)
                for (int j = 1; j < N - 1; j++)
                {
                    double[] L = new double[S];
                    double[] K = new double[S];
                   
                    L[1] = 0;
                    K[1] = U[i, j, 0];
                    for (int q = 2; q < S; q++)
                    {
                        L[q] = R / (1 + 2 * R - R * L[q - 1]);
                        K[q] = ((U[i, j, q-1] + R * K[q - 1]) / (1 + 2 * R - R * L[q - 1]));
                    }
                    for (int q = M - 2; q > 0; q--)
                    {
                        U[i, j, q] = L[q + 1] * U[i, j, q+1] + K[q + 1];
                    }
                }

            return U;
        }
        public Array3D<double> CalcNewTN3D(Array3D<double> U, double a, double h, double tau, int steps)
        {
            double R = a * a * tau / h / h;
            ///
            int k = 0;
            do
            {
                U = ProgonkaPPM3D(R,U);
                k++;
            } while (k < steps);

            return U;
        }
<<<<<<< HEAD
>>>>>>> parent of 0f196f6... Merge branch 'master' into AlParMatrix
=======
>>>>>>> parent of ae9877b... Merge pull request #14 from V-vltru/KulakovNewBranch
=======
       
>>>>>>> parent of abd9ab2... Merge branch 'master' into KulakovNewBranch
    }
}
