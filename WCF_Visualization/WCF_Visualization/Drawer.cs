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
        private double[][] u;
        private double h;
        public Drawer(double [][]U, double H)
        {
            this.U = U;
            this.H = H;
        }

        public void Draw(Graphics g, Panel panel)
        {
            int N = U[0].Length;
            int D = Convert.ToInt32(panel.Width / N);
            int Rest = panel.Width - N * D;
            //int Rest = Convert.ToInt32(panel.Width % N);
            double MaxU = U.SelectMany(y => y).Max();
            double MinU = U.SelectMany(y => y).Min();

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
