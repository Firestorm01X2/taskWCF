using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using WCF_Visualization.ServiceReference1;

namespace WCF_Visualization
{
    //public class BufferedPanel : Panel
    //{
    //    public BufferedPanel()
    //    {
    //        DoubleBuffered = true;
    //    }
    //}
    public partial class Form1 : Form
    {
        myPanel panel1;

        private double[][] U;
        private double G1;
        private double G2;
        private double G3;
        private double G4;
        private double size;
        private double H;
        private double Tau;
        private double A;
        private int Freq;
        private double time = 0;

        #region Default parameters
        private double Default_left = 0;
        private double Default_right = 0;
        private double Default_top = 100;
        private double Default_bottom = 100;

        private double Default_size = 2;
        private double Default_step = 0.08;
        private double Default_tau = 0.001;
        private double Default_a = 1.0;
        private int Default_freq = 5;
        #endregion

        private void SaveDefault()
        {
            Properties.Settings.Default.Left = Default_left;
            Properties.Settings.Default.Right = Default_right;
            Properties.Settings.Default.Top = Default_top;
            Properties.Settings.Default.Bottom = Default_bottom;

            Properties.Settings.Default.Size = Default_size;
            Properties.Settings.Default.Step = Default_step;
            Properties.Settings.Default.Tau = Default_tau;
            Properties.Settings.Default.a = Default_a;
            Properties.Settings.Default.Freq = Default_freq;

            Properties.Settings.Default.Save();
        }

        public Form1()
        {
            InitializeComponent();

            panel1 = new myPanel();
            panel1.Width = 580;
            panel1.Height = 580;
            panel1.Location = new Point(0, 0);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            panel1.Visible = true;
            this.Controls.Add(panel1);
            
            //panel1.Show();           
        }
        class myPanel : Panel { public myPanel() { this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true); } }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                textBoxLeft.Text = Properties.Settings.Default.Left.ToString();
                textBoxRight.Text = Properties.Settings.Default.Right.ToString();
                textBoxTop.Text = Properties.Settings.Default.Top.ToString();
                textBoxBottom.Text = Properties.Settings.Default.Bottom.ToString();

                textBoxSize.Text = Properties.Settings.Default.Size.ToString();
                textBoxH.Text = Properties.Settings.Default.Step.ToString();
                textBoxTau.Text = Properties.Settings.Default.Tau.ToString();
                textBoxA.Text = Properties.Settings.Default.a.ToString();
                textBoxFreq.Text = Properties.Settings.Default.Freq.ToString();

