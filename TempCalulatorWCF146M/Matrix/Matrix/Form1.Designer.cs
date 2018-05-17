namespace Matrix
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvMatA = new System.Windows.Forms.DataGridView();
            this.btCalculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAstrings_i = new System.Windows.Forms.TextBox();
            this.tbAcolumns_j = new System.Windows.Forms.TextBox();
            this.tbBstrings_j = new System.Windows.Forms.TextBox();
            this.tbBcolumns_k = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chbSumorPr = new System.Windows.Forms.CheckBox();
            this.dgvMatB = new System.Windows.Forms.DataGridView();
            this.dgvMatC = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btSolve = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.rtbAns = new System.Windows.Forms.RichTextBox();
            this.chbParal = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatC)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMatA
            // 
            this.dgvMatA.AllowUserToAddRows = false;
            this.dgvMatA.AllowUserToDeleteRows = false;
            this.dgvMatA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatA.ColumnHeadersVisible = false;
            this.dgvMatA.Location = new System.Drawing.Point(15, 230);
            this.dgvMatA.Name = "dgvMatA";
            this.dgvMatA.RowHeadersVisible = false;
            this.dgvMatA.Size = new System.Drawing.Size(193, 175);
            this.dgvMatA.TabIndex = 0;
            // 
            // btCalculate
            // 
            this.btCalculate.Location = new System.Drawing.Point(12, 109);
            this.btCalculate.Name = "btCalculate";
            this.btCalculate.Size = new System.Drawing.Size(179, 37);
            this.btCalculate.TabIndex = 1;
            this.btCalculate.Text = "Сгенерировать матрицы А и В";
            this.btCalculate.UseVisualStyleBackColor = true;
            this.btCalculate.Click += new System.EventHandler(this.btCalculate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Строки:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Строки:";
            // 
            // tbAstrings_i
            // 
            this.tbAstrings_i.Location = new System.Drawing.Point(72, 54);
            this.tbAstrings_i.Name = "tbAstrings_i";
            this.tbAstrings_i.Size = new System.Drawing.Size(100, 20);
            this.tbAstrings_i.TabIndex = 4;
            this.tbAstrings_i.Text = "2";
            // 
            // tbAcolumns_j
            // 
            this.tbAcolumns_j.Location = new System.Drawing.Point(72, 83);
            this.tbAcolumns_j.Name = "tbAcolumns_j";
            this.tbAcolumns_j.Size = new System.Drawing.Size(100, 20);
            this.tbAcolumns_j.TabIndex = 5;
            this.tbAcolumns_j.Text = "2";
            // 
            // tbBstrings_j
            // 
            this.tbBstrings_j.Location = new System.Drawing.Point(282, 54);
            this.tbBstrings_j.Name = "tbBstrings_j";
            this.tbBstrings_j.Size = new System.Drawing.Size(100, 20);
            this.tbBstrings_j.TabIndex = 6;
            this.tbBstrings_j.Text = "2";
            // 
            // tbBcolumns_k
            // 
            this.tbBcolumns_k.Location = new System.Drawing.Point(282, 83);
            this.tbBcolumns_k.Name = "tbBcolumns_k";
            this.tbBcolumns_k.Size = new System.Drawing.Size(100, 20);
            this.tbBcolumns_k.TabIndex = 7;
            this.tbBcolumns_k.Text = "2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Столбцы:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Столбцы:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Размерность матрицы А";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(222, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Размерность матрицы В";
            // 
            // chbSumorPr
            // 
            this.chbSumorPr.AutoSize = true;
            this.chbSumorPr.Location = new System.Drawing.Point(225, 163);
            this.chbSumorPr.Name = "chbSumorPr";
            this.chbSumorPr.Size = new System.Drawing.Size(86, 17);
            this.chbSumorPr.TabIndex = 12;
            this.chbSumorPr.Text = "Умножение";
            this.chbSumorPr.UseVisualStyleBackColor = true;
            // 
            // dgvMatB
            // 
            this.dgvMatB.AllowUserToAddRows = false;
            this.dgvMatB.AllowUserToDeleteRows = false;
            this.dgvMatB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatB.ColumnHeadersVisible = false;
            this.dgvMatB.Location = new System.Drawing.Point(223, 230);
            this.dgvMatB.Name = "dgvMatB";
            this.dgvMatB.RowHeadersVisible = false;
            this.dgvMatB.Size = new System.Drawing.Size(193, 175);
            this.dgvMatB.TabIndex = 13;
            // 
            // dgvMatC
            // 
            this.dgvMatC.AllowUserToAddRows = false;
            this.dgvMatC.AllowUserToDeleteRows = false;
            this.dgvMatC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatC.Location = new System.Drawing.Point(15, 446);
            this.dgvMatC.Name = "dgvMatC";
            this.dgvMatC.Size = new System.Drawing.Size(193, 175);
            this.dgvMatC.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Матрица А:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(222, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Матрица В:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 419);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Матрица С:";
            // 
            // btSolve
            // 
            this.btSolve.Location = new System.Drawing.Point(12, 152);
            this.btSolve.Name = "btSolve";
            this.btSolve.Size = new System.Drawing.Size(179, 37);
            this.btSolve.TabIndex = 18;
            this.btSolve.Text = "Расчитать матрицу С";
            this.btSolve.UseVisualStyleBackColor = true;
            this.btSolve.Click += new System.EventHandler(this.btSolve_Click);
            // 
            // btSave
            // 
            this.btSave.Enabled = false;
            this.btSave.Location = new System.Drawing.Point(223, 109);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(159, 37);
            this.btSave.TabIndex = 19;
            this.btSave.Text = "Сохранить результат";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // rtbAns
            // 
            this.rtbAns.Location = new System.Drawing.Point(223, 446);
            this.rtbAns.Name = "rtbAns";
            this.rtbAns.Size = new System.Drawing.Size(193, 175);
            this.rtbAns.TabIndex = 20;
            this.rtbAns.Text = "";
            // 
            // chbParal
            // 
            this.chbParal.AutoSize = true;
            this.chbParal.Location = new System.Drawing.Point(317, 163);
            this.chbParal.Name = "chbParal";
            this.chbParal.Size = new System.Drawing.Size(110, 17);
            this.chbParal.TabIndex = 22;
            this.chbParal.Text = "Распараллелить";
            this.chbParal.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 633);
            this.Controls.Add(this.chbParal);
            this.Controls.Add(this.rtbAns);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btSolve);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvMatC);
            this.Controls.Add(this.dgvMatB);
            this.Controls.Add(this.chbSumorPr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbBcolumns_k);
            this.Controls.Add(this.tbBstrings_j);
            this.Controls.Add(this.tbAcolumns_j);
            this.Controls.Add(this.tbAstrings_i);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCalculate);
            this.Controls.Add(this.dgvMatA);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMatA;
        private System.Windows.Forms.Button btCalculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAstrings_i;
        private System.Windows.Forms.TextBox tbAcolumns_j;
        private System.Windows.Forms.TextBox tbBstrings_j;
        private System.Windows.Forms.TextBox tbBcolumns_k;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chbSumorPr;
        private System.Windows.Forms.DataGridView dgvMatB;
        private System.Windows.Forms.DataGridView dgvMatC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btSolve;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.RichTextBox rtbAns;
        private System.Windows.Forms.CheckBox chbParal;
    }
}

