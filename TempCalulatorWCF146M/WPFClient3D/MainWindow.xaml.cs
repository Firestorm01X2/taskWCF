using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Media3D;
using WPFClient3D.ServiceReference1;
using Array3DLibrary;
using HelixToolkit.Wpf;

namespace WPFClient3D
{
    struct Circle
    {
        public Point Poit;
        public Color color;
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double MaxU = -10000000;
        public static double MinU = 10000000;

        Array3D<Circle> circleArray;
        Array3D<double> U;
        int size;
        double H;
        double tau;
        int frequency;
        double a;
        private int MaxSize = 10;
        int realSize;
        double[] T;

        private void InitData()
        {
            T = new double[6];
            T[0] = Convert.ToDouble(textboxT1.Text);
            T[1] = Convert.ToDouble(textboxT2.Text);
            T[2] = Convert.ToDouble(textboxT3.Text);
            T[3] = Convert.ToDouble(textboxT4.Text);
            T[4] = Convert.ToDouble(textboxT5.Text);
            T[5] = Convert.ToDouble(textboxT6.Text);


            
            H = Convert.ToDouble(textboxH.Text);
            tau = Convert.ToDouble(textboxTau.Text);
            frequency = Convert.ToInt32(textboxFreq.Text);
            a = Convert.ToDouble(textboxA.Text);

            size = Convert.ToInt32(Convert.ToDouble(textboxSize.Text) / H) + 1;

            if (size > MaxSize)
                realSize = MaxSize;
            else
                realSize = size;

            U = new Array3D<double>(size, size, size);
            for(int i = 1; i < size - 1; i++)
            {
                for (int j = 1; j < size - 1; j++)
                {
                    for (int k = 1; k < size - 1; k++)
                    {
                        U[i, j, k] = 0;
                    }
                }
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    U[0, i, j] = T[0];
                    U[i, size - 1, j] = T[1];
                    U[size - 1, i, j] = T[2];
                    U[i, 0, j] = T[3];
                    U[i, j, 0] = T[4];
                    U[i, j, size - 1] = T[5];
                }
            }
        }

        private Array3D<double> GetRealValues(Array3D<double> currentArray, int realSize)
        {
            Array3D<double> result = new Array3D<double>(realSize, realSize, realSize);
            int currentSize = currentArray.XLength;

            int perNode = currentSize / realSize;
            int remains = currentSize % realSize;

            for (int i = 0; i < realSize; i++)
            {
                for (int j = 0; j < realSize; j++)
                {
                    for(int k = 0; k < realSize; k++)
                    {

                        int stI;
                        int stJ;
                        int stK;

                        int perNodeX;
                        int perNodeY;
                        int perNodeZ;

                        if (i == realSize - 1)
                        {
                            stI = i * perNode + remains;
                            perNodeX = perNode + remains;
                        }
                        else
                        {
                            stI = i * perNode;
                            perNodeX = perNode;
                        }

                        if (j == realSize - 1)
                        {
                            stJ = j * perNode + remains;
                            perNodeY = perNode + remains;
                        }
                        else
                        {
                            stJ = j * perNode;
                            perNodeY = perNode;
                        }

                        if (k == realSize - 1)
                        {
                            stK = k * perNode + remains;
                            perNodeZ = perNode + remains;
                        }
                        else
                        {
                            stK = k * perNode;
                            perNodeZ = perNode;
                        }

                        result[i, j, k] = GetAverage(currentArray, stI, stJ, stK, perNodeX, perNodeY, perNodeZ);
                    }
                }
            }
            return result;
        }

        private double GetAverage(Array3D<double> currentArray, int i, int j, int k, int perNodeX, int perNodeY, int perNodeZ)
        {
            double perX = 0;
            double perY = 0;
            double perZ = 0;

            for (int l = 0; l < perNodeX; l++)
            {
                perX += currentArray[i + l, j, k];               
            }
            perX = perX / perNodeX;

            for(int l = 0; l < perNodeY; l++)
            {
                perY += currentArray[i, j + l, k];               
            }
            perY = perY / perNodeY;

            for (int l = 0; l < perNodeZ; l++)
            {
                perZ += currentArray[i, j, k + l];
            }
            perZ = perZ / perNodeZ;

            return (perX + perY + perZ) / 3.0;
        }

        private void Calculate()
        {
            InputForTemp3D inputForTemp3D = new InputForTemp3D();
            inputForTemp3D.C = a;
            inputForTemp3D.Tau = tau;
            inputForTemp3D.H = H;
            inputForTemp3D.U = U;
            inputForTemp3D.TimeSteps = frequency;

            Service1Client client = new Service1Client();
            OutputForTemp3D output = client.CalculateTemp3D(inputForTemp3D);
            U = output.U;
        }

        private void Draw()
        {
            if (MaxU == -10000000 || MinU == -10000000)
                DefineMaxMin();
            double l = 5;
            double interval = (MaxU - MinU) / l;
            ModelArea.Children.Clear();
            Array3D<double> arrayToDraw = U;
            for (int i = 0; i < U.XLength; i++)
            {
                for (int j = 0; j < U.XLength; j++)
                {
                    for (int k = 0; k < U.XLength; k++)
                    {
                        GeometryModel3D geom;
                        var builder = new MeshBuilder(true, true);
                        var position = new Point3D(i, j, k);
                        builder.AddSphere(position, 0.25, 15, 15);
                        var visual = new ModelVisual3D();

                        if (U[i, j, k] < MinU + interval)
                            geom = new GeometryModel3D(builder.ToMesh(), Materials.Blue);
                        else if (U[i, j, k] >= MinU + interval && U[i, j, k] < MinU + 2 * interval)
                            geom = new GeometryModel3D(builder.ToMesh(), Materials.Yellow);
                        else if (U[i, j, k] >= MinU + 2 * interval && U[i, j, k] < MinU + 3 * interval)
                            geom = new GeometryModel3D(builder.ToMesh(), Materials.Gold);
                        else if (U[i, j, k] >= MinU + 3 * interval && U[i, j, k] < MinU + 4 * interval)
                            geom = new GeometryModel3D(builder.ToMesh(), Materials.Orange);
                        else
                            geom = new GeometryModel3D(builder.ToMesh(), Materials.Red);

                        
                        visual.Content = geom;
                        ModelArea.Children.Add(visual);
                    }
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            InitData();
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            Calculate();
            Draw();
        }

        private void DefineMaxMin()
        {
            for (int i = 0; i < U.XLength; i++)
            {
                for (int j = 0; j < U.YLength; j++)
                {
                    for (int k = 0; k < U.ZLength; k++)
                    {
                        if (U[i, j, k] > MaxU)
                        {
                            MaxU = U[i, j, k];
                        }
                        if (U[i, j, k] < MinU)
                        {
                            MinU = U[i, j, k];
                        }
                    }
                }
            }
        }
    }
}