                panel1.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Чтение сохраненных параметров завершилось с ошибкой: " + ex.Message.ToString());
            }

            CheckCondition();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.Left = Convert.ToDouble(textBoxLeft.Text);
                Properties.Settings.Default.Right = Convert.ToDouble(textBoxRight.Text);
                Properties.Settings.Default.Top = Convert.ToDouble(textBoxTop.Text);
                Properties.Settings.Default.Bottom = Convert.ToDouble(textBoxBottom.Text);

                Properties.Settings.Default.Size = Convert.ToDouble(textBoxSize.Text);
                Properties.Settings.Default.Step = Convert.ToDouble(textBoxH.Text);
                Properties.Settings.Default.Tau = Convert.ToDouble(textBoxTau.Text);
                Properties.Settings.Default.a = Convert.ToDouble(textBoxA.Text);
                Properties.Settings.Default.Freq = Convert.ToInt32(textBoxFreq.Text);

                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            { }
        }

        private void textBoxH_TextChanged(object sender, EventArgs e)
        {
            checkState((TextBox)sender);
            CheckCondition();         
        }
        
        private void CheckCondition()
        {
            if (textBoxA.Text != "" && textBoxTau.Text != "" && textBoxH.Text != "")
            {
                double a = Convert.ToDouble(textBoxA.Text);
                double Tau = Convert.ToDouble(textBoxTau.Text);
                double H = Convert.ToDouble(textBoxH.Text);
                if (a * a * Tau / H / H < 0.25)
                {
                    labelStatus.ForeColor = Color.Green;
                    labelStatus.Text = "Статус: условие устойчивости соблюдено";
                }
                else
                {
                    labelStatus.ForeColor = Color.Red;
                    labelStatus.Text = "Статус: условие устойчивости не соблюдено";
                }
            }
            else
            {
                labelStatus.ForeColor = Color.Black;
                labelStatus.Text = "Статус: условие устойчивости не определено";
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if(textBoxLeft.Text == "" || textBoxRight.Text == "" || textBoxTop.Text == "" || textBoxBottom.Text == ""
                || textBoxSize.Text == "" || textBoxH.Text == "" || textBoxTau.Text == "" || textBoxA.Text == "" || textBoxFreq.Text == "")
            {
                MessageBox.Show("Поля не могут быть пустыми");
                return;
            }
            else if (Convert.ToDouble(textBoxSize.Text) <= 0 || Convert.ToDouble(textBoxH.Text) <= 0 || 
                Convert.ToDouble(textBoxTau.Text) <= 0 || Convert.ToDouble(textBoxFreq.Text) <= 0)
            {
                MessageBox.Show("Размер пластины, шаг по пространству, шаг по времени и частота обращения к сервису должны быть ненулевыми значениями");
                return;
            }
            else
            {
                buttonReset.Enabled = false;
                buttonStart.Enabled = false;
                buttonContinue.Enabled = false;
                buttonStop.Enabled = true;
                InitData();
                timer1.Start();
            }
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            buttonStart.Enabled = true;
            buttonContinue.Enabled = true;
            buttonStop.Enabled = false;
            buttonReset.Enabled = true;
        }
        private void textBoxLeft_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            checkState(tb);
        }
        private bool checkState(TextBox tb)
        {
            string correctString = "";
            bool allCorrect = true;
            for (int i = 0; i < tb.Text.Length; i++)
            {
                if (char.IsDigit(tb.Text[i]) || tb.Text[i] == '.' || tb.Text[i] == ',' || tb.Text[i] == '-')
                {
                    correctString += tb.Text[i];
                }
                else
                    allCorrect = false;
            }
            if (!allCorrect)
            {
                MessageBox.Show("Поля должны содержать только цифры!");
                tb.Text = correctString;
                return false;
            }
            return true;
        }
        private void InitData()
        {
            G1 = Convert.ToDouble(textBoxLeft.Text);
            G2 = Convert.ToDouble(textBoxTop.Text);
            G3 = Convert.ToDouble(textBoxRight.Text);
            G4 = Convert.ToDouble(textBoxBottom.Text);

            size = Convert.ToDouble(textBoxSize.Text);
            H = Convert.ToDouble(textBoxH.Text);
            Tau = Convert.ToDouble(textBoxTau.Text);
            A = Convert.ToDouble(textBoxA.Text);
            Freq = Convert.ToInt32(textBoxFreq.Text);

            int N = Convert.ToInt32(size / H) + 1;
            U = new double[N][];
            for(int i = 0; i < N; i++)
            {
                U[i] = new double[N];
            }

            for(int i = 1; i < N - 1; i++)
            {
                for(int j = 1; j < N - 1; j++)
                {
                    U[i][j] = 0.0;
                }
            }

            for(int i = 0; i < N; i++)
            {
                U[0][i] = G4;
                U[N - 1][i] = G2;
                U[i][0] = G1;
                U[i][N - 1] = G3;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time += Tau;
            labelTime.Text = "Time: " + time;
            panel1.Invalidate();
            this.Invalidate();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            if (!timer1.Enabled)
                return;
            Calculate();
            Drawer dr = new Drawer(U, H);
            dr.Draw(e.Graphics, (Panel)sender);
        }
        private void Calculate()
        {
            InputForTemp input = new InputForTemp();
            input.TimeSteps = Freq;
            input.C = A;
            input.Tau = Tau;
            input.H = H;
            input.U = U;

            Service1Client client = new Service1Client();
            OutputForTemp output = client.CalculateTemp(input);
            U = output.U;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            time = 0;
            labelTime.Text = "Time: " + time;
            panel1.Refresh();
            buttonReset.Enabled = false;
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            timer1.Start();
            buttonReset.Enabled = false;
            buttonStop.Enabled = true;
            buttonStart.Enabled = false;
            buttonContinue.Enabled = false;
        }
    }
}
