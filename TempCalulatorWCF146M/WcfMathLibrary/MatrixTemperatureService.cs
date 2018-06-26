namespace WcfMathLibrary
{
    using System;
    using Array3DLibrary;
    using Matrix;
    using Interfaces;
    using Temperature;
    using global::Matrix;

    public class MatrixTemperatureService : IService
    {
        OutputForTemp IService.CalculateTemp(InputForTemp input)
        {
            OutputForTemp result = new OutputForTemp();
            try
            {
                double[,] u = Utils.ToMultiD(input.U);
                u = NewMathLib.HeatFlow.CalcNewT(u, input.C, input.H, input.Tau, input.TimeSteps);
                result.U = Utils.ToJagged(u);
                result.OutputMessage = "Calculations are correct";
            }
            catch (Exception e)
            {
                result.OutputMessage = e.Message.ToString();
            }
            return result;
        }

        OutputForTemp3D IService.CalculateTemp3D(InputForTemp3D input)
        {
            OutputForTemp3D result = new OutputForTemp3D();
            result.U = new Array3D<double>(input.U.XLength, input.U.YLength, input.U.ZLength);
            try
            {
                Array3D<double> u = input.U;
                u = NewMathLib.HeatFlow.CalcNewT3D(u, input.C, input.H, input.Tau, input.TimeSteps);
                result.U = u;
                result.OutputMessage = "Calculations are correct";
            }
            catch (Exception e)
            {
                result.OutputMessage = e.Message.ToString();
            }
            return result;
        }

        OutputForTemp1D IService.CalculateTemp1D(InputForTemp1D input1D)
        {
            OutputForTemp1D result = new OutputForTemp1D();

            try
            {
                result.U = NewMathLib.HeatFlow.CalcNewT1D(input1D.U, input1D.C, input1D.H, input1D.Tau, input1D.TimeSteps);
                result.OutputMessage = "Calculations are correct";
            }
            catch (Exception e)
            {
                result.OutputMessage = e.Message.ToString();
            }

            return result;
        }

        MatrixOutput IService.MatrixSum(MatrixInput Input)
        {
            MatrixT<int> A = new MatrixT<int>(new int[Input.matrix1[0].Length, Input.matrix1[1].Length]);
            MatrixT<int> B = new MatrixT<int>(new int[Input.matrix2[0].Length, Input.matrix2[1].Length]);
            for (int i = 0; i < Input.matrix1[0].Length; i++)
            {
                for (int j = 0; j < Input.matrix1[1].Length; j++)
                {
                    A[i, j] = Input.matrix1[i][j];
                }
            }
            for (int i = 0; i < Input.matrix2[0].Length; i++)
            {
                for (int j = 0; j < Input.matrix2[1].Length; j++)
                {
                    B[i, j] = Input.matrix2[i][j];
                }
            }

            MatrixT<int> MatResult = A + B;
            MatrixOutput result = new MatrixOutput();
            result.matrixResult = new int[Input.matrix1[0].Length][];
            for (int i = 0; i < Input.matrix1[1].Length; i++)
            {
                result.matrixResult[i] = new int[Input.matrix1[0].Length];
            }
            int[][] ansArr = new int[Input.matrix1[0].Length][];
            for (int i = 0; i < Input.matrix1[1].Length; i++)
            {
                ansArr[i] = new int[Input.matrix1[0].Length];
            }

            for (int i = 0; i < Input.matrix1[0].Length; i++)
            {
                for (int j = 0; j < Input.matrix1[1].Length; j++)
                {
                    ansArr[i][j] = MatResult[i, j];
                }
            }
            result.matrixResult = ansArr;
            return result;
        }

        MatrixOutput IService.MatrixMul(MatrixInput Input)
        {
            MatrixT<int> A = new MatrixT<int>(new int[Input.matrix1[0].Length, Input.matrix1[1].Length]);
            MatrixT<int> B = new MatrixT<int>(new int[Input.matrix2[0].Length, Input.matrix2[1].Length]);
            for (int i = 0; i < Input.matrix1[0].Length; i++)
            {
                for (int j = 0; j < Input.matrix1[1].Length; j++)
                {
                    A[i, j] = Input.matrix1[i][j];
                }

            }
            for (int i = 0; i < Input.matrix2[0].Length; i++)
            {
                for (int j = 0; j < Input.matrix2[1].Length; j++)
                {
                    B[i, j] = Input.matrix2[i][j];
                }

            }

            MatrixT<int> MatResult = A * B;
            MatrixOutput result = new MatrixOutput();
            result.matrixResult = new int[Input.matrix1[0].Length][];
            for (int i = 0; i < Input.matrix1[1].Length; i++)
            {
                result.matrixResult[i] = new int[Input.matrix1[0].Length];
            }

            for (int i = 0; i < Input.matrix1[0].Length; i++)
            {
                for (int j = 0; j < Input.matrix1[1].Length; j++)
                {
                    result.matrixResult[i][j] = MatResult[i, j];
                }

            }

            return result;
        }
    }
}
