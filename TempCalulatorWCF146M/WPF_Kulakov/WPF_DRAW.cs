using System;

using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WPF_Kulakov.ServiceReference1;

namespace WPF_Kulakov
{
    public class WPF_draw
    {
        public int N {get; private set;}
        public double A { get; private set; }
        public double H { get; private set; }
        public double Tau { get; private set; }
        public double[][] ArrayU { get; private set; }
        public Shape[,] Square { get; private set; }
        public int Iteration { get; private set; }
        public double PlateSize { get; private set; }

        public WPF_draw()
        {
            PlateSize = 0;
            A = 0;
            N = 0;
            Iteration = 0;
            Tau = 0;
            ArrayU = null;
            H = 0;
        }

        public WPF_draw(double plateSize, double a, int n, int iteration, double tau, double[][] arrayU)
        {
            PlateSize = plateSize;
            A = a;
            N = n;
            Iteration = iteration;
            Tau = tau;
            ArrayU = arrayU;
            H = plateSize / N;
        }

        public void BeforeDraw(Canvas canvas, double width, double height)
        {
            Square = new Shape[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = canvas.Width / N;
                    rectangle.Height = canvas.Height / N;
                    rectangle.Fill = Brushes.Blue;
                    rectangle.Stroke = Brushes.Red;
                    rectangle.StrokeThickness = 0;

                    Canvas.SetLeft(rectangle, rectangle.Width * i);
                    Canvas.SetTop(rectangle, rectangle.Height * j);

                    canvas.Children.Add(rectangle);
                    Square[i, j] = rectangle;
                }

            }
        }

        public void Redraw()
        {
            double color;
            byte colorRed, colorBlue;
            double minU = 0.0;
            double maxU = 0.0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (maxU <= ArrayU[i][j])
                    {
                        maxU = ArrayU[i][j];
                    }
                }
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (minU >= ArrayU[i][j])
                    {
                        minU = ArrayU[i][j];
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    color = (((ArrayU[i][j] - minU) * (255)) / (maxU - minU));
                    colorRed = Convert.ToByte(color);
                    colorBlue = Convert.ToByte(255 - colorRed);

                    Color colorGreen = Color.FromArgb(255, colorRed, 0, colorBlue);
                    Brush brush = new SolidColorBrush(colorGreen);
                    Square[i, j].Fill = brush;

                }
            }
        }
        public void DoCalculate()
        {
            InputForTemp input = new InputForTemp();
            input.TimeSteps = Iteration;
            input.C = A;
            input.Tau = Tau;
            input.H = H;
            input.U = ArrayU;
            
            ServiceClient client = new ServiceClient();
            OutputForTemp output = client.CalculateTemp(input);
            ArrayU = output.U;
            string mes = output.OutputMessage;
        }
    }
}
