using System.Drawing;
using System.Windows.Forms;

namespace WCF_Visualization
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gBConditions = new System.Windows.Forms.GroupBox();
            this.textBoxFreq = new System.Windows.Forms.TextBox();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.textBoxTau = new System.Windows.Forms.TextBox();
            this.textBoxH = new System.Windows.Forms.TextBox();
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gBBoarders = new System.Windows.Forms.GroupBox();
            this.textBoxBottom = new System.Windows.Forms.TextBox();
            this.textBoxTop = new System.Windows.Forms.TextBox();
            this.textBoxRight = new System.Windows.Forms.TextBox();
            this.textBoxLeft = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelTime = new System.Windows.Forms.Label();
            this.buttonContinue = new System.Windows.Forms.Button();
            myPanel panel1 = new myPanel();
            this.gBConditions.SuspendLayout();
            this.gBBoarders.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBConditions
            // 
            this.gBConditions.Controls.Add(this.textBoxFreq);
            this.gBConditions.Controls.Add(this.textBoxA);
            this.gBConditions.Controls.Add(this.textBoxTau);
            this.gBConditions.Controls.Add(this.textBoxH);
            this.gBConditions.Controls.Add(this.textBoxSize);
            this.gBConditions.Controls.Add(this.label9);
            this.gBConditions.Controls.Add(this.label8);
            this.gBConditions.Controls.Add(this.label7);
            this.gBConditions.Controls.Add(this.label6);
            this.gBConditions.Controls.Add(this.label5);
            this.gBConditions.Location = new System.Drawing.Point(607, 167);
            this.gBConditions.Name = "gBConditions";
            this.gBConditions.Size = new System.Drawing.Size(233, 183);
            this.gBConditions.TabIndex = 1;
            this.gBConditions.TabStop = false;
            this.gBConditions.Text = "Условия";
            // 
            // textBoxFreq
            // 
            this.textBoxFreq.Location = new System.Drawing.Point(145, 132);
            this.textBoxFreq.Name = "textBoxFreq";
            this.textBoxFreq.Size = new System.Drawing.Size(82, 20);
            this.textBoxFreq.TabIndex = 9;
            this.textBoxFreq.TextChanged += new System.EventHandler(this.textBoxLeft_TextChanged);
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(145, 107);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(82, 20);
            this.textBoxA.TabIndex = 8;
            this.textBoxA.TextChanged += new System.EventHandler(this.textBoxH_TextChanged);
            // 
            // textBoxTau
            // 
            this.textBoxTau.Location = new System.Drawing.Point(145, 80);
            this.textBoxTau.Name = "textBoxTau";
            this.textBoxTau.Size = new System.Drawing.Size(82, 20);
            this.textBoxTau.TabIndex = 7;
            this.textBoxTau.TextChanged += new System.EventHandler(this.textBoxH_TextChanged);
            // 
            // textBoxH
            // 
            this.textBoxH.Location = new System.Drawing.Point(145, 54);
            this.textBoxH.Name = "textBoxH";
            this.textBoxH.Size = new System.Drawing.Size(82, 20);
            this.textBoxH.TabIndex = 6;
            this.textBoxH.TextChanged += new System.EventHandler(this.textBoxH_TextChanged);
            // 
            // textBoxSize
            // 
            this.textBoxSize.Location = new System.Drawing.Point(145, 28);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(82, 20);
            this.textBoxSize.TabIndex = 5;
            this.textBoxSize.TextChanged += new System.EventHandler(this.textBoxLeft_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Частота обр. к службе:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Коэф. теплопроводности:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Шаг по времени: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Шаг по пространству: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Размер пластины: ";
            // 
            // gBBoarders
            // 
            this.gBBoarders.Controls.Add(this.textBoxBottom);
            this.gBBoarders.Controls.Add(this.textBoxTop);
            this.gBBoarders.Controls.Add(this.textBoxRight);
            this.gBBoarders.Controls.Add(this.textBoxLeft);
            this.gBBoarders.Controls.Add(this.label4);
            this.gBBoarders.Controls.Add(this.label3);
            this.gBBoarders.Controls.Add(this.label2);
            this.gBBoarders.Controls.Add(this.label1);
            this.gBBoarders.Location = new System.Drawing.Point(607, 12);
            this.gBBoarders.Name = "gBBoarders";
            this.gBBoarders.Size = new System.Drawing.Size(233, 137);
            this.gBBoarders.TabIndex = 0;
            this.gBBoarders.TabStop = false;
            this.gBBoarders.Text = "Границы";
            // 
            // textBoxBottom
            // 
            this.textBoxBottom.Location = new System.Drawing.Point(72, 106);
            this.textBoxBottom.Name = "textBoxBottom";
            this.textBoxBottom.Size = new System.Drawing.Size(100, 20);
            this.textBoxBottom.TabIndex = 7;
            this.textBoxBottom.TextChanged += new System.EventHandler(this.textBoxLeft_TextChanged);
            // 
            // textBoxTop
            // 
            this.textBoxTop.Location = new System.Drawing.Point(72, 80);
            this.textBoxTop.Name = "textBoxTop";
            this.textBoxTop.Size = new System.Drawing.Size(100, 20);
            this.textBoxTop.TabIndex = 6;
            this.textBoxTop.TextChanged += new System.EventHandler(this.textBoxLeft_TextChanged);
            // 
            // textBoxRight
            // 
            this.textBoxRight.Location = new System.Drawing.Point(72, 54);
            this.textBoxRight.Name = "textBoxRight";
            this.textBoxRight.Size = new System.Drawing.Size(100, 20);
            this.textBoxRight.TabIndex = 5;
            this.textBoxRight.TextChanged += new System.EventHandler(this.textBoxLeft_TextChanged);
            // 
            // textBoxLeft
            // 
            this.textBoxLeft.Location = new System.Drawing.Point(72, 28);
            this.textBoxLeft.Name = "textBoxLeft";
            this.textBoxLeft.Size = new System.Drawing.Size(100, 20);
            this.textBoxLeft.TabIndex = 4;
            this.textBoxLeft.TextChanged += new System.EventHandler(this.textBoxLeft_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Bottom: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Top: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Right: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Left: ";
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(607, 356);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(110, 73);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.Location = new System.Drawing.Point(723, 356);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(117, 73);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Stop/Pause";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 607);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(47, 13);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "Статус: ";
            // 
            // buttonReset
            // 
            this.buttonReset.Enabled = false;
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(607, 509);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(233, 72);
            this.buttonReset.TabIndex = 5;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(602, 607);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(42, 13);
            this.labelTime.TabIndex = 6;
            this.labelTime.Text = "Time: 0";
            // 
            // buttonContinue
            // 
            this.buttonContinue.Enabled = false;
            this.buttonContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonContinue.Location = new System.Drawing.Point(607, 435);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(233, 68);
            this.buttonContinue.TabIndex = 7;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);

            
            panel1.Width = 580;
            panel1.Height = 580;
            panel1.Location = new Point(0, 0);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 640);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.gBBoarders);
            this.Controls.Add(this.gBConditions);
            this.Name = "Form1";
            this.Text = "Visualization";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gBConditions.ResumeLayout(false);
            this.gBConditions.PerformLayout();
            this.gBBoarders.ResumeLayout(false);
            this.gBBoarders.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gBConditions;
        private System.Windows.Forms.TextBox textBoxFreq;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.TextBox textBoxTau;
        private System.Windows.Forms.TextBox textBoxH;
        private System.Windows.Forms.TextBox textBoxSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gBBoarders;
        private System.Windows.Forms.TextBox textBoxBottom;
        private System.Windows.Forms.TextBox textBoxTop;
        private System.Windows.Forms.TextBox textBoxRight;
        private System.Windows.Forms.TextBox textBoxLeft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button buttonContinue;
    }
}

