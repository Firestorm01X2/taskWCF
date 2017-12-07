using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TempCalulatorWCF146M.ServiceReference1;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TempCalulatorWCF146M
{

    public class Drawer2
    {
        public double[][] Umas;
        public Shape[,] Elements;
        public int N;
        public double A;
        public double H;
        public double Tau;
        public int NumItt;
        public double SizeP;

        public void InitData(double sizeP, double a, int n, int numItt, double tau, double[][] umas)
        {
            SizeP = sizeP;
            A = a;
            N = n;
            NumItt = numItt;
            Tau = tau;
            Umas = umas;
            H = SizeP / N;
        }

        public void PrepareDraw(Canvas canvas, double Widht, double Hidht)
        {
            //Widht = 500;
            //int Height = 500;
            //double D = Widht / N;


            Elements = new Shape[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Rectangle rect = new Rectangle();
                    rect.Width = canvas.Width / N;
                    rect.Height = canvas.Height / N;
                    //Color col = Color.FromArgb(0, 10, 10, 10);
                    //Brush br = new SolidColorBrush(col);
                    rect.Fill = Brushes.Blue;
                    rect.Stroke = Brushes.Red;
                    rect.StrokeThickness = 0;
                    Canvas.SetLeft(rect, rect.Width * i);
                    Canvas.SetTop(rect, rect.Height * j);

                    canvas.Children.Add(rect);
                    Elements[i, j] = rect;
                }

            }
        }
        public void ReDraw()
        {
            double Col;
            byte col2, col3;
            double minU = 0.0, maxU = 0.0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (maxU <= Umas[i][j])
                    {
                        maxU = Umas[i][j];
                    }
                }
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (minU >= Umas[i][j])
                    {
                        minU = Umas[i][j];
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Col = (((Umas[i][j] - minU) * (255)) / (maxU - minU));
                    col2 = Convert.ToByte(Col);
                    col3 = Convert.ToByte(255 - col2);
                    Color col4 = Color.FromArgb(255, col2, 0, col3);
                    Brush br2 = new SolidColorBrush(col4);
                    Elements[i, j].Fill = br2;

                }
            }
        }
        public void DoCalculate()
        {
            InputForTemp input = new InputForTemp();
            input.TimeSteps = NumItt;
            input.C = A;
            input.Tau = Tau;
            input.H = H;
            input.U = Umas;
            Service1Client client = new Service1Client();
            OutputForTemp output = client.CalculateTemp(input);
            Umas = output.U;
            string mes = output.OutputMessage;

        }
    }
}
