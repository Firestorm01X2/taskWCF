using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TempCalulatorWCF146M.ServiceReference1;

namespace TempCalulatorWCF146M
{
    //Ещё один комментарий
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
            SizeP = sizeP; // ПОМЕНЯЙ, добавить initData method для инициализации данных. 
            N = n;
            NumItt = numItt;
            Tau = tau;
            Umas = umas;
            H = SizeP / N;
            //Umas = new double[N][];
            //for (int h = 0; h < N; h++)
            //{
            //    Umas[h] = new double[N];
            //}
            //for (int i = 0; i < N; i++)
            //{
            //    for (int j = 0; j < N; j++)
            //    {
            //        Umas[i][j] = 0;
            //    }
            //}
        }
        public void Draw(Graphics g, int Widht, int Height)
        {
            Widht = 500;
            Height = 500;
            //int N = 4; // размер матрицы
            int D = Widht / N;
            Random rnd = new Random();
            Umas = new double[N][];
            for (int h = 0; h < N; h++)
            {
                Umas[h] = new double[N];
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Umas[i][j] = rnd.Next(0, 10);
                }

            }

            
            SolidBrush redBrush = new SolidBrush(Color.Red);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    SolidBrush Brush = new SolidBrush(Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));
                    Rectangle rect = new Rectangle(D * j, D * i, D, D);
                    g.FillRectangle(Brush, rect);
                    
                }


            }
        }
        public void DoCalculate()
        {
            InputForTemp input = new InputForTemp();
            
            Service1Client client = new Service1Client();
            OutputForTemp output = client.CalculateTemp(input);
        }
    }
}
