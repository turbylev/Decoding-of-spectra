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
	public partial class Form2 : Form
	{
		AllParam AP = new AllParam();
		List<Points> Po = new List<Points>();
		
		List<Points2> Po2 = new List<Points2>();
		public Form2(AllParam ap)
		{
			AP = ap;

			InitializeComponent();
			kOtrazh.Text += "\t\t" + ap.Otr1;
			Kprop.Text += "\t\t" + ap.Prop1;
			dEtalona.Text += "\t\t" + ap.Etal1 + " мм";
			wave.Text += "\t\t" + ap.Wave + " нм";
			prelomleni.Text += "\t\t" + ap.Prel1;


			
		}


		public void Form2_Load(object sender, EventArgs e)
		{
			
			//Graph1 gr1 = new Graph1();
			//Po = gr1.CreateGraph1(zg1, AP);
			SetSize();

		}
		private void graph2_Click_1(object sender, EventArgs e)
		{
			
			Graph2 gr2 = new Graph2();
			Po2 = gr2.CreateGraph2(zg1, AP, Po);
			dEtalona.Text = "\t\t" + "L2 = " + AP.Etal2 + " мм";

		}

		private void graph3_Click(object sender, EventArgs e)
		{
			
			Graph3 gr3 = new Graph3();
			gr3.CreateGraph3(zg1, AP, Po2);
			dEtalona.Text = "\t\t" + "L3 = " + AP.Etal3 + " мм";
		}






		private void button2_Click(object sender, EventArgs e)
		{
			/*AllParam app = new AllParam();
			if (radioButton1.Checked == true)
			{
				app.Indicator = 0;
			}

			if (radioButton2.Checked == false)
			{
				app.Indicator = 1;

			}*/
			Graph1 gr1 = new Graph1();
			Po = gr1.CreateGraph1(zg1, AP);
			dEtalona.Text = "\t\t" + "L1 = " + AP.Etal1 + " мм";
			SetSize();

			
			
			

		}





		private void Form2_Resize(object sender, EventArgs e)
		{
			//SetSize();
		}

		
		private void SetSize()
		{
			zg1.Location = new Point(10, 10);
			// Leave a small margin around the outside of the control
			zg1.Size = new Size(this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 85);
		}

        private void button1_Click(object sender, EventArgs e)
        {
			this.Close();
		}

        





        /*private void button1_Click(object sender, EventArgs e)
{
//this.Text = "Досвидания";
//System.Threading.Thread.Sleep(2000); 
this.Close();	
}*/


    }
}

