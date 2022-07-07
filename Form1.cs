using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace ZedGraphSample
{
	public partial class Form1 : Form
	{
		AllParam AP = new AllParam();
		List<Points> Po = new List<Points>();
		List<Points2> Po2 = new List<Points2>();
		List<Points3> Po3 = new List<Points3>();
		List<Points4> Po4 = new List<Points4>();
		List<Points5> Po5 = new List<Points5>();
		List<Points6> Po6 = new List<Points6>();

		double contrast1;
		double contrast2;
		double contrast3;
		public Form1()
		{
			
			InitializeComponent();
		}

       

        public void Form1_Load( object sender, EventArgs e )
		{
			
		}
		
		public void button1_Click(object sender, EventArgs e)
		{


			AllParam ap = new AllParam()

			
			{
				Otr1 = this.kOtr1.Text,
			//	Prop1 = this.kProp1.Text,
				Etal1 = this.dEtal1.Text,
				Wave = this.dWave.Text,
				Prel1 = this.pPrel1.Text,
				Etal2 = this.dEtal2.Text,
				Etal3 = this.dEtal3.Text
			};
			if (selectK.Checked == true)
            {
				ap.Indicator = 0;
            }
			if (selectWave.Checked == true)
            {
				ap.Indicator = 1;
            } 

			Form2 fm2 = new Form2(ap);
			
			
			//newForm.Show();
			fm2.ShowDialog();
			
		}
		 public void button3_Click(object sender, EventArgs e)
        {
			

			AllParam ap = new AllParam()
			

			{
				Otr1 = this .kOtr1.Text,
				//Prop1 = this.kProp1.Text,
				Etal1 = this.dEtal1.Text,
				Wave = this.dWave.Text,
				Prel1 = this.pPrel1.Text,
				Etal2 = this.dEtal2.Text,
				Etal3 = this.dEtal3.Text
			};
			
			AP = ap;
			MessageBox.Show("значения получены");
        }


		/*public void GetIndicator( RadioButton rdButton)
        {
			AllParam ap = new AllParam();
			if (rdButton.Checked)
			{
				ap.Indicator = 1;
			}

			else
			{
				ap.Indicator = 0;
			}
        }*/

		//рассчет r для 1-го эталона
		private void label2_Click(object sender, EventArgs e)
		{
			double n = Convert.ToDouble(pPrel1.Text);
			double r = Math.Pow((n - 1), 2) / Math.Pow((n + 1), 2);
			MessageBox.Show("Для эталона с n = " + n + " коэффициент отражения: " + Math.Round(r, 3));
		}


		//рассчет r для 2-го эталона
		private void label13_Click(object sender, EventArgs e)
		{
			double n = Convert.ToDouble(pPrel2.Text);
			double r = Math.Pow((n - 1), 2) / Math.Pow((n + 1), 2);
			MessageBox.Show("Для эталона с n = " + n + " коэффициент отражения: " + Math.Round(r, 3));
		}
		
				
		//рассчет r для 3-го эталона
		private void label12_Click(object sender, EventArgs e)
		{
			double n = Convert.ToDouble(pPrel3.Text);
			double r = Math.Pow((n - 1), 2) / Math.Pow((n + 1), 2);
			MessageBox.Show("Для эталона с n = " + n + " коэффициент отражения: " + Math.Round(r, 3));
		}
		

		//рассчет r для 4-го эталона
		private void label5_Click_1(object sender, EventArgs e)
		{
			double n = Convert.ToDouble(pPrel4.Text);
			double r = Math.Pow((n - 1), 2) / Math.Pow((n + 1), 2);
			MessageBox.Show("Для эталона с n = " + n + " коэффициент отражения: " + Math.Round(r, 3));
		}

		private void kOtrLabel5_Click(object sender, EventArgs e)
		{
			double n = Convert.ToDouble(pPrel5.Text);
			double r = Math.Pow((n - 1), 2) / Math.Pow((n + 1), 2);
			MessageBox.Show("Для эталона с n = " + n + " коэффициент отражения: " + Math.Round(r, 3));
		}

		
		private void kOtrLabel6_Click_1(object sender, EventArgs e)
		{
			double n = Convert.ToDouble(pPrel6.Text);
			double r = Math.Pow((n - 1), 2) / Math.Pow((n + 1), 2);
			MessageBox.Show("Для эталона с n = " + n + " коэффициент отражения: " + Math.Round(r, 3));
		}
		private void kOtrLabel7_Click(object sender, EventArgs e)
		{
			double n = Convert.ToDouble(pPrel7.Text);
			double r = Math.Pow((n - 1), 2) / Math.Pow((n + 1), 2);
			MessageBox.Show("Для эталона с n = " + n + " коэффициент отражения: " + Math.Round(r, 3));
		}
		public void odinEtal_Click(object sender, EventArgs e)
        {

			// вывод расстояния между максимумами
			double w = Convert.ToDouble(dWave.Text);
			double d1 = Convert.ToDouble(dEtal1.Text) * 1000000;

			double n1 = Convert.ToDouble(pPrel1.Text);
			double r1 = Convert.ToDouble(kOtr1.Text);
			double dlym1 = (w * w) / (2 * d1 * n1);
			dLymOutput.Text = "dλ = " + Convert.ToString(Math.Round(dlym1, 3));
			//double[] weig = new double[] { d1, d2, d3, d4 };


			//контрастность
			/*
			contrast1 = (1 + r1) / (1 - r1);
			conTrast.Text = "ɣ = " + Convert.ToString(Math.Round(contrast1, 1));*/

			//ширина спектральной линии
			contrast1 = ((w * w) * (1 - r1)) / (2 * n1 * d1 * Math.Sqrt(r1));

			conTrast.Text = "dl = " + Convert.ToString(Math.Round(contrast1, 1));

			//различие ширины эталона Дельта t
			double doubDt = (1 / (2 * Math.PI) * ((1 - r1) / Math.Sqrt(r1))) * w;
			trackBar1.Minimum = 0 - Convert.ToInt32(doubDt);
			trackBar1.Maximum = 0 + Convert.ToInt32(doubDt);

			


			dLymOutput.Show();
			//conTrast.Show();
			AllParam ap = new AllParam()


			{
				Otr1 = this.kOtr1.Text,
				Otr2 = this.kOtr2.Text,
				Otr3 = this.kOtr3.Text,
				Otr4 = this.kOtr4.Text,
				Otr5 = this.kOtr5.Text,
				Otr6 = this.kOtr6.Text,
				Otr7 = this.kOtr7.Text,
				/*Prop1 = this.kProp1.Text,// поменять0
				Prop2 = this.kProp2.Text,
				Prop3 = this.kProp3.Text,
				Prop4 = this.kProp4.Text,*/

				Etal1 = this.dEtal1.Text,
				Etal2 = this.dEtal2.Text,
				Etal3 = this.dEtal3.Text,
				Etal4 = this.dEtal4.Text,
				Etal5 = this.dEtal5.Text,
				Etal6 = this.dEtal6.Text,
				Etal7 = this.dEtal7.Text,

				Prel1 = this.pPrel1.Text,
				Prel2 = this.pPrel2.Text,
				Prel3 = this.pPrel3.Text,
				Prel4 = this.pPrel4.Text,
				Prel5 = this.pPrel5.Text,
				Prel6 = this.pPrel6.Text,
				Prel7 = this.pPrel7.Text,

				Wave = this.dWave.Text,

				FromLym = this.LymdaAt.Text,
				ToLym = this.LymdaTo.Text,

				Staps = this.BarStap.Value,

				Dt1 = this.trackBar1.Value,
				Dt2 = this.trackBar2.Value,
				Dt3 = this.trackBar3.Value,
				Dt4 = this.trackBar4.Value,
				Dt5 = this.trackBar5.Value,
				Dt6 = this.trackBar6.Value,
				Dt7 = this.trackBar7.Value,

			};

			if (selectK.Checked == true)
			{
				ap.Indicator = 0;
			}
			if (selectWave.Checked == true)
			{
				ap.Indicator = 1;
			}


			
			AP = ap;
			
			
			Graph1 gr1 = new Graph1();
			Po = gr1.CreateGraph1(zg2, AP);
			
			


		}
		
		public void dvaEtal_Click(object sender, EventArgs e)
        {
			

			try
			{//GetIndicator(selectWave);
				Graph2 gr2 = new Graph2();
				Po2 = gr2.CreateGraph2(zg2, AP, Po);
				AllParam app = new AllParam();


				// вывод расстояния между максимумами
				double w = Convert.ToDouble(dWave.Text);
				double d2 = Convert.ToDouble(dEtal2.Text) * 1000000;
				double d1 = Convert.ToDouble(dEtal1.Text) * 1000000;
				


				double n2 = Convert.ToDouble(pPrel2.Text);
				double n1 = Convert.ToDouble(pPrel1.Text);

				double r2 = Convert.ToDouble(kOtr2.Text);

				double dlym2 = 0;
			

				if (d2 > d1)
                {
					dlym2 = (w * w) / (2 * d1 * n2);
				}

				else
                {
					dlym2 = (w * w) / (2 * d2 * n2);
				}

				dLymOutput.Text = "dλ = " + Convert.ToString(Math.Round(dlym2, 3));



				double doubDt2 = (1 / (2 * Math.PI) * ((1 - r2) / Math.Sqrt(r2))) * w;
				trackBar2.Minimum = 0 - Convert.ToInt32(doubDt2);
				trackBar2.Maximum = 0 + Convert.ToInt32(doubDt2);

				//контрастность

				contrast2 = (1 + r2) / (1 - r2);
				conTrast.Text = "ɣ = " + Convert.ToString(Math.Round(contrast2 * contrast1, 1));
			}
			catch {  }
		
		}

		public void triEtal_Click(object sender, EventArgs e)
        {

			try
			{
				Graph3 gr3 = new Graph3();
				Po3 = gr3.CreateGraph3(zg2, AP, Po2);
				AllParam app = new AllParam();

				// вывод расстояния между максимумами
				double w = Convert.ToDouble(dWave.Text);
				double d3 = Convert.ToDouble(dEtal3.Text) * 1000000;
				double d1 = Convert.ToDouble(dEtal1.Text) * 1000000;
				double d2 = Convert.ToDouble(dEtal2.Text) * 1000000;
				
				
				double n = Convert.ToDouble(pPrel3.Text);
				double r3 = Convert.ToDouble(kOtr3.Text);

				double doubDt3 = (1 / (2 * Math.PI) * ((1 - r3) / Math.Sqrt(r3))) * w;
				trackBar3.Minimum = 0 - Convert.ToInt32(doubDt3);
				trackBar3.Maximum = 0 + Convert.ToInt32(doubDt3);

				double[] weig = new double[] { d1, d2, d3};
				double minN = weig[0];
				for(int i=0; i < weig.Length; i++)
					if(weig[i] < minN)
                    {
						minN = weig[i];
                    }                



				double dlym1 = (w * w) / (2 * minN * n);
				dLymOutput.Text = "dλ = " + Convert.ToString(Math.Round(dlym1, 3));

				//контрастность

				contrast3 = (1 + r3) / (1 - r3); ;
				conTrast.Text = "ɣ = " + Convert.ToString(Math.Round(contrast3 * contrast2 * contrast1, 1));
			}
			catch { }
		}

		public void chetEtal_Click(object sender, EventArgs e)
        {

			try
			{
				Graph4 gr4 = new Graph4();
				Po4 = gr4.CreateGraph4(zg2, AP, Po3);

				double w = Convert.ToDouble(dWave.Text);
				double r4 = Convert.ToDouble(kOtr4.Text);
				double d3 = Convert.ToDouble(dEtal3.Text) * 1000000;
				double d1 = Convert.ToDouble(dEtal1.Text) * 1000000;
				double d2 = Convert.ToDouble(dEtal2.Text) * 1000000;
				double d4 = Convert.ToDouble(dEtal4.Text) * 1000000;

				double doubDt4 = (1 / (2 * Math.PI) * ((1 - r4) / Math.Sqrt(r4))) * w;
				trackBar4.Minimum = 0 - Convert.ToInt32(doubDt4);
				trackBar4.Maximum = 0 + Convert.ToInt32(doubDt4);


				double[] weig = new double[] { d1, d2, d3, d4};
				double minN = weig[0];
				for (int i = 0; i < weig.Length; i++)
					if (weig[i] < minN)
					{
						minN = weig[i];
					}

				double n = Convert.ToDouble(pPrel4.Text);
				double dlym1 = (w * w) / (2 * minN * n);
				dLymOutput.Text = "dλ = " + Convert.ToString(Math.Round(dlym1, 3));
			}
			catch { }
		}
		
		private void fiveEtal_Click(object sender, EventArgs e)
		{
			try
			{
				Graph5 gr5 = new Graph5();
				Po5 = gr5.CreateGraph5(zg2, AP, Po4);

				double w = Convert.ToDouble(dWave.Text);
				double r5 = Convert.ToDouble(kOtr5.Text);
				double d3 = Convert.ToDouble(dEtal3.Text) * 1000000;
				double d1 = Convert.ToDouble(dEtal1.Text) * 1000000;
				double d2 = Convert.ToDouble(dEtal2.Text) * 1000000;
				double d4 = Convert.ToDouble(dEtal4.Text) * 1000000;
				double d5 = Convert.ToDouble(dEtal5.Text) * 1000000;

				double doubDt5 = (1 / (2 * Math.PI) * ((1 - r5) / Math.Sqrt(r5))) * w;
				trackBar5.Minimum = 0 - Convert.ToInt32(doubDt5);
				trackBar5.Maximum = 0 + Convert.ToInt32(doubDt5);


				double[] weig = new double[] { d1, d2, d3, d4, d5 };
				double minN = weig[0];
				for (int i = 0; i < weig.Length; i++)
					if (weig[i] < minN)
					{
						minN = weig[i];
					}

				double n = Convert.ToDouble(pPrel5.Text);
				double dlym1 = (w * w) / (2 * minN * n);
				dLymOutput.Text = "dλ = " + Convert.ToString(Math.Round(dlym1, 3));
			}
			catch { }
		}
		
		

		
		private void sixEtal_Click(object sender, EventArgs e)
		{
			try
			{
				Graph6 gr6 = new Graph6();
				Po6 = gr6.CreateGraph6(zg2, AP, Po5);

				double w = Convert.ToDouble(dWave.Text);
				double r6 = Convert.ToDouble(kOtr6.Text);
				double d3 = Convert.ToDouble(dEtal3.Text) * 1000000;
				double d1 = Convert.ToDouble(dEtal1.Text) * 1000000;
				double d2 = Convert.ToDouble(dEtal2.Text) * 1000000;
				double d4 = Convert.ToDouble(dEtal4.Text) * 1000000;
				double d5 = Convert.ToDouble(dEtal5.Text) * 1000000;
				double d6 = Convert.ToDouble(dEtal6.Text) * 1000000;

				double doubDt6 = (1 / (2 * Math.PI) * ((1 - r6) / Math.Sqrt(r6))) * w;
				trackBar6.Minimum = 0 - Convert.ToInt32(doubDt6);
				trackBar6.Maximum = 0 + Convert.ToInt32(doubDt6);


				double[] weig = new double[] { d1, d2, d3, d4, d5, d6 };
				double minN = weig[0];
				for (int i = 0; i < weig.Length; i++)
					if (weig[i] < minN)
					{
						minN = weig[i];
					}

				double n = Convert.ToDouble(pPrel6.Text);
				double dlym1 = (w * w) / (2 * minN * n);
				dLymOutput.Text = "dλ = " + Convert.ToString(Math.Round(dlym1, 3));
			}
			catch { }
		}

		private void sevenEtal_Click(object sender, EventArgs e)
		{
			try
			{
				Graph7 gr7 = new Graph7();
				gr7.CreateGraph7(zg2, AP, Po6);

				double w = Convert.ToDouble(dWave.Text);
				double r7 = Convert.ToDouble(kOtr7.Text);
				double d3 = Convert.ToDouble(dEtal3.Text) * 1000000;
				double d1 = Convert.ToDouble(dEtal1.Text) * 1000000;
				double d2 = Convert.ToDouble(dEtal2.Text) * 1000000;
				double d4 = Convert.ToDouble(dEtal4.Text) * 1000000;
				double d5 = Convert.ToDouble(dEtal5.Text) * 1000000;
				double d6 = Convert.ToDouble(dEtal6.Text) * 1000000;
				double d7 = Convert.ToDouble(dEtal7.Text) * 1000000;

				double doubDt7 = (1 / (2 * Math.PI) * ((1 - r7) / Math.Sqrt(r7))) * w;
				trackBar7.Minimum = 0 - Convert.ToInt32(doubDt7);
				trackBar7.Maximum = 0 + Convert.ToInt32(doubDt7);


				double[] weig = new double[] { d1, d2, d3, d4, d5, d6, d7 };
				double minN = weig[0];
				for (int i = 0; i < weig.Length; i++)
					if (weig[i] < minN)
					{
						minN = weig[i];
					}

				double n = Convert.ToDouble(pPrel7.Text);
				double dlym1 = (w * w) / (2 * minN * n);
				dLymOutput.Text = "dλ = " + Convert.ToString(Math.Round(dlym1, 3));
			}
			catch { }
		}

		private void dEtal1_KeyPress(object sender, KeyPressEventArgs e)
        {
			if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
			{
				return;
			}



			if (e.KeyChar == '.')
			{
				e.KeyChar = ',';
			}

			if (e.KeyChar == ',')
			{
				if (dEtal1.Text.IndexOf(',') != -1)
				{
					e.Handled = true;
				}
				return;
			}


			e.Handled = true;
		}

        private void kOtr1_KeyPress(object sender, KeyPressEventArgs e)
        {
			if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
			{
				return;
			}

			

			if (e.KeyChar == '.')
			{
				e.KeyChar = ',';
			}

			if (e.KeyChar == ',')
			{
				if (kOtr1.Text.IndexOf(',') != -1)
				{
					e.Handled = true;
				}
				return;
			}


			e.Handled = true;
		}
		private void kOtr2_KeyPress(object sender, KeyPressEventArgs e)
		{


			if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
			{
				return;
			}



			if (e.KeyChar == '.')
			{
				e.KeyChar = ',';
			}

			if (e.KeyChar == ',')
			{
				if (kOtr2.Text.IndexOf(',') != -1)
				{
					e.Handled = true;
				}
				return;
			}


			e.Handled = true;
		}
		private void kOtr3_KeyPress(object sender, KeyPressEventArgs e)
		{


			if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
			{
				return;
			}



			if (e.KeyChar == '.')
			{
				e.KeyChar = ',';
			}

			if (e.KeyChar == ',')
			{
				if (kOtr3.Text.IndexOf(',') != -1)
				{
					e.Handled = true;
				}
				return;
			}


			e.Handled = true;
		}
		private void kOtr4_KeyPress(object sender, KeyPressEventArgs e)
		{


			if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
			{
				return;
			}



			if (e.KeyChar == '.')
			{
				e.KeyChar = ',';
			}

			if (e.KeyChar == ',')
			{
				if (kOtr4.Text.IndexOf(',') != -1)
				{
					e.Handled = true;
				}
				return;
			}


			e.Handled = true;
		}


		private void button2_Click(object sender, EventArgs e)
        {
			this.Close();
        }

       

		
		private void dEtal3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar >= '0') && (e.KeyChar <= '9') && (e.KeyChar == '.') && (e.KeyChar == ','))
			{
				return;
			}



			if (e.KeyChar == '.')
			{
				e.KeyChar = ',';
			}

			if (e.KeyChar == ',')
			{
				if (dEtal3.Text.IndexOf(',') != -1)
				{
					e.Handled = true;
				}
				return;
			}


			e.Handled = true;
		}

		private void dEtal4_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar >= '0') && (e.KeyChar <= '9') && (e.KeyChar == '.') && (e.KeyChar == ','))
			{
				return;
			}



			if (e.KeyChar == '.')
			{
				e.KeyChar = ',';
			}

			if (e.KeyChar == ',')
			{
				if (dEtal4.Text.IndexOf(',') != -1)
				{
					e.Handled = true;
				}
				return;
			}


			e.Handled = true;
		}

		private void dWave_KeyPress(object sender, KeyPressEventArgs e)
        {
			if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
			{
				return;
			}



			if (e.KeyChar == '.')
			{
				e.KeyChar = ',';
			}

			if (e.KeyChar == ',')
			{
				if (dWave.Text.IndexOf(',') != -1)
				{
					e.Handled = true;
				}
				return;
			}

			if (Char.IsControl(e.KeyChar))
			{

				if (e.KeyChar == (char)Keys.Enter)
					dEtal2.Focus();
				return;
			}
			e.Handled = true;
		}

        private void pPrel_KeyPress(object sender, KeyPressEventArgs e)
        {
			if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
			{
				return;
			}



			if (e.KeyChar == '.')
			{
				e.KeyChar = ',';
			}

			if (e.KeyChar == ',')
			{
				if (pPrel1.Text.IndexOf(',') != -1)
				{
					e.Handled = true;
				}
				return;
			}

			if (Char.IsControl(e.KeyChar))
			{

				if (e.KeyChar == (char)Keys.Enter)
					dWave.Focus();
				return;
			}
			e.Handled = true;
		}

		private void pPrel2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
			{
				return;
			}



			if (e.KeyChar == '.')
			{
				e.KeyChar = ',';
			}

			if (e.KeyChar == ',')
			{
				if (pPrel2.Text.IndexOf(',') != -1)
				{
					e.Handled = true;
				}
				return;
			}

			if (Char.IsControl(e.KeyChar))
			{

				if (e.KeyChar == (char)Keys.Enter)
					dWave.Focus();
				return;
			}
			e.Handled = true;
		}

		private void pPrel3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
			{
				return;
			}



			if (e.KeyChar == '.')
			{
				e.KeyChar = ',';
			}

			if (e.KeyChar == ',')
			{
				if (pPrel3.Text.IndexOf(',') != -1)
				{
					e.Handled = true;
				}
				return;
			}

			if (Char.IsControl(e.KeyChar))
			{

				if (e.KeyChar == (char)Keys.Enter)
					dWave.Focus();
				return;
			}
			e.Handled = true;
		}

		private void pPrel4_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
			{
				return;
			}



			if (e.KeyChar == '.')
			{
				e.KeyChar = ',';
			}

			if (e.KeyChar == ',')
			{
				if (pPrel4.Text.IndexOf(',') != -1)
				{
					e.Handled = true;
				}
				return;
			}

			if (Char.IsControl(e.KeyChar))
			{

				if (e.KeyChar == (char)Keys.Enter)
					dWave.Focus();
				return;
			}
			e.Handled = true;
		}

		private void Form1_Load_1(object sender, EventArgs e)
        {

        }

		Point lastPoint;
        

      

      

       
       

        private void panel2_MouseDown_1(object sender, MouseEventArgs e)
        {
			lastPoint = new Point(e.X, e.Y);
		}

        private void panel2_MouseMove_1(object sender, MouseEventArgs e)
        {
			if (e.Button == MouseButtons.Left)
			{
				this.Left += e.X - lastPoint.X;
				this.Top += e.Y - lastPoint.Y;
			}
		}

      

        private void odinEtal_MouseEnter(object sender, EventArgs e)
        {
			this.odinEtal.ForeColor = System.Drawing.Color.FromArgb(244, 244, 246);
		}
        private void odinEtal_MouseLeave(object sender, EventArgs e)
        {
			this.odinEtal.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46);
		}

        private void dvaEtal_MouseEnter(object sender, EventArgs e)
        {
			this.dvaEtal.ForeColor = System.Drawing.Color.FromArgb(244, 244, 246);
		}
		private void dvaEtal_MouseLeave(object sender, EventArgs e)
        {
			this.dvaEtal.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46);
		}

        private void triEtal_MouseEnter(object sender, EventArgs e)
        {
			this.triEtal.ForeColor = System.Drawing.Color.FromArgb(244, 244, 246);
		}
		private void triEtal_MouseLeave(object sender, EventArgs e)
        {
			this.triEtal.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46);
		}


		private void chetEtal_MouseEnter(object sender, EventArgs e)
		{
			this.chetEtal.ForeColor = System.Drawing.Color.FromArgb(244, 244, 246);
		}
		private void chetEtal_MouseLeave(object sender, EventArgs e)
		{
			this.chetEtal.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46);
		}


	
		private void fiveEtal_MouseEnter(object sender, EventArgs e)
		{
			this.fiveEtal.ForeColor = System.Drawing.Color.FromArgb(244, 244, 246);
		}
		private void fiveEtal_MouseLeave(object sender, EventArgs e)
		{
			this.fiveEtal.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46);
		}


		private void sixEtal_MouseEnter(object sender, EventArgs e)
		{
			this.sixEtal.ForeColor = System.Drawing.Color.FromArgb(244, 244, 246);
		}
		private void sixEtal_MouseLeave(object sender, EventArgs e)
		{
			this.sixEtal.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46);
		}


		private void sevenEtal_MouseEnter(object sender, EventArgs e)
		{
			this.sevenEtal.ForeColor = System.Drawing.Color.FromArgb(244, 244, 246);
		}
		private void sevenEtal_MouseLeave(object sender, EventArgs e)
		{
			this.sevenEtal.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46);
		}



		private void pictureBox1_Click(object sender, EventArgs e)
        {
			this.Close();
		}

        private void pictureBox2_Click(object sender, EventArgs e)
        {
			double i = Convert.ToDouble(LymdaAt.Text);
			double b = i + 1;
			this.LymdaAt.Text = b.ToString();
		}

        private void pictureBox3_Click(object sender, EventArgs e)
        {
			double i = Convert.ToDouble(LymdaTo.Text);
			double b = i + 1;
			this.LymdaTo.Text = b.ToString();
		}

        private void pictureBox4_Click(object sender, EventArgs e)
        {
			int b = 0;
			this.LymdaAt.Text = b.ToString();
			this.LymdaTo.Text = b.ToString();
			this.trackBar1.Value = b;
			this.trackBar2.Value = b;
			this.trackBar3.Value = b;
			this.trackBar4.Value = b;
			this.trackBar5.Value = b;
			this.trackBar5.Value = b;
			this.trackBar6.Value = b;
			this.trackBar7.Value = b;

		}


		private void SavePaneImage(int index)
		{
			// ДИалог выбора имени файла создаем вручную
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "*.png|*.png|*.jpg; *.jpeg|*.jpg;*.jpeg|*.bmp|*.bmp|Все файлы|*.*";

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				// Получием панель по ее индексу
				GraphPane pane = zg2.MasterPane.PaneList[index];

				// Получаем картинку, соответствующую панели
				Bitmap bmp = pane.GetImage();

				// Сохраняем картинку средствами класса Bitmap
				// Формат картинки выбирается исходя из имени выбранного файла
				
				
					bmp.Save(dlg.FileName);
				
			}
		}


		private void pictureBox6_Click(object sender, EventArgs e)
        {
			zg2.GraphPane.CurveList.Clear();
			zg2.GraphPane.GraphObjList.Clear();
			zg2.Refresh();
		}

        private void pictureBox7_Click(object sender, EventArgs e)
        {
			SavePaneImage(0);
		}

      
	
       

        private void Etalon1_Click(object sender, EventArgs e)
        {
			OutPanel1.Width = 200;
			OutPanel1.Height = 80;
			OutPanel1.Location = new Point(8, 40);

			if (OutPanel2.Visible)
			{
				OutPanel2.Hide();
				

				Etalon3.Location = new Point(Etalon3.Location.X, Etalon3.Location.Y - 80);
				Etalon4.Location = new Point(Etalon4.Location.X, Etalon4.Location.Y - 80);

				Etalon2.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
				Etalon2.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);
			}

			if (OutPanel3.Visible)
			{
				OutPanel3.Hide();
				
				Etalon4.Location = new Point(Etalon4.Location.X, Etalon4.Location.Y - 80);

				Etalon3.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
				Etalon3.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);

			}

			if (OutPanel4.Visible)
			{	
				OutPanel4.Hide();
				
				Etalon4.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
				Etalon4.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);

			}
			if (OutPanel1.Visible)
			{
				OutPanel1.Hide();

				
				Etalon2.Location = new Point(Etalon2.Location.X, Etalon2.Location.Y - 80);
				Etalon3.Location = new Point(Etalon3.Location.X, Etalon3.Location.Y - 80);
				Etalon4.Location = new Point(Etalon4.Location.X, Etalon4.Location.Y - 80);
				
				Etalon1.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
				Etalon1.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);

			}

			else
			{
				OutPanel1.Show();

				Etalon1.ForeColor = System.Drawing.Color.FromArgb(244, 244, 246);
				Etalon1.BackColor = System.Drawing.Color.FromArgb(61, 68, 206);
						
				Etalon2.Location = new Point(Etalon2.Location.X, Etalon2.Location.Y + 80);
				Etalon3.Location = new Point(Etalon3.Location.X, Etalon3.Location.Y + 80);
				Etalon4.Location = new Point(Etalon4.Location.X, Etalon4.Location.Y + 80);

				OutPanel2.Hide();
				OutPanel3.Hide();
				OutPanel4.Hide();
			}

			//OutPanel1.Width = 250;
			//OutPanel1.Height = 130;
			OutPanel1.Location = new Point(OutPanel1.Location.X, OutPanel1.Location.Y);
			//OutPanel1.Location = new Point(10,45);
			//label10.Location = new Point(21, 51);
		}

        private void Etalon2_Click(object sender, EventArgs e)
        {
			OutPanel2.Width = 200;
			OutPanel2.Height = 80;
			OutPanel2.Location = new Point(8, 68);

			if (OutPanel1.Visible)//обработано
			{
				OutPanel1.Hide();

				Etalon2.Location = new Point(Etalon2.Location.X, Etalon2.Location.Y - 80);
				Etalon3.Location = new Point(Etalon3.Location.X, Etalon3.Location.Y - 80);
				Etalon4.Location = new Point(Etalon4.Location.X, Etalon4.Location.Y - 80);

				Etalon1.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
				Etalon1.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);

			}
		
			

			if (OutPanel3.Visible) //отбработано
			{
				OutPanel3.Hide();

				Etalon4.Location = new Point(Etalon4.Location.X, Etalon4.Location.Y - 80);

				Etalon3.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
				Etalon3.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);

			}

			if (OutPanel4.Visible) //отбработано
			{
				OutPanel4.Hide();

				Etalon4.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
				Etalon4.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);


			}
			
			if (OutPanel2.Visible) //отбработано
			{
			
				OutPanel2.Hide();

			Etalon3.Location = new Point(Etalon3.Location.X, Etalon3.Location.Y - 80);
			Etalon4.Location = new Point(Etalon4.Location.X, Etalon4.Location.Y - 80);

			Etalon2.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
			Etalon2.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);

			}


			else//отработано
			{
				OutPanel2.Show();

				Etalon2.ForeColor = System.Drawing.Color.FromArgb(244, 244, 246);
				Etalon2.BackColor = System.Drawing.Color.FromArgb(61, 68, 206);
				
				Etalon3.Location = new Point(Etalon3.Location.X, Etalon3.Location.Y + 80);
				Etalon4.Location = new Point(Etalon4.Location.X, Etalon4.Location.Y + 80);
				
				OutPanel1.Hide();
				OutPanel3.Hide();
				OutPanel4.Hide();
			
				
				
			}

			//OutPanel2.Width = 250;
			//OutPanel2.Height = 130;
			OutPanel2.Location = new Point(OutPanel2.Location.X, OutPanel2.Location.Y);
		}

        private void Etalon3_Click(object sender, EventArgs e)
        {
			OutPanel3.Width = 200;
			OutPanel3.Height = 80;
			OutPanel3.Location = new Point(8, 96);

			if (OutPanel1.Visible) //отработано
			{
				OutPanel1.Hide();
				Etalon2.Location = new Point(Etalon2.Location.X, Etalon2.Location.Y - 80);
				Etalon3.Location = new Point(Etalon3.Location.X, Etalon3.Location.Y - 80);
				Etalon4.Location = new Point(Etalon4.Location.X, Etalon4.Location.Y - 80);

				Etalon1.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
				Etalon1.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);

			}

			if (OutPanel2.Visible) //отработано
			{
				OutPanel2.Hide();

				Etalon3.Location = new Point(Etalon3.Location.X, Etalon3.Location.Y - 80);
				Etalon4.Location = new Point(Etalon4.Location.X, Etalon4.Location.Y - 80);

				Etalon2.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
				Etalon2.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);

			}

			
			if (OutPanel4.Visible) //отработано
			{
				OutPanel4.Hide();

				Etalon4.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
				Etalon4.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);

			}

			if (OutPanel3.Visible) //отработано
			{
				OutPanel3.Hide();
				
				Etalon4.Location = new Point(Etalon4.Location.X, Etalon4.Location.Y - 80);
				
				Etalon3.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
				Etalon3.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);

			}

			else //отработано
			{	
				OutPanel3.Show();

				Etalon3.ForeColor = System.Drawing.Color.FromArgb(244, 244, 246);
				Etalon3.BackColor = System.Drawing.Color.FromArgb(61, 68, 206);

				Etalon4.Location = new Point(Etalon4.Location.X, Etalon4.Location.Y +80);

				OutPanel1.Hide();
				OutPanel2.Hide();
				OutPanel4.Hide();
			
				//label10.Location = new Point(label10.Location.X, label10.Location.Y + 130);
			}

		//	OutPanel3.Width = 250;
		//	OutPanel3.Height = 130;
			OutPanel3.Location = new Point(OutPanel3.Location.X, OutPanel3.Location.Y);
		}
		private void Etalon4_Click(object sender, EventArgs e)
		{
			
			OutPanel4.Width = 200;
			OutPanel4.Height = 80;
			OutPanel4.Location = new Point(8, 124);

			if (OutPanel1.Visible)//отработано
			{
				OutPanel1.Hide();

				Etalon2.Location = new Point(Etalon2.Location.X, Etalon2.Location.Y - 80);
				Etalon3.Location = new Point(Etalon3.Location.X, Etalon3.Location.Y - 80);
				Etalon4.Location = new Point(Etalon4.Location.X, Etalon4.Location.Y - 80);

				Etalon1.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
				Etalon1.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);
				
			}

			if (OutPanel2.Visible)//отработано
			{
				OutPanel2.Hide();

				Etalon3.Location = new Point(Etalon3.Location.X, Etalon3.Location.Y - 80);
				Etalon4.Location = new Point(Etalon4.Location.X, Etalon4.Location.Y - 80);

				Etalon2.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
				Etalon2.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);

			}

			if (OutPanel3.Visible)//отработано
			{
				OutPanel3.Hide();

				Etalon4.Location = new Point(Etalon4.Location.X, Etalon4.Location.Y - 80);

				Etalon3.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
				Etalon3.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);
				
			}

			if (OutPanel4.Visible)
			{
				OutPanel4.Hide();

				Etalon4.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
				Etalon4.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);
				
			}

			else
			{
				OutPanel4.Show();

				Etalon4.ForeColor = System.Drawing.Color.FromArgb(244, 244, 246);
				Etalon4.BackColor = System.Drawing.Color.FromArgb(61, 68, 206);
			
				
				OutPanel1.Hide();
				OutPanel2.Hide();
				OutPanel3.Hide();
				
			}

			//OutPanel4.Width = 250;
			//OutPanel4.Height = 130;
			OutPanel4.Location = new Point(OutPanel4.Location.X, OutPanel4.Location.Y);
			
		}
		private void Etalon5_Click(object sender, EventArgs e)
        {

			OutPanel5.Width = 200;
			OutPanel5.Height = 80;
			OutPanel5.Location = new Point(8, 138);
			OutPanel6.Hide();
			OutPanel7.Hide();

			Etalon7.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
			Etalon7.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);
			Etalon6.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
			Etalon6.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);


			if (OutPanel5.Visible)
			{
				OutPanel5.Hide();
				Etalon5.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
				Etalon5.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);
			}
			else
			{
				OutPanel5.Show();
				Etalon5.ForeColor = System.Drawing.Color.FromArgb(244, 244, 246);
				Etalon5.BackColor = System.Drawing.Color.FromArgb(61, 68, 206);

			}
		}

        private void Etalon6_Click(object sender, EventArgs e)
        {
			
			OutPanel6.Width = 200;
			OutPanel6.Height = 80;
			OutPanel6.Location = new Point(8, 138);
			OutPanel5.Hide();
			OutPanel7.Hide();
			Etalon5.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
			Etalon5.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);
			Etalon7.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
			Etalon7.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);

			if (OutPanel6.Visible)
			{ 
				OutPanel6.Hide();
				Etalon6.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
				Etalon6.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);
			}
			else
			{
				OutPanel6.Show();
				Etalon6.ForeColor = System.Drawing.Color.FromArgb(244, 244, 246);
				Etalon6.BackColor = System.Drawing.Color.FromArgb(61, 68, 206);

			}
		}

        private void Etalon7_Click(object sender, EventArgs e)
        {
			OutPanel7.Width = 200;
			OutPanel7.Height = 80;
			OutPanel7.Location = new Point(8, 138);
			OutPanel5.Hide();
			OutPanel6.Hide();
			Etalon5.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
			Etalon5.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);
			Etalon6.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
			Etalon6.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);

			if (OutPanel7.Visible)
			{
				OutPanel7.Hide();
				Etalon7.ForeColor = System.Drawing.Color.FromArgb(45, 45, 46); //черный
				Etalon7.BackColor = System.Drawing.Color.FromArgb(244, 244, 246);

				
			}
			else
			{
				OutPanel7.Show();
				Etalon7.ForeColor = System.Drawing.Color.FromArgb(244, 244, 246);
				Etalon7.BackColor = System.Drawing.Color.FromArgb(61, 68, 206);
				

			}
		}
		private void Form1_Load_2(object sender, EventArgs e)
        {
			OutPanel1.Hide();
			OutPanel2.Hide();
			OutPanel3.Hide();
			OutPanel4.Hide();
			dLymOutput.Hide();
			conTrast.Hide();
			OutPanel5.Hide();
			OutPanel6.Hide();
			OutPanel7.Hide();
			conTrast.Hide();
			//fiveEtal.Hide();
		}

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

      

        private void OtherPanelClose_Click(object sender, EventArgs e)
        {
			OutPanel5.Hide();
		}

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
			label3.Text = trackBar1.Value.ToString() + "нм";
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
			label17.Text = trackBar3.Value.ToString() + "нм";
		}

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
			label11.Text = trackBar2.Value.ToString() + "нм";
		}

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
			label15.Text = trackBar4.Value.ToString() + "нм";
		}

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
			OutDt5.Text = trackBar5.Value.ToString() + "нм";
		}
				

        private void trackBar6_Scroll_1(object sender, EventArgs e)
        {
			OutDt6.Text = trackBar6.Value.ToString() + "нм";
		}

       
        private void trackBar7_Scroll(object sender, EventArgs e)
        {
			OutDt7.Text = trackBar7.Value.ToString() + "нм";
		}

     
    }
   
}

//button1.Focus();


