namespace WindowsFormsApplication1
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
        delegate void SetTextCallback(string val);
        delegate void SetValCallback(int val);
        public void SetBar1Val(int val) {
            if (this.progressBar1.InvokeRequired)
            {
                SetValCallback d = new SetValCallback(SetBar1Val);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                progressBar1.Value = val;
            }
        }
        public void SetBar2Val(int val)
        {
            if (this.progressBar2.InvokeRequired)
            {
                SetValCallback d = new SetValCallback(SetBar2Val);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                progressBar2.Value = val;
            }
        }
        public void SetBar3Val(int val)
        {
            if (this.progressBar3.InvokeRequired)
            {
                SetValCallback d = new SetValCallback(SetBar3Val);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                progressBar3.Value = val;
            }
        }
        public void SetButtonVal(string val)
        {
            if (this.button1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetButtonVal);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                button1.Text = val;
            }
        }
        public void Setlabel3Val(string val)
        {
            if (this.progressBar1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(Setlabel3Val);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                label3.Text = val;
            }
        }
        public void Setlabel2Val(string val)
        {
            if (this.progressBar1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(Setlabel2Val);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                label2.Text = val;
            }
        }
        public void Setlabel4Val(string val)
        {
            if (this.progressBar1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(Setlabel4Val);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                label4.Text = val;
            }
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelM = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonOpenPort = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panelM.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelM
            // 
            this.panelM.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelM.Controls.Add(this.label1);
            this.panelM.Controls.Add(this.comboBox1);
            this.panelM.Controls.Add(this.buttonOpenPort);
            this.panelM.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelM.Location = new System.Drawing.Point(0, 0);
            this.panelM.Margin = new System.Windows.Forms.Padding(4);
            this.panelM.Name = "panelM";
            this.panelM.Size = new System.Drawing.Size(512, 48);
            this.panelM.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(23, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "COM порт";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.Location = new System.Drawing.Point(139, 7);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.MaxDropDownItems = 10;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(116, 32);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // buttonOpenPort
            // 
            this.buttonOpenPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOpenPort.Location = new System.Drawing.Point(264, 9);
            this.buttonOpenPort.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenPort.Name = "buttonOpenPort";
            this.buttonOpenPort.Size = new System.Drawing.Size(117, 31);
            this.buttonOpenPort.TabIndex = 5;
            this.buttonOpenPort.Tag = "1";
            this.buttonOpenPort.Text = "Відкрити";
            this.buttonOpenPort.UseVisualStyleBackColor = true;
            this.buttonOpenPort.Click += new System.EventHandler(this.buttonOpenPort_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Location = new System.Drawing.Point(453, 70);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(46, 219);
            this.panel1.TabIndex = 26;
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.progressBar1.Location = new System.Drawing.Point(12, 81);
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(342, 31);
            this.progressBar1.TabIndex = 27;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(12, 230);
            this.progressBar2.Maximum = 1000;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(342, 28);
            this.progressBar2.TabIndex = 30;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(12, 154);
            this.progressBar3.Maximum = 1000;
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(342, 27);
            this.progressBar3.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(370, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 26);
            this.label2.TabIndex = 32;
            this.label2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(370, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 26);
            this.label3.TabIndex = 33;
            this.label3.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(370, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 26);
            this.label4.TabIndex = 34;
            this.label4.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label5.Location = new System.Drawing.Point(12, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 26);
            this.label5.TabIndex = 35;
            this.label5.Text = "Lighting indoor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label6.Location = new System.Drawing.Point(12, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 26);
            this.label6.TabIndex = 36;
            this.label6.Text = "Lighting outdoor";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label7.Location = new System.Drawing.Point(12, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(287, 26);
            this.label7.TabIndex = 37;
            this.label7.Text = "Enable indoor light treshhold";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(13, 290);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 20);
            this.label8.TabIndex = 38;
            this.label8.Text = "Today\'s average:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.button1.ForeColor = System.Drawing.Color.Green;
            this.button1.Location = new System.Drawing.Point(170, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 39);
            this.button1.TabIndex = 39;
            this.button1.Text = "retrieve";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 319);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelM);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoLight";
            this.panelM.ResumeLayout(false);
            this.panelM.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        
        private System.Windows.Forms.Panel panelM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonOpenPort;
        
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
    }
}
