namespace Matrix
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.IO;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public MatrixT<int> GenMat(int i, int j, Func<int, int, int> F) // генерация матрицы
        {
            Random random = new Random();
            MatrixT<int> Mat = new MatrixT<int>(new int[i, j]);
            for (int k = 0; k < i; k++)
            {
                for (int l = 0; l < j; l++)
                {
                    Mat[k, l] = F(k, l);
                }
            }
            return Mat;
        }

        public void GenGrids() // генерация таблиц
        {
            dgvMatA.Rows.Clear();
            dgvMatA.Columns.Clear();
            dgvMatB.Rows.Clear();
            dgvMatB.Columns.Clear();
            int A_i = Convert.ToInt32(tbAstrings_i.Text);
            int A_j = Convert.ToInt32(tbAcolumns_j.Text);
            int B_j = Convert.ToInt32(tbBstrings_j.Text);
            int B_k = Convert.ToInt32(tbBcolumns_k.Text);
            Random random = new Random();
            Stopwatch sw = new Stopwatch();
            MatrixT<int> MatA = GenMat(A_i, A_j, (i, j) => i + j + 1 + random.Next(0, 10));
            MatrixT<int> MatB = GenMat(B_j, B_k, (i, j) => i + j + 1 + random.Next(0, 10));
            //создаем таблицу матрицы А
            //задаем столбцы
            for (int j = 0; j < A_j; ++j)
            {
                var column = new DataGridViewColumn();
                column.HeaderText = Convert.ToString(j + 1);
                column.ReadOnly = false;
                column.CellTemplate = new DataGridViewTextBoxCell();
                dgvMatA.Columns.Add(column);
            }
            //строки
            for (int i = 0; i < A_i; ++i)
            {
                dgvMatA.Rows.Add();
            }
            //заполнение таблицы матрицы А
            for (int i = 0; i < dgvMatA.Columns.Count; i++)
            {
                for (int j = 0; j < dgvMatA.Rows.Count; j++)
                {
                    dgvMatA[i, j].Value = MatA[j, i];
                }
            }
            //создаем таблицу матрицы В
            //задаем столбцы
            for (int k = 0; k < B_k; ++k)
            {
                var column = new DataGridViewColumn();
                column.HeaderText = Convert.ToString(k + 1);
                column.ReadOnly = false;
                column.CellTemplate = new DataGridViewTextBoxCell();
                dgvMatB.Columns.Add(column);
            }
            //строки
            for (int j = 0; j < B_j; ++j)
            {
                dgvMatB.Rows.Add();
            }
            //заполнение таблицы матрицы B
            for (int j = 0; j < dgvMatB.Columns.Count; j++)
            {
                for (int k = 0; k < dgvMatB.Rows.Count; k++)
                {
                    dgvMatB[j, k].Value = MatB[k, j];
                }
            }
        }

        public void DoSolve()
        {
            dgvMatC.Rows.Clear();
            dgvMatC.Columns.Clear();
            Stopwatch sw = new Stopwatch();
            if (!chbSumorPr.Checked)
            {
                int A_i = Convert.ToInt32(tbAstrings_i.Text);
                int A_j = Convert.ToInt32(tbAcolumns_j.Text);
                MatrixT<int> MatA = new MatrixT<int>(new int[A_i, A_j]);
                for (int j = 0; j < dgvMatA.Columns.Count; j++)
                {
                    for (int i = 0; i < dgvMatA.Rows.Count; i++)
                    {
                        MatA[i, j] = Convert.ToInt32(dgvMatA[j, i].Value);
                    }
                }

                int B_j = Convert.ToInt32(tbBstrings_j.Text);
                int B_k = Convert.ToInt32(tbBcolumns_k.Text);
                MatrixT<int> MatB = new MatrixT<int>(new int[B_j, B_k]);
                for (int k = 0; k < dgvMatB.Columns.Count; k++)
                {
                    for (int j = 0; j < dgvMatB.Rows.Count; j++)
                    {
                        MatB[j, k] = Convert.ToInt32(dgvMatB[k, j].Value);
                    }
                }
                // проверка условий выполнения операции сложения
                if (!(A_i == B_j & A_j == B_k))
                {
                    MessageBox.Show("Не выполняется условие выполнения операции!");
                    return;
                }

                sw.Start();
                MatrixT<int> MatC = MatA + MatB;
                sw.Stop();
                //создаем таблицу матрицы C
                //задаем столбцы
                for (int j = 0; j < A_j; ++j)
                {
                    var column = new DataGridViewColumn();
                    column.HeaderText = Convert.ToString(j + 1);
                    column.ReadOnly = false;
                    column.CellTemplate = new DataGridViewTextBoxCell();
                    dgvMatC.Columns.Add(column);
                }
                //строки
                for (int i = 0; i < A_i; ++i)
                {
                    dgvMatC.Rows.Add();
                }
                //заполнение таблицы матрицы C
                for (int i = 0; i < dgvMatA.Columns.Count; i++)
                {
                    for (int j = 0; j < dgvMatA.Rows.Count; j++)
                    {
                        dgvMatC[i, j].Value = MatC[j, i];
                    }
                }
                rtbAns.AppendText("Время(мс):" + sw.ElapsedMilliseconds + "\n");
            }
            else
            {
                int A_i = Convert.ToInt32(tbAstrings_i.Text);
                int A_j = Convert.ToInt32(tbAcolumns_j.Text);
                MatrixT<int> MatA = new MatrixT<int>(new int[A_i, A_j]);
                for (int j = 0; j < dgvMatA.Columns.Count; j++)
                {
                    for (int i = 0; i < dgvMatA.Rows.Count; i++)
                    {
                        MatA[i, j] = Convert.ToInt32(dgvMatA[j, i].Value);
                    }
                }

                int B_j = Convert.ToInt32(tbBstrings_j.Text);
                int B_k = Convert.ToInt32(tbBcolumns_k.Text);
                MatrixT<int> MatB = new MatrixT<int>(new int[B_j, B_k]);
                for (int k = 0; k < dgvMatB.Columns.Count; k++)
                {
                    for (int j = 0; j < dgvMatB.Rows.Count; j++)
                    {
                        MatB[j, k] = Convert.ToInt32(dgvMatB[k, j].Value);
                    }
                }
                // проверка условий выполнения операции умножения
                if (!(A_j == B_j))
                {
                    MessageBox.Show("Не выполняется условие выполнения операции!");
                    return;
                }
                sw.Start();
                MatrixT<int> MatC = MatA * MatB;
                sw.Stop();
                //создаем таблицу матрицы C
                //задаем столбцы
                for (int k = 0; k < B_k; ++k)
                {
                    var column = new DataGridViewColumn();
                    column.HeaderText = Convert.ToString(k + 1);
                    column.ReadOnly = false;
                    column.CellTemplate = new DataGridViewTextBoxCell();
                    dgvMatC.Columns.Add(column);
                }
                //строки
                for (int i = 0; i < A_i; ++i)
                {
                    dgvMatC.Rows.Add();
                }
                //заполнение таблицы матрицы C
                for (int i = 0; i < dgvMatA.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvMatB.Columns.Count; j++)
                    {
                        dgvMatC[j, i].Value = MatC[i, j];
                    }
                }
                rtbAns.AppendText("Время(мс):" + sw.ElapsedMilliseconds + "\n");
            }
        }
        private void btCalculate_Click(object sender, EventArgs e)
        {
            GenGrids();
            //проверка 
        }

        private void btSolve_Click(object sender, EventArgs e)
        {
            if (chbParal.Checked)
            {
                MatrixT<int>.Paral = true;
                DoSolve();
                btSave.Enabled = true;
            }
            else
            {
                MatrixT<int>.Paral = false;
                DoSolve();
                btSave.Enabled = true;
            }
        }

        private void btSave_Click(object sender, EventArgs e) // обработчик кнопки "Сохранить"
        {
            string filePath = Path.Combine(Application.StartupPath, "SaveMatrix.csv");
            FileStream fs = new FileStream(filePath, FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fs);
            try
            {
                for (int j = 0; j < dgvMatC.Rows.Count; j++)
                {
                    for (int i = 0; i < dgvMatC.Columns.Count; i++)
                    {
                        streamWriter.Write(dgvMatC[i, j].Value + "     ");
                    }

                    streamWriter.WriteLine();
                }

                streamWriter.Close();
                fs.Close();

                MessageBox.Show("Файл успешно сохранен. \nПуть: " + Convert.ToString(Application.StartupPath));
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранении файла!");
            }
            btSave.Enabled = false;
        }
    }
}
