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
using TempCalulatorWCF146M;

namespace WpfApp
{
    public partial class MainWindow : Window
    {

        Drawer2 _drawer;
        private double[][] Umas;
        public MainWindow()
        {
            InitializeComponent();
            _drawer = new Drawer2();
            GenArrey();
        }

        public bool Check()
        {
            double sizeP = Convert.ToDouble(tbSizeP.Text);
            double N = Convert.ToDouble(tbN.Text);
            double tau = Convert.ToDouble(tbTau.Text);
            double a = Convert.ToDouble(tba.Text);
            double h = sizeP / N;
            double R = a * a * tau / h / h;

            if (R >= 0.25)
            {
                MessageBoxResult result = MessageBox.Show("Не выполняется условие устойчивости");
                btStart.IsEnabled = true;
                return false;
            }
            return true;
        }
        private void GenArrey()
        {
            int G1 = Convert.ToInt32(tbG1.Text);
            int G2 = Convert.ToInt32(tbG2.Text);
            int G3 = Convert.ToInt32(tbG3.Text);
            int G4 = Convert.ToInt32(tbG4.Text);
            int N = Convert.ToInt32(tbN.Text);
            Umas = new double[N][];
            for (int h = 0; h < N; h++)
            {
                Umas[h] = new double[N];
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Umas[i][j] = 0.0;
                }
            }
            for (int j = 0; j < N; j++) //заполняем верхнюю границу
            {
                Umas[0][j] = G1;
            }
            for (int j = 0; j < N; j++) // заполняем нижнюю границу
            {
                Umas[N - 1][j] = G3;
            }
            for (int i = 0; i < N; i++) // заполняем правую границу
            {
                Umas[i][0] = G2;
            }
            for (int i = 0; i < N; i++) // заполняем левую границу
            {
                Umas[i][N - 1] = G4;
            }

        }


        private void timerTick(object sender, EventArgs e)
        {
           
            _drawer.DoCalculate();
            _drawer.ReDraw();
        }


        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            btStart.IsEnabled = false;
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            int T;
            double T2;
            if (!Int32.TryParse(tbSizeP.Text, out T) | !Int32.TryParse(tbN.Text, out T) | !Int32.TryParse(tbNumItt.Text, out T)
                | !Double.TryParse(tbTau.Text, out T2) | !Double.TryParse(tba.Text, out T2) | !Int32.TryParse(tbG1.Text, out T)
                | !Int32.TryParse(tbG2.Text, out T) | !Int32.TryParse(tbG3.Text, out T) | !Int32.TryParse(tbG4.Text, out T))
            {

                MessageBoxResult result = MessageBox.Show("Не тот тип данных");
                btStart.IsEnabled = true;
                return;
            }
            if (Int32.Parse(tbSizeP.Text) < 0 | Int32.Parse(tbN.Text) < 0 | Int32.Parse(tbNumItt.Text) < 0
                | Double.Parse(tbTau.Text) < 0.0 | Double.Parse(tba.Text) < 0.0)
            {

                MessageBoxResult result = MessageBox.Show("Значения должны быть положительными");
                btStart.IsEnabled = true;
                return;
            }
            int sizeP = Convert.ToInt32(tbSizeP.Text);
            int N = Convert.ToInt32(tbN.Text);
            int numItt = Convert.ToInt32(tbNumItt.Text);
            double tau = Convert.ToDouble(tbTau.Text);
            double a = Convert.ToDouble(tba.Text);
            GenArrey();
            bool Check1 = Check();
            _drawer.InitData(sizeP, a, N, numItt, tau, Umas);
            timer.Start();
            if (!Check1)
            {
                timer.Stop();
                return;
            }
            _drawer.PrepareDraw(canvas, canvas.Width, canvas.Height);
        }


        private void btStop_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Stop();
            btStart.IsEnabled = true;

        }

    }

}

