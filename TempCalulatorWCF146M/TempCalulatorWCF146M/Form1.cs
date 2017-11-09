using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TempCalulatorWCF146M.ServiceReference1;

namespace TempCalulatorWCF146M
{
    public partial class Form1 : Form
    {
        private List<Point> myPts = new List<Point>();
        Drawer _drawer;
        private double[][] Umas;

        public Form1()
        {
            InitializeComponent();
             //panel1 = new MyDisplay();
            _drawer = new Drawer();
            GenArrey();
        }
        //class myPanel : Panel { public myPanel() { this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true); } }
        //public class MyDisplay : Panel
        //{
        //    public MyDisplay()
        //    {
        //        //this.DoubleBuffered = true;

        //        // or

        //        SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        //        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        //        UpdateStyles();
        //    }
        //}

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
                Umas[N-1][j] = G3;
            }
            for (int i = 0; i < N; i++) // заполняем правую границу
            {
                Umas[i][0] = G2;
            }
            for (int i = 0; i < N; i++) // заполняем левую границу
            {
                Umas[i][N-1] = G4;
            }

        }

        public bool Check()
        {
            double sizeP = Convert.ToDouble(tbSizeP.Text);
            double N = Convert.ToDouble(tbN.Text);
            double tau = Convert.ToDouble(tbTau.Text);
            double a = Convert.ToDouble(tba.Text);
            double h = sizeP / N;
            double R = a * a * tau / h / h;

            if ( R >= 0.25)
            {
                MessageBox.Show("Не выполняется условие устойчивости", "Ошибка в начальных данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btStart.Enabled = true;
                return false;
            }
            return true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           //panel1 = new MyDisplay();
           panel1.Invalidate();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (!timer1.Enabled)
                return;
            _drawer.DoCalculate();
            _drawer.Draw(e.Graphics, panel1.Width, panel1.Height);
           

        }

        private void btStart_Click(object sender, EventArgs e)
        {
            btStart.Enabled = false;
            int T;
            double T2;
            if (!Int32.TryParse(tbSizeP.Text, out T) | !Int32.TryParse(tbN.Text, out T) | !Int32.TryParse(tbNumItt.Text, out T)
                | !Double.TryParse(tbTau.Text, out T2) | !Double.TryParse(tba.Text, out T2) | !Int32.TryParse(tbG1.Text, out T)
                | !Int32.TryParse(tbG2.Text, out T) | !Int32.TryParse(tbG3.Text, out T) | !Int32.TryParse(tbG4.Text, out T))
            {
                MessageBox.Show("Не тот тип данных", "Ошибка в начальных данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btStart.Enabled = true;
                return;
            }
            if (Int32.Parse(tbSizeP.Text) < 0 | Int32.Parse(tbN.Text) <0 | Int32.Parse(tbNumItt.Text) < 0
                | Double.Parse(tbTau.Text) < 0.0 | Double.Parse(tba.Text) < 0.0 | Int32.Parse(tbG1.Text) < 0
                | Int32.Parse(tbG2.Text) < 0 | Int32.Parse(tbG3.Text) < 0 | Int32.Parse(tbG4.Text) < 0)
            {
                MessageBox.Show("Значения должны быть положительными", "Ошибка в начальных данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btStart.Enabled = true;
                return;
            }
            int sizeP = Convert.ToInt32(tbSizeP.Text);
            int N = Convert.ToInt32(tbN.Text);
            int numItt = Convert.ToInt32(tbNumItt.Text);
            double tau = Convert.ToDouble(tbTau.Text);
            double a = Convert.ToDouble(tba.Text);
            GenArrey();
            bool Check1 = Check();
            _drawer.InitData(sizeP,a, N, numItt, tau, Umas);
            timer1.Start();
            if (Check1 == false ) timer1.Stop();
             
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            
            timer1.Stop();
            panel1.Refresh();
            btStart.Enabled = true;
        }

    }
}
