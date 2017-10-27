using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TempCalulatorWCF146M
{
    //Ещё один комментарий
    public class Drawer
    {
        public void Draw(Graphics g, int Widht, int Height)
        {
            int N = 4; // размер матрицы
            int D = Widht / N;
            Random rnd = new Random();
            double[][] Umas = new double[N][];
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

            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            SolidBrush redBrush = new SolidBrush(Color.Red);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (Umas[i][j] < 5)
                    {
                        Rectangle rect = new Rectangle(D * j, D * i, D, D);
                        g.FillRectangle(blueBrush, rect);
                    }
                    else
                    {
                        Rectangle rect = new Rectangle(D * j, D * i, D, D);
                        g.FillRectangle(redBrush, rect);
                    }
                }

            }
        }
    }
}
