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
using WPFAskieva2D.ServiceReference1;

namespace WPFAskieva2D
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double Time { get; set; } = 0;
        private double T1 { get; set; }

        private double T2 { get; set; }

        private double T3 { get; set; }

        private double T4 { get; set; }

        private double H { get; set; }

        private double Tau { get; set; }

        private double A { get; set; }

        private double Size { get; set; }

        private int N { get; set; }

        private int Frequency { get; set; }

        private double[][] U { get; set; }

        private Drawer drawer { get; set; }

        private System.Windows.Threading.DispatcherTimer timer { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.CheckStableCondition();
            this.timer = new System.Windows.Threading.DispatcherTimer();

            this.timer.Tick += new EventHandler(this.timerTick);
            this.timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            this.buttonStart.IsEnabled = false;
            this.ButtonStop.IsEnabled = true;
            this.canvas.Children.Clear();
            this.Time = 0;
            try
            {
                this.InitData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                return;
            }

            this.drawer = new Drawer();
            this.drawer.PreDraw(this.canvas, this.N, this.U);

            this.timer.Start();

        }

        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonStop.IsEnabled = false;
            this.buttonStart.IsEnabled = true;
            
            this.timer.Stop();
        }

        private void AOrTauOrH_changed(object sender, TextChangedEventArgs e)
        {
            this.CheckStableCondition();
        }

        private void CheckStableCondition()
        {
            try
            {
                labelStatus.Content = "Статус: ";
                double h = Convert.ToDouble(this.textBoxH.Text);
                double tau = Convert.ToDouble(this.textBoxTau.Text);
                double a = Convert.ToDouble(this.textBoxA.Text);
                double R = a * tau / h / h;
                if (R < 0.25)
                {
                    this.labelStatus.Foreground = Brushes.Green;
                    this.labelStatus.Content += "Условие устойчивости соблюдено!";
                }
                else
                {
                    this.labelStatus.Foreground = Brushes.Orange;
                    this.labelStatus.Content += string.Format("Условие устойчивости НЕ соблюдено! R = {0}", R);
                }
            }
            catch (NullReferenceException nullEx)
            {

            }
            catch (Exception ex)
            {
                this.labelStatus.Foreground = Brushes.Red;
                this.labelStatus.Content += string.Format("Ошибка! {0}", ex.Message);
            }
        }

        private void InitData()
        {
            this.T1 = Convert.ToDouble(this.textBoxT1.Text);
            this.T2 = Convert.ToDouble(this.textBoxT2.Text);
            this.T3 = Convert.ToDouble(this.textBoxT3.Text);
            this.T4 = Convert.ToDouble(this.textBoxT4.Text);

            this.A = Convert.ToDouble(this.textBoxA.Text);
            this.H = Convert.ToDouble(this.textBoxH.Text);
            this.Tau = Convert.ToDouble(this.textBoxTau.Text);
            this.Size = Convert.ToDouble(this.textBoxSize.Text);
            this.Frequency = Convert.ToInt32(this.textboxFreq.Text);

            this.N = Convert.ToInt32(this.Size / this.H) + 1;

            this.U = new double[this.N][];

            for (int i = 0; i < this.N; i++)
            {
                this.U[i] = new double[this.N];
            }

            for (int i = 0; i < this.N; i++)
            {
                for(int j = 0; j < this.N; j++)
                {
                    this.U[i][j] = 0.0;
                }
            }

            for (int i = 0; i < N; i++)
            {
                this.U[i][0] = this.T1;
                this.U[N - 1][i] = this.T2;
                this.U[i][N - 1] = this.T3;
                this.U[0][i] = this.T4;
            }
        }

        private void Calculate()
        {
            InputForTemp input = new InputForTemp();

            input.TimeSteps = this.Frequency;
            input.C = this.A;
            input.Tau = this.Tau;
            input.H = this.H;
            input.U = this.U;

            ServiceClient client = new ServiceClient();

            OutputForTemp output = client.CalculateTemp(input);
            this.U = output.U;
        }

        private void timerTick(object sender, EventArgs e)
        {
            this.Calculate();
            this.drawer.ReDraw(this.canvas, this.U, this.N);
            this.Time += this.Tau * this.Frequency;
            this.labelTime.Content = "Время " + this.Time;
        }
    }
}
