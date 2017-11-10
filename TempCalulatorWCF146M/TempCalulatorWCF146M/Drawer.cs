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
        public double A;
        public double H;
        public double Tau;
        public int NumItt;
        public double SizeP;

        public void InitData(double sizeP, double a, int n, int numItt, double tau, double [][]umas)
        {
            SizeP = sizeP;
            A = a;
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
            
            double minU = 0.0, maxU= 0.0;
            for(int i=0;i<N;i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if(maxU<=Umas[i][j])
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
                         minU= Umas[i][j];
                    }
                }
            }


            double Col;
            int col2;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Col = (((Umas[i][j] - minU) * (255)) / (maxU - minU));
                    col2 = Convert.ToInt32(Col);
                    SolidBrush Brush = new SolidBrush(Color.FromArgb(col2, 0, 255 - col2));
                    Rectangle rect = new Rectangle(D * j, D * i, D, D);
                    g.FillRectangle(Brush, rect);
                    
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
