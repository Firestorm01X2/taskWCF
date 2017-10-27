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
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _drawer = new Drawer();
        }

        private void MovePoints(List<Point> pts)
        {
            for (int i = 0; i < pts.Count; i++)
            {
                Point p = pts[i];
                pts[i] = new Point(pts[i].X + 2, pts[i].Y + 2);
            }

            this.Invalidate();
        }

        private void DrawCalc(Graphics g)
        {
            string str = "Привет GDI+";
            string nameFont = "Times New Roman";
            
            InputForTemp input = new InputForTemp();
            input.C = 10;
            input.H = 10;
            input.Tau = 10;
            input.InputMessage = str;
            Service1Client client = new Service1Client();
            OutputForTemp output = client.CalculateTemp(input);

            g.DrawString
                  (output.OutputMessage, new Font(nameFont, 20), Brushes.Green, 0, 0);

            foreach (Point p in myPts)
            {
                g.FillEllipse(Brushes.Red, p.X, p.Y, 10, 10);
            }
            Brush brush = Brushes.DarkRed;
            Pen pen = new Pen(Color.Green);
            pen.Width = 10.0f;
            //g.DrawRectangle(pen, 100, 100, 100, 100);
            //g.FillRectangle(brush, 100, 100, 100, 100);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawCalc(e.Graphics);

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ////Получение объекта Graphics через Hwnd.
            //Graphics g = Graphics.FromHwnd(this.Handle);
            ////Рисование круга 10*10 по щелчку мыши.
            //g.FillEllipse(Brushes.Red, e.X, e.Y, 10, 10);
            ////Освобождение объектов Graphics, созданных напрямую.
            //g.Dispose();

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //myPts.Add(new Point(e.X, e.Y));
           // this.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // MovePoints(myPts);
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (!timer1.Enabled)
                return;
            _drawer.Draw(e.Graphics,panel1.Width, panel1.Height);
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            panel1.Refresh();
        }
    }
}
