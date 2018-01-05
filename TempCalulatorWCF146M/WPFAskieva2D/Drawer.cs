using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFAskieva2D
{
    class Drawer
    {
        public Shape[,] Shapes { get; set; }

        public Rectangle[,] Rects { get; set; }

        public double MaxU { get; set; } = -10000000;

        public double MinU { get; set; } = 10000000;

        public double RectangleWidth { get; set; }

        public double RectangleHeight { get; set; }

        public void PreDraw(Canvas canvas, int N, double[][] U)
        {
            this.SetMaxMinU(U, N);

            this.Shapes = new Shape[N, N];
            this.Rects = new Rectangle[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Rectangle rect = new Rectangle();
                    rect.Width = canvas.ActualWidth / N;
                    rect.Height = canvas.ActualHeight / N;
                    rect.Fill = Brushes.Blue;
                    Canvas.SetLeft(rect, (rect.Width - 1) * i);
                    Canvas.SetTop(rect, (rect.Height - 1) * j);

                    canvas.Children.Add(rect);
                    this.Shapes[i, j] = rect;
                    
                }
            }

            this.RectangleWidth = canvas.ActualWidth;
            this.RectangleHeight = canvas.ActualHeight;
        }

        public void ReDraw(Canvas canvas, double[][] U, int N)
        {
            double Col;
            byte col2, col3;
            if (canvas.ActualWidth != this.RectangleWidth || canvas.ActualHeight != this.RectangleHeight)
            {
                canvas.Children.Clear();

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        Rectangle rect = new Rectangle();
                        rect.Width = canvas.ActualWidth / N;
                        rect.Height = canvas.ActualHeight / N;
                        rect.Fill = this.Shapes[i, j].Fill;
                        Canvas.SetLeft(rect, (rect.Width - 1) * i);
                        Canvas.SetTop(rect, (rect.Height - 1) * j);

                        canvas.Children.Add(rect);
                        this.Shapes[i, j] = rect;
                    }
                }

                this.RectangleWidth = canvas.ActualWidth;
                this.RectangleHeight = canvas.ActualHeight;
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Col = (((U[i][j] - MinU) * (255)) / (MaxU - MinU));
                    col2 = Convert.ToByte(Col);
                    col3 = Convert.ToByte(255 - col2);
                    Color col4 = Color.FromArgb(255, col2, 0, col3);
                    Brush br2 = new SolidColorBrush(col4);

                    Shapes[i, j].Fill = br2;
                    Shapes[i, j].Stroke = br2;
                }
            }
        }

        private void SetMaxMinU(double[][] U, int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (this.MaxU < U[i][j])
                    {
                        this.MaxU = U[i][j];
                    }

                    if (this.MinU > U[i][j])
                    {
                        this.MinU = U[i][j];
                    }
                }
            }
        }
    }
}
