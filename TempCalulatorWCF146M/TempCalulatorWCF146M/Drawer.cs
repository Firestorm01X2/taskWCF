using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TempCalulatorWCF146M.ServiceReference1;

namespace TempCalulatorWCF146M
{

    public class Drawer
    {
        public double[][] Umas;
        public int N;
        public double H;
        public double Tau;
        public int NumItt;
        public double SizeP;

        public void InitData(double sizeP, int n, int numItt, double tau, double [][]umas)
        {
            SizeP = sizeP; 
            N = n;
            NumItt = numItt;
            Tau = tau;
            Umas = umas;
            H = SizeP / N;
        }
        public void Draw(Graphics g, int Widht, int Height)
        {
            Widht = 500;
            Height = 500;
            int D = Widht / N;
            //Random rnd = new Random();
            //Umas = new double[N][];
            //for (int h = 0; h < N; h++)
            //{
            //    Umas[h] = new double[N];
            //}
            //for (int i = 0; i < N; i++)
            //{
            //    for (int j = 0; j < N; j++)
            //    {
            //        Umas[i][j] = rnd.Next(0, 10);
            //    }

            //}//(((Umas[i][j]-MinU)*(255))/(MaxU-MinU))
            
            double MaxU = Umas.SelectMany(y => y).Max();
            double MinU = Umas.SelectMany(y => y).Min();
            double Col;
            int col2;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Col = (((Umas[i][j] - MinU) * (255)) / (MaxU - MinU));
                    col2 = Convert.ToInt32(Col);
                    SolidBrush Brush = new SolidBrush(Color.FromArgb(col2,100,0));
                    Rectangle rect = new Rectangle(D * j, D * i, D, D);
                    g.FillRectangle(Brush, rect);
                    
                }

            }
        }
        public void DoCalculate()
        {
            InputForTemp input = new InputForTemp();
            input.TimeSteps = NumItt;
            input.C = 1;
            input.Tau = Tau;
            input.H = H;
            input.U = Umas;
            Service1Client client = new Service1Client();
            OutputForTemp output = client.CalculateTemp(input);
            Umas = output.U;

        }
    }
}
