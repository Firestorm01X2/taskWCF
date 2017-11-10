using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WCF_Visualization
{
    class Drawer
    {
        public static double MaxU = -10000000;
        public static double MinU = -10000000;
        private double[][] u;
        private double h;
        public Drawer(double [][]U, double H)
        {
            this.U = U;
            this.H = H;
        }

        public void Draw(Graphics g, Panel panel, bool how, double maxU, double minU)
        {
            int N = U[0].Length;
            int D = Convert.ToInt32(panel.Width / N);
            int Rest = panel.Width - N * D;
            //int Rest = Convert.ToInt32(panel.Width % N);
            
            if (how == true)
            {
                if (MaxU == -10000000)
                    MaxU = maxU;
                if (MinU == -10000000)
                    MinU = minU;
                double Col;
                int col2;
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {

                        Col = (((U[i][j] - MinU) * (255)) / (MaxU - MinU));
                        col2 = Convert.ToInt32(Col);
                        SolidBrush Brush = new SolidBrush(Color.FromArgb(col2, 0, 255 - col2));
                        Rectangle rect = new Rectangle(D * j, D * i, D, D);
                        g.FillRectangle(Brush, rect);

                    }
                }
            }
            else
            {
                if (MaxU == -10000000)
                    MaxU = maxU;
                if (MinU == -10000000)
                    MinU = minU;

                double k = 8;
                double Interval = (MaxU - MinU) / k;
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        Color color;
                        if (U[i][j] < MinU + Interval)
                            color = Color.Blue;
                        else if (U[i][j] >= MinU + Interval && U[i][j] < MinU + 2 * Interval)
                            color = Color.DodgerBlue;
                        else if (U[i][j] >= MinU + 2 * Interval && U[i][j] < MinU + 3 * Interval)
                            color = Color.Aqua;
                        else if (U[i][j] >= MinU + 3 * Interval && U[i][j] < MinU + 4 * Interval)
                            color = Color.Yellow;
                        else if (U[i][j] >= MinU + 4 * Interval && U[i][j] < MinU + 5 * Interval)
                            color = Color.Gold;
                        else if (U[i][j] >= MinU + 5 * Interval && U[i][j] < MinU + 6 * Interval)
                            color = Color.Orange;
                        else if (U[i][j] >= MinU + 6 * Interval && U[i][j] < MinU + 7 * Interval)
                            color = Color.OrangeRed;
                        else
                            color = Color.Red;
                        

                        SolidBrush Brush = new SolidBrush(color);
                        Rectangle rect = new Rectangle(D * j, D * i, D, D);
                        g.FillRectangle(Brush, rect);
                    }
                }
            }
        }

        public double[][] U
        {
            get
            {
                return u;
            }

            set
            {
                u = value;
            }
        }

        public double H
        {
            get
            {
                return h;
            }

            set
            {
                h = value;
            }
        }
    }
}
