
namespace ZedGraphSample
{
	partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.button1 = new System.Windows.Forms.Button();
            this.kOtrazh = new System.Windows.Forms.Label();
            this.Kprop = new System.Windows.Forms.Label();
            this.dEtalona = new System.Windows.Forms.Label();
            this.wave = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.graph1 = new System.Windows.Forms.Button();
            this.graph3 = new System.Windows.Forms.Button();
            this.graph2 = new System.Windows.Forms.Button();
            this.prelomleni = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zg1
            // 
            this.zg1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.zg1.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.zg1.ForeColor = System.Drawing.Color.Aquamarine;
            this.zg1.Location = new System.Drawing.Point(14, 14);
            this.zg1.Margin = new System.Windows.Forms.Padding(5);
            this.zg1.Name = "zg1";
            this.zg1.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zg1.ScrollGrace = 0D;
            this.zg1.ScrollMaxX = 0D;
            this.zg1.ScrollMaxY = 0D;
            this.zg1.ScrollMaxY2 = 0D;
            this.zg1.ScrollMinX = 0D;
            this.zg1.ScrollMinY = 0D;
            this.zg1.ScrollMinY2 = 0D;
            this.zg1.Size = new System.Drawing.Size(500, 300);
            this.zg1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // kOtrazh
            // 
            this.kOtrazh.AutoSize = true;
            this.kOtrazh.Location = new System.Drawing.Point(20, 18);
            this.kOtrazh.Name = "kOtrazh";
            this.kOtrazh.Size = new System.Drawing.Size(28, 17);
            this.kOtrazh.TabIndex = 4;
            this.kOtrazh.Text = "t = ";
            // 
            // Kprop
            // 
            this.Kprop.AutoSize = true;
            this.Kprop.Location = new System.Drawing.Point(19, 1);
            this.Kprop.Name = "Kprop";
            this.Kprop.Size = new System.Drawing.Size(29, 17);
            this.Kprop.TabIndex = 5;
            this.Kprop.Text = "r = ";
            // 
            // dEtalona
            // 
            this.dEtalona.AutoSize = true;
            this.dEtalona.Location = new System.Drawing.Point(16, 34);
            this.dEtalona.Name = "dEtalona";
            this.dEtalona.Size = new System.Drawing.Size(40, 17);
            this.dEtalona.TabIndex = 8;
            this.dEtalona.Text = "L1 = ";
            // 
            // wave
            // 
            this.wave.AutoSize = true;
            this.wave.Location = new System.Drawing.Point(17, 51);
            this.wave.Name = "wave";
            this.wave.Size = new System.Drawing.Size(31, 17);
            this.wave.TabIndex = 9;
            this.wave.Text = "λ = ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Controls.Add(this.graph1);
            this.panel1.Controls.Add(this.graph3);
            this.panel1.Controls.Add(this.graph2);
            this.panel1.Controls.Add(this.prelomleni);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.wave);
            this.panel1.Controls.Add(this.dEtalona);
            this.panel1.Controls.Add(this.Kprop);
            this.panel1.Controls.Add(this.kOtrazh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 367);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 86);
            this.panel1.TabIndex = 15;
            // 
            // graph1
            // 
            this.graph1.Location = new System.Drawing.Point(118, 18);
            this.graph1.Name = "graph1";
            this.graph1.Size = new System.Drawing.Size(82, 65);
            this.graph1.TabIndex = 18;
            this.graph1.Text = "эталон 1";
            this.graph1.UseVisualStyleBackColor = true;
            this.graph1.Click += new System.EventHandler(this.button2_Click);
            // 
            // graph3
            // 
            this.graph3.Location = new System.Drawing.Point(294, 18);
            this.graph3.Name = "graph3";
            this.graph3.Size = new System.Drawing.Size(82, 65);
            this.graph3.TabIndex = 17;
            this.graph3.Text = "добавить эталон L*3";
            this.graph3.UseVisualStyleBackColor = true;
            this.graph3.Click += new System.EventHandler(this.graph3_Click);
            // 
            // graph2
            // 
            this.graph2.Location = new System.Drawing.Point(206, 18);
            this.graph2.Name = "graph2";
            this.graph2.Size = new System.Drawing.Size(82, 65);
            this.graph2.TabIndex = 16;
            this.graph2.Text = "добавить эталон L*2";
            this.graph2.UseVisualStyleBackColor = true;
            this.graph2.Click += new System.EventHandler(this.graph2_Click_1);
            // 
            // prelomleni
            // 
            this.prelomleni.AutoSize = true;
            this.prelomleni.Location = new System.Drawing.Point(16, 68);
            this.prelomleni.Name = "prelomleni";
            this.prelomleni.Size = new System.Drawing.Size(32, 17);
            this.prelomleni.TabIndex = 15;
            this.prelomleni.Text = "n = ";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aquamarine;
            this.ClientSize = new System.Drawing.Size(538, 453);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.zg1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Resize += new System.EventHandler(this.Form2_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		public ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label kOtrazh;
        private System.Windows.Forms.Label Kprop;
        private System.Windows.Forms.Label dEtalona;
        private System.Windows.Forms.Label wave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label prelomleni;
        private System.Windows.Forms.Button graph2;
        private System.Windows.Forms.Button graph3;
        private System.Windows.Forms.Button graph1;
    }
}